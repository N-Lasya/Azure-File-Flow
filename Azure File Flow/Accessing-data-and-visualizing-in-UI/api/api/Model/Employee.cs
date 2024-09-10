using MongoDB.Bson.Serialization.Attributes;

using MongoDB.Bson;

namespace Database6.Model
{
    public class Employee
    {
        

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ObjectId { get; set; }

        public string id { get; set; }


        public string date { get; set; }

        public string amount { get; set; }

        public string name { get; set; }

        public string transactionId { get; set; }




    }
}
