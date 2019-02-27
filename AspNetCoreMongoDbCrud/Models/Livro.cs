using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AspNetCoreMongoDbCrud.Models
{
    public class Livro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Preco")]
        public decimal Preco { get; set; }

        [BsonElement("Categoria")]
        public string Categoria { get; set; }

        [BsonElement("Autor")]
        public string Autor { get; set; }
    }
}
