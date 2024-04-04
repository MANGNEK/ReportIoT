using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ReportIoT.Models;

public class DataDayNowModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public string Temperture { get; set; } = string.Empty;
    public string Humidity { get; set; } = string.Empty;
    public string WindSpeed { get; set; } = string.Empty;
    public string Cloud { get; set; } = string.Empty;
}
