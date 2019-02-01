using System;
using System.IO;
using System.Runtime.CompilerServices;
using BlocksCore.Data.Abstractions;
using BlocksCore.Loader.Abstractions.Modules.Builder;
using BlocksCore.Loader.Abstractions.Shell;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BlocksCore.Data
{
    public static class BlocksCoreBuilderExtensions
    {
        public static BlocksCoreBuilder AddDataAccess(this BlocksCoreBuilder builder)
        {

            builder.ConfigureServices(services =>
            {
                services.TryAddDataProvider(name: "Sql Server", value: "SqlConnection", hasConnectionString: true,
                    hasTablePrefix: true, isDefault: false);
                services.TryAddDataProvider(name: "Sqlite", value: "Sqlite", hasConnectionString: false,
                    hasTablePrefix: false, isDefault: true);
                services.TryAddDataProvider(name: "MySql", value: "MySql", hasConnectionString: true,
                    hasTablePrefix: true, isDefault: false);
                services.TryAddDataProvider(name: "Postgres", value: "Postgres", hasConnectionString: true,
                    hasTablePrefix: true, isDefault: false);

                services.AddDbContext<BlocksCoreDbContext>();


                services.AddScoped<IDataContext,DataContext>();

            });

            return builder;
        }
    }
}