using Database6.Model;
using MongoDB.Driver;

namespace Database6
{
    public class EmployeeContext
    {
        private readonly IMongoDatabase _database;

        public EmployeeContext(IConfiguration configuration) 
        {
            var connectionString = configuration.GetSection("MongoDBSettings:ConnectionString"). Value;
            var databaseName = configuration.GetSection("MongoDBSettings:DatabaseName").Value;
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }
        public IMongoCollection<Employee> Drivers => _database.GetCollection<Employee>("poctransactioncollection");
    }
}
