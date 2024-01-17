using System.Configuration;

namespace APIRest.Services
{
    public abstract class BaseDataService
    {
        protected readonly string _connectionString;

        protected BaseDataService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
    }
}