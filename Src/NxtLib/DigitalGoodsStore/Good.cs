using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NxtLib.Internal;

namespace NxtLib.DigitalGoodsStore
{
    public class Good
    {
        public bool Delisted { get; set; }
        public string Description { get; set; }

        [JsonConverter(typeof(StringToIntegralTypeConverter))]
        [JsonProperty(PropertyName = Parameters.Goods)]
        public ulong GoodsId { get; set; }
        public string Name { get; set; }
        public int NumberOfPublicFeedbacks { get; set; }
        public int NumberOfPurchases { get; set; }
        public List<string> ParsedTags { get; set; }

        [JsonConverter(typeof(NqtAmountConverter))]
        [JsonProperty(PropertyName = Parameters.PriceNqt)]
        public Amount Price { get; set; }
        public int Quantity { get; set; }

        [JsonConverter(typeof(StringToIntegralTypeConverter))]
        [JsonProperty(PropertyName = Parameters.Seller)]
        public ulong SellerId { get; set; }
        public string SellerRs { get; set; }
        public string Tags { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}