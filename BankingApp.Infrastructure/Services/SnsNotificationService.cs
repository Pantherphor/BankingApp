using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using BankingApp.Core.Interfaces;
using BankingApp.Core.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace BankingApp.Infrastructure.Services
{
    public class SnsNotificationService : INotificationService
    {
        private readonly IAmazonSimpleNotificationService _snsClient;
        private readonly ILoggerService _logger;
        private readonly string _snsTopicArn;

        public SnsNotificationService(IAmazonSimpleNotificationService snsClient,
                                      ILoggerService logger,
                                      IConfiguration config)
        {
            _snsClient = snsClient;
            _logger = logger;
            _snsTopicArn = config["AWS:SnsTopicArn"];
        }

        public async Task PublishEventAsync(WithdrawalEvent withdrawalEvent)
        {
            try
            {
                var request = new PublishRequest
                {
                    Message = withdrawalEvent.ToJson(),
                    TopicArn = _snsTopicArn
                };

                // NOTE: could be configured with credentials for production
                // to make use, like this is enough for this POC
                //var response = await _snsClient.PublishAsync(request);
                _logger.LogInformation("Event published with MessageId: {response.MessageId}");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Failed to publish event: {exception.Message}");
                throw;
            }
        }
    }

}
