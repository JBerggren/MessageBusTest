namespace Company.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;
    using Microsoft.Extensions.Logging;

    public class UserUpdatedConsumer :
        IConsumer<UserUpdated>
    {
        public UserUpdatedConsumer(ILogger<UserUpdatedConsumer> logger){
            this.Logger = logger;
        }

        public ILogger Logger { get; private set; }

        public Task Consume(ConsumeContext<UserUpdated> context)
        {
            Logger.LogInformation("Got message:", context.Message);
            return Task.CompletedTask;
        }
    }
}