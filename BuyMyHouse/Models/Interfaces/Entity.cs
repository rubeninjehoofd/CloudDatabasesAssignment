using Newtonsoft.Json;

namespace BuyMyHouse.Models.Interfaces
{
    public abstract class Entity : IEntity
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid Id { get; set; }
    }
}
