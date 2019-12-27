using MongoDB.Driver;
using RealEstateListing.Models;

namespace RealEstateListing.Data
{
    public class RealEstateContext
    {
        // Create an instance of MongoClient. Requires a connection string.
        //MongoDB client abstracts the interactions with the server.

        public IMongoDatabase Database { get; set; }
        public RealEstateContext(string connectionString, string databaseName)
        {
            var mongoClient = new MongoClient(connectionString);
            Database = mongoClient.GetDatabase(databaseName);
        }

        public IMongoCollection<Rental> Rentals {get {

            return Database.GetCollection<Rental>("rentals");
        }}

    }

}