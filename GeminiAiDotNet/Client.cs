using System.Net;
using System;
using System.Text;
using System.Text.Json;
using Gemini.Model;
using System.Net.Http.Json;

namespace Gemini
{
    public class Client
    {
        public string ApiKey { get; set; }

        public string Model { get; set; }

        public string Url { get; set; }

        public string Version { get; set; }

        public Client(string apiKey, string model) 
        {
            Url = "https://generativelanguage.googleapis.com";
            Version = "v1beta";
            Model = model;
            ApiKey = apiKey;
        }

        public Client(string apiKey)
        {
            Url = "https://generativelanguage.googleapis.com";
            Version = "v1beta";
            Model = "gemini-2.0-flash";
            ApiKey = apiKey;
        }

        public async Task<GeminiResponse?> generate_content(string text)
        {
            Gemini.Model.GeminiGenerate content = new Gemini.Model.GeminiGenerate();
            content.contents = new List<Model.GeminiContent>();
            var gemini_content = new Gemini.Model.GeminiContent();
            gemini_content.parts = new List<Model.GeminiPart>();
            gemini_content.parts.Add(new Model.GeminiPart() { text = text });
            content.contents.Add(gemini_content);

            var response = await Rest("generateContent", content);

            string payload = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<GeminiResponse>(payload);
        }

        private async Task<HttpResponseMessage> Rest(string command, object content)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, $"{Url}/{Version}/models/{Model}:{command}?key={ApiKey}"))
                {
                    request.Content = JsonContent.Create(content);

                    HttpResponseMessage response = await client.SendAsync(request);

                    return response;
                }
            }

            
        }

    }
}
