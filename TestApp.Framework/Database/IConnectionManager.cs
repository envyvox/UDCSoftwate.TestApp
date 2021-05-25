using System.Data;

namespace TestApp.Framework.Database
{
    public interface IConnectionManager
    {
        IDbConnection GetConnection();
    }
}
