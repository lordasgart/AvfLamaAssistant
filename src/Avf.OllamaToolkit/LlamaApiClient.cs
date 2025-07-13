using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Avf.OllamaToolkit;

public class LlamaApiClient
{
    //Jeder Prompt in einer Datenbank wird mit apiurl und model gespeichert, also prompt, api_url, model
    private static readonly HttpClient client = new HttpClient();
    private const string ApiUrl = "http://localhost:11434/api/generate";
    private const string Model = "llama3.1:8b";

    public async Task<string> GenerateResponseAsync(string prompt)
    {
        var requestBody = new
        {
            model = Model,
            prompt = prompt
        };

        string json = System.Text.Json.JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync(ApiUrl, content);
        response.EnsureSuccessStatusCode();

        string responseString = await response.Content.ReadAsStringAsync();
        return responseString;
    }
}
