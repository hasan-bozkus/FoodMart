using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.EntityLayer.Entities
{
    public class PeopleViewing
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PeopleViewingId { get; set; }
        public string Title { get; set; }
    }
}
