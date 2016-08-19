using Newtonsoft.Json;
using System.Collections.Generic;

namespace XamFormsEfficientNetworking.Models
{
    public class Order
    {
        public string ObjectId { get; set; }
        public string OrderNumber { get; set; }
        [JsonIgnore]
        public List<Item> Items { get; set; }
    }
}
