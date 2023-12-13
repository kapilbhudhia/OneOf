using Newtonsoft.Json;
namespace OneOf
{
    public interface IOneOf 
    { 
        [JsonProperty(TypeNameHandling = TypeNameHandling.Auto, PropertyName ="_$type")]
        object Value { get ; }
        int Index { get; }
    }
}