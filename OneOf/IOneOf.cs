using Newtonsoft.Json;
namespace OneOf
{
    public interface IOneOf 
    { 
        [JsonProperty(TypeNameHandling = TypeNameHandling.Auto)]
        object Value { get ; }
        int Index { get; }
    }
}