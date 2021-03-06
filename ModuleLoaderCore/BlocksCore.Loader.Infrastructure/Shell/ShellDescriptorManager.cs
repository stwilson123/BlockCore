using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlocksCore.Data.Abstractions;
using BlocksCore.Loader.Abstractions.Modules.Extensions;
using BlocksCore.Loader.Abstractions.Shell;
using BlocksCore.Loader.Abstractions.Shell.Descriptor;
using BlocksCore.Loader.Abstractions.Shell.Descriptor.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlocksCore.Environment.Shell.Data.Descriptors
{
    /// <summary>
    /// Implements <see cref="IShellDescriptorManager"/> by providing the list of features store in the database. 
    /// </summary>
    public class ShellDescriptorManager : IShellDescriptorManager
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ShellSettings _shellSettings;
        private readonly IEnumerable<ShellFeature> _alwaysEnabledFeatures;
        private readonly IEnumerable<IShellDescriptorManagerEventHandler> _shellDescriptorManagerEventHandlers;
        private readonly IDataContext _session;
        private readonly ILogger _logger;
        private ShellDescriptor _shellDescriptor;

        public ShellDescriptorManager(
            IServiceProvider serviceProvider,
            ShellSettings shellSettings,
            IEnumerable<ShellFeature> shellFeatures,
            IEnumerable<IShellDescriptorManagerEventHandler> shellDescriptorManagerEventHandlers,
            IDataContext session,
            ILogger<ShellDescriptorManager> logger)
        {
            _serviceProvider = serviceProvider;
            _shellSettings = shellSettings;
            _alwaysEnabledFeatures = shellFeatures.Where(f => f.AlwaysEnabled).ToArray();
            _shellDescriptorManagerEventHandlers = shellDescriptorManagerEventHandlers;
            _session = session;
            _logger = logger;
        }

        public async Task<ShellDescriptor> GetShellDescriptorAsync()
        {
            // Prevent multiple queries during the same request
            if (_shellDescriptor == null)
            {
                _shellDescriptor = await _session.Query<ShellDescriptor>((s) => s.Features).FirstOrDefaultAsync();

                if (_shellDescriptor == null)
                {
                    // If no descriptor was found, try to update from Beta2
                    //await UpgradeFromBeta2();
                    _shellDescriptor = await _session.Query<ShellDescriptor>().FirstOrDefaultAsync();
                }

                if (_shellDescriptor != null)
                {
                    _shellDescriptor.Features = _alwaysEnabledFeatures.Concat(
                        _shellDescriptor.Features).Distinct().ToList();
                }
            }

            return _shellDescriptor;
        }

        public async Task UpdateShellDescriptorAsync(int priorSerialNumber, IEnumerable<ShellFeature> enabledFeatures, IEnumerable<ShellParameter> parameters)
        {
            var shellDescriptorRecord = await GetShellDescriptorAsync();
            var serialNumber = shellDescriptorRecord == null ? 0 : shellDescriptorRecord.SerialNumber;
            if (priorSerialNumber != serialNumber)
            {
                throw new InvalidOperationException("Invalid serial number for shell descriptor");
            }

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Updating shell descriptor for tenant '{TenantName}' ...", _shellSettings.Name);
            }

            if (shellDescriptorRecord == null)
            {
                shellDescriptorRecord = new ShellDescriptor { SerialNumber = 1 };
            }
            else
            {
                shellDescriptorRecord.SerialNumber++;
            }

            shellDescriptorRecord.Features = _alwaysEnabledFeatures.Concat(enabledFeatures).Distinct().ToList();
            shellDescriptorRecord.Parameters = parameters.ToList();

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Shell descriptor updated for tenant '{TenantName}'.", _shellSettings.Name);
            }

            _session.Save(shellDescriptorRecord);

            // Update cached reference
            _shellDescriptor = shellDescriptorRecord;

            await _shellDescriptorManagerEventHandlers.InvokeAsync(e => e.Changed(shellDescriptorRecord, _shellSettings.Name), _logger);
        }

//        private async Task UpgradeFromBeta2()
//        {
//            // TODO: Can be removed when going RC as users are not supposed to go from beta2 to RC
//            // c.f. https://github.com/OrchardCMS/BlocksCore/issues/2439
//
//            var connectionAccessor = _serviceProvider.GetRequiredService<IDbConnectionAccessor>();
//
//            var connection = await connectionAccessor.GetConnectionAsync();
//            var dialect = SqlDialectFactory.For(connection);
//            var tablePrefix = _shellSettings.TablePrefix;
//
//            if (!String.IsNullOrEmpty(tablePrefix))
//            {
//                tablePrefix += '_';
//            }
//
//            var documentTable = dialect.QuoteForTableName($"{tablePrefix}{nameof(Document)}");
//
//            var oldShellDescriptorType = "BlocksCore.Environment.Shell.Descriptor.Models.ShellDescriptor, BlocksCore.Environment.Shell.Abstractions";
//            var newShellDescriptorType = "BlocksCore.Environment.Shell.Descriptor.Models.ShellDescriptor, BlocksCore.Abstractions";
//
//            var updateShellDescriptorCmd = $"UPDATE {documentTable} SET {dialect.QuoteForColumnName(nameof(Document.Type))} = {dialect.GetSqlValue(newShellDescriptorType)} WHERE {dialect.QuoteForColumnName(nameof(Document.Type))} = {dialect.GetSqlValue(oldShellDescriptorType)}";
//
//            var oldShellStateType = "BlocksCore.Environment.Shell.State.ShellState, BlocksCore.Environment.Shell.Abstractions";
//            var newShellStateType = "BlocksCore.Environment.Shell.State.ShellState, BlocksCore.Abstractions";
//
//            var updateShellStateCmd = $"UPDATE {documentTable} SET {dialect.QuoteForColumnName(nameof(Document.Type))} = {dialect.GetSqlValue(newShellStateType)} WHERE {dialect.QuoteForColumnName(nameof(Document.Type))} = {dialect.GetSqlValue(oldShellStateType)}";
//
//            await connection.ExecuteAsync(updateShellDescriptorCmd);
//            await connection.ExecuteAsync(updateShellStateCmd);
//        }
    }
}