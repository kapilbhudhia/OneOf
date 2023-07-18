using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Newtonsoft.Json;

namespace OneOf
{
    public class OneOfMongoSerializer<T> : SerializerBase<T>, IBsonDocumentSerializer
    {
        public override void Serialize(
            MongoDB.Bson.Serialization.BsonSerializationContext context,
            MongoDB.Bson.Serialization.BsonSerializationArgs args,
            T value)
        {
            string json = JsonConvert.SerializeObject(value, Formatting.Indented);
            BsonSerializer.Serialize(context.Writer, BsonDocument.Parse(json));
        }

        public override T Deserialize(
            MongoDB.Bson.Serialization.BsonDeserializationContext context,
            MongoDB.Bson.Serialization.BsonDeserializationArgs args)
        {
            var jsonDocument = new BsonDocumentSerializer().Deserialize(context, args).ToJson();
            return JsonConvert.DeserializeObject<T>(jsonDocument)!;
        }

        public bool TryGetMemberSerializationInfo(string memberName, out BsonSerializationInfo serializationInfo)
        {
            serializationInfo = default!;
            return false;
        }
    }
}