using System.Text.Json.Serialization;

namespace SQSPublisher.Messages;

public class CustomerCreated
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("fullName")]
    public string FullName { get; set; } = default!;
}