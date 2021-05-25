using System.Data;

namespace TestApp.Framework.Database
{
    public abstract class ConnectionManagerBase : IConnectionManager
    {
        public IDbConnection GetConnection()
        {
            return _connection ??= CreateDbConnection();
        }

        private IDbConnection _connection;
        protected abstract IDbConnection CreateDbConnection();
    }
}
