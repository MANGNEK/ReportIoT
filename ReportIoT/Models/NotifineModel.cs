using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ReportIoT.Models;

public class NotifineModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public string TypeLog { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
}