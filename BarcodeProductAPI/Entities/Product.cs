using MongoDB.Bson.Serialization.Attributes;

namespace BarcodeProductAPI.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Barcode")]
        public string Barcode { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Price")]
        public decimal Price { get; set; }
        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }
    }
}
