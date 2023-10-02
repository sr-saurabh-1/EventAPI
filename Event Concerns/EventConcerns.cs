using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Event_Concerns
{
    public class EventConcerns
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EventId { get; set; }
        public string EventName { get; set; }
        public string EventDesc { get; set; }
        public string EventType { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Status Status { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime  Date { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime  Deadline { get; set; }
        public string  Place { get; set; }

        public string  VanueAndAddress { get; set; }
        public string  LandingPage { get; set; }

        [BsonRepresentation(BsonType.String)]
        public JobType  JobType { get; set; }
        public string  JobTitle{ get; set; }
        public List<string> Roles { get; set; }
        public string  EventCode{ get; set; }
        public string  EventUrl{ get; set; }
        public string  OrganizationUrl{ get; set; }
        public int  RunningRollNo{ get; set; }
        public int  NoOfDigit{ get; set; }

    }
}