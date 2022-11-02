using Newtonsoft.Json;

namespace ApiDatatableExample.Utilities
{
    public class Search
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "regex")]
        public bool Regex { get; set; }
        public int Id { get; set; }
    }
}
