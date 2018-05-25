using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using NetCoreMongo.Models.Entities;

namespace NetCoreMongo.Models
{
    public class AppDbContext
    {
		private readonly MongoClient Client;
        private readonly IMongoDatabase Database;

        public IMongoCollection<User> Users { get{ return Database.GetCollection<User>("users");} }

		public AppDbContext(IOptions<ApplicationSettings> settings)
        {
            Client = new MongoClient(settings.Value.DbConnectionString);
            Setup();
            Database = Client.GetDatabase(settings.Value.DbName);
        }
        private void Setup()
        {
            ConventionPack pack = new ConventionPack()
            {
                new IgnoreExtraElementsConvention(true)
            };
            ConventionRegistry.Register("IgnoreExtraElements", pack, t => true);
        }
    }
}