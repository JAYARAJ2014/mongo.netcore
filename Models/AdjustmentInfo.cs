using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RealEstateListing.ViewModels;

namespace RealEstateListing.Models
{
    public class AdjustmentInfo
    {
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public string Reason { get; set; }

        public AdjustmentInfo(AdjustPrice adjustredPrice, decimal oldPrice)
        {
            OldPrice =oldPrice;
            NewPrice = adjustredPrice.NewPrice;
            Reason = adjustredPrice.Reason;
        }
        public string Describe() => $"{OldPrice} - > {NewPrice}: {Reason}";
    }


}