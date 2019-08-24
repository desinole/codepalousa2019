using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDB
{
    public interface IInteraction
    {
        [JsonProperty(PropertyName = "id")]
        string Id { get; set; }
        string medium { get; }
    }
}
