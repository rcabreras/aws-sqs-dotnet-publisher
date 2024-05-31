// See https://aka.ms/new-console-template for more information

using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Microsoft.Extensions.Configuration;
using SQSPublisher.Messages;


var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
IConfiguration _configuration = configurationBuilder.Build();
var accessKey = _configuration["AWS:AccessKey"];
var secretKey = _configuration["AWS:SecretKey"];

BasicAWSCredentials basicCredentials = new BasicAWSCredentials(accessKey, secretKey);
IAmazonSQS _sqs = new AmazonSQSClient(basicCredentials, RegionEndpoint.USEast2);

var publisher = new SQSPublisher.SQSPublisher(_sqs);
await publisher.PublishAsync("test-queue-1", new CustomerCreated()
{
    Id= 1,
    FullName = "Lua"
});