using Newtonsoft.Json;

namespace ApiDatatableExample.Utilities
{
    public class Column
    {
        [JsonProperty(PropertyName = "data")]
        public int Data { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "searchable")]
        public bool Searchable { get; set; }

        [JsonProperty(PropertyName = "orderable")]
        public bool Orderable { get; set; }

        [JsonProperty(PropertyName = "search")]
        public Search Search { get; set; }
    }
}
