using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace SQSPublisher;

public class SQSPublisher
{
    private readonly IAmazonSQS _sqs;

    public SQSPublisher(IAmazonSQS sqs)
    {
        _sqs = sqs;
    }

    public async Task PublishAsync<T>(string queueName, T message)
    {
        var queueUrl = await _sqs.GetQueueUrlAsync(queueName);
        var request = new SendMessageRequest
        {
            QueueUrl = queueUrl.QueueUrl,
            MessageBody = JsonSerializer.Serialize(message)
        };
        await _sqs.SendMessageAsync(request); 
    }
}