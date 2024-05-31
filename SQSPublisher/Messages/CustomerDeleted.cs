using System.Text.Json.Serialization;

namespace SQSPublisher.Messages;

public class CustomerDeleted
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}