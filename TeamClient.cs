using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Teams
{
    public class TeamClient
    {
        private readonly Uri webHookUri;
        private readonly HttpClient httpClient = new HttpClient();

        //constructor

        public TeamClient(Uri webHookUri)
        {
            this.webHookUri = webHookUri;
        }

        public async Task<HttpResponseMessage> SendMessageAsync(string message, string title, string username)
        {
            PayloadMessage payloadMessage = new PayloadMessage
            {
                //Username = username,
                Type = "MessageCard",
                Title = "Daily chat",
                Text = message
            };

            //serializePayload
            var serializePayload = JsonConvert.SerializeObject(payloadMessage);
            var response = await httpClient.PostAsync(webHookUri,
                    new StringContent(serializePayload, Encoding.UTF8, "application/json"));
            return response;
        }
    }
}
