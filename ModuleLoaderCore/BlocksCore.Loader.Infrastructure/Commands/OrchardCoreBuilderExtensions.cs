using BlocksCore.Loader.Abstractions.Modules.Builder;
using BlocksCore.Loader.Infrastructure.Commands.Builtin;
using BlocksCore.Loader.Infrastructure.Commands.Parameters;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.Loader.Infrastructure.Commands
{
    public static partial class BlocksCoreBuilderExtensions
    {
        /// <summary>
        /// Adds host level services to provide CLI commands.
        /// </summary>
        public static BlocksCoreBuilder AddCommands(this BlocksCoreBuilder builder)
        {
            var services = builder.ApplicationServices;

            services.AddScoped<ICommandManager, DefaultCommandManager>();
            services.AddScoped<ICommandHandler, HelpCommand>();

            services.AddScoped<ICommandParametersParser, CommandParametersParser>();
            services.AddScoped<ICommandParser, CommandParser>();

            return builder;
        }
    }
}