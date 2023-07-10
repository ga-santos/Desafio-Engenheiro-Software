using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Consumer.Domain.Entities
{
    public class Pedido
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("codigoPedido")]
        public int CodigoPedido { get; set; }

        [BsonElement("codigoCliente")]
        public int CodigoCliente { get; set; }

        [BsonElement("itens")]
        public List<Item> Itens { get; set; }
    }

    public class Item
    {
        [BsonElement("produto")]
        public string Produto { get; set; }

        [BsonElement("quantidade")]
        public int Quantidade { get; set; }

        [BsonElement("preco")]
        public decimal Preco { get; set; }
    }
}
