using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RealEstateListing.ViewModels;

namespace RealEstateListing.Models
{
    public class Rental
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }
        public List<string> Address = new List<string>();
        public Rental()
        {
            AdjustmentsHistory = new List<AdjustmentInfo>();
        }
        public Rental(PostRental postRental)
        {
            Description = postRental.Description;
            NumberOfRooms = postRental.NumberOfRooms;
            Price = postRental.Price;
            Address = (postRental.Address ?? string.Empty).Split('\n').ToList();

            AdjustmentsHistory = new List<AdjustmentInfo>();
        }

        [BsonRepresentation(BsonType.Double)]
        public decimal Price { get; set; }
        public List<AdjustmentInfo> AdjustmentsHistory { get; set; }
        public void AdjustPrice(AdjustPrice adjustedPrice)
        {
            var adjustment = new AdjustmentInfo(adjustedPrice, Price);
            AdjustmentsHistory.Add(adjustment);
            Price = adjustedPrice.NewPrice;
        }
    }


}