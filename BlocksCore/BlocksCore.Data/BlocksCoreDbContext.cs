using System;
using System.Data;
using System.IO;
using BlocksCore.Data.Shell.EntityTypeConfiguration;
using BlocksCore.Loader.Abstractions.Shell;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BlocksCore.Data
{
    public class BlocksCoreDbContext : DbContext
    {
        private readonly IServiceProvider _serviceProvider;

        public BlocksCoreDbContext(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             var shellSettings = _serviceProvider.GetService<ShellSettings>();

                    if (shellSettings.DatabaseProvider == null)
                    {
                        return;
                    }

                   

                    // Disabling query gating as it's failing to improve performance right now
                    //storeConfiguration.DisableQueryGating();
                   
                    switch (shellSettings.DatabaseProvider)
                    {
                        case "SqlConnection":
                            optionsBuilder.UseSqlServer(shellSettings.ConnectionString);
                            break;
                        case "Sqlite":
                            var shellOptions = _serviceProvider.GetService<IOptions<ShellOptions>>();
                            var option = shellOptions.Value;
                            var databaseFolder = Path.Combine(option.ShellsApplicationDataPath, option.ShellsContainerName, shellSettings.Name);
                            var databaseFile = Path.Combine(databaseFolder, "yessql.db");
                            Directory.CreateDirectory(databaseFolder);

                            optionsBuilder.UseSqlite($"Data Source={databaseFile};Cache=Shared");
                            //storeConfiguration.UseSqLite($"Data Source={databaseFile};Cache=Shared", IsolationLevel.ReadUncommitted);
                            break;
                        case "MySql":
                            optionsBuilder.UseMySQL(shellSettings.ConnectionString);
                           // storeConfiguration.UseMySql(shellSettings.ConnectionString, IsolationLevel.ReadUncommitted);
                            break;
//                        case "Postgres":
//                            storeConfiguration.UsePostgreSql(shellSettings.ConnectionString, IsolationLevel.ReadUncommitted);
//                            break;
                        default:
                            throw new ArgumentException("Unknown database provider: " + shellSettings.DatabaseProvider);
                    }
            
       
//
//                    if (!string.IsNullOrWhiteSpace(shellSettings.TablePrefix))
//                    {
//                        storeConfiguration.TablePrefix = shellSettings.TablePrefix + "_";
//                    }
//                    

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ShellEntityTypeConfiguartionApply.ModelCreating(modelBuilder);

        }
    }
}