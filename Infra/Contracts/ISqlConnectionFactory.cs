using System.Data;

namespace ExemploDapper.Infra.Contracts
{
    public interface ISqlConnectionFactory
    {
        IDbConnection Connection();
    }
}
