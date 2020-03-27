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
            var webhookUrl = new Uri("https://outlook.office.com/webhook/78b74c6b-4cbf-4b4d-a4d6-a8b1ffef0938@f01e930a-b52e-42b1-b70f-a8882b5d043b/IncomingWebhook/fed7b023afc14e0e965c887bc8bbff3b/41d97487-1533-4405-89f4-fd294fb50d1a");

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
