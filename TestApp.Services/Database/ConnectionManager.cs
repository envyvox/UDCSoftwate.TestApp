﻿using System.Data;
using Microsoft.Extensions.Options;
using Npgsql;
using TestApp.Framework.Autofac;
using TestApp.Framework.Database;

namespace TestApp.Services.Database
{
    [InjectableService]
    public class ConnectionManager : ConnectionManagerBase
    {
        private readonly ConnectionOptions _options;

        public ConnectionManager(IOptions<ConnectionOptions> options)
        {
            _options = options.Value;
        }

        protected override IDbConnection CreateDbConnection() => new NpgsqlConnection(_options.ConnectionString);
    }
}
