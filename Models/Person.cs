using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealEstateListing.Models
{
    public class Person
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Address { get; set; }
        public Contact Contact { get; set; }
        public Person()
        {
            Address = new List<string>();
            Contact = new Contact();
        }

    }
}