using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuffTime.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DogJson
    {
        [JsonProperty("dog")]
        public Dog Dog { get; set; }
    }
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Dog
    {
        [JsonProperty("breeds")]
        public List<object> breeds { get; set; }
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("width")]
        public int width { get; set; }
        [JsonProperty("height")]
        public int height { get; set; }
    }
}
