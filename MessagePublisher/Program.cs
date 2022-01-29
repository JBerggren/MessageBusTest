namespace Contracts
{
    using System;
    public record UserUpdated
    {
        public int EmployeeId { get; init; }
        public string Name { get; init; }
        public DateTime LastLogin { get; set; }
    }
}

namespace MessagePublisher
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using MassTransit;
    public class Program
    {
        public static async Task Main()
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq();

            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await busControl.StartAsync(source.Token);
            try
            {
                while (true)
                {
                    string value = await Task.Run(() =>
                    {
                        Console.WriteLine("Enter name for employee 1 (or quit to exit)");
                        Console.Write("> ");
                        return Console.ReadLine();
                    });

                    if ("quit".Equals(value, StringComparison.OrdinalIgnoreCase))
                        break;

                    await busControl.Publish<UserUpdated>(new
                    {
                        EmployeeId = 1,
                        Name=value,
                        LastLogin=DateTime.Now
                    });
                }
            }
            finally
            {
                await busControl.StopAsync();
            }
        }
    }
}
