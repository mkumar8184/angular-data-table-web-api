using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApiDatatableExample.Utilities
{
    public class PagingRequest
    {
        [JsonProperty(PropertyName = "draw")]
        public int Draw { get; set; }

        [JsonProperty(PropertyName = "columns")]
        public IList<Column> Columns { get; set; }

        [JsonProperty(PropertyName = "order")]
        public IList<Order> Order { get; set; }

        [JsonProperty(PropertyName = "start")]
        public int Start { get; set; }

        [JsonProperty(PropertyName = "length")]
        public int Length { get; set; } = 10;

        [JsonProperty(PropertyName = "search")]
        public Search Search { get; set; }
       
    }
}
