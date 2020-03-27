using System;
using System.Threading.Tasks;

namespace Teams
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.WaitAll(IntegrateWithTeamsAsync());

        }

        private static async Task IntegrateWithTeamsAsync()
        {
            var webhookUrl = new Uri("your uri incoming webhook here");

            var slackClient = new TeamClient(webhookUrl);
            while (true)
            {
                Console.Write("Type a message: ");
                var message = Console.ReadLine();
                var response = await slackClient.SendMessageAsync(message, "iambotakasafe", "quyen nguyen");
                var isValid = response.IsSuccessStatusCode ? "valid" : "invalid";
                Console.WriteLine($"Received {isValid} response.");
            }
        }
    }
}
