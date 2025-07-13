using System.Text;
using System.Text.Json;

namespace Avf.OllamaToolkit;


public class LlamaResponseDeserializationException : Exception
{
    public LlamaResponseDeserializationException(string? message) : base(message)
    {
    }
}

public class OllamaAnswer<T>
{
    public T Value { get; set; }
    public TimeSpan Duration { get; set; }
}

public class OllamaToolkitWrapper<T>
{

    public async Task<OllamaAnswer<T>> GetOllamaAnswer(string prompt, string data = "")
    {
        var input = new StringBuilder();
        input.Append(prompt);
        input.Append(" ");
        input.Append(data);

        OllamaAnswer<T> ollamaAnswer = new OllamaAnswer<T>();
        var reponses = await GetLamaResponses(input.ToString());

        ollamaAnswer.Duration = GetDuration(reponses);
        ollamaAnswer.Value = GetDataTypeValue(reponses);

        return ollamaAnswer;
    }

    private T GetDataTypeValue(List<LlamaResponse> responses)
    {
        if (typeof(T) == typeof(bool))
        {
            string answer = GetAnswer(responses);
            bool booleanAnswer;
            if (int.TryParse(answer, out int i))
            {
                booleanAnswer = Convert.ToBoolean(i);
            }
            else
            {
                booleanAnswer = Convert.ToBoolean(answer);
            }
            return (T)(object)booleanAnswer;
        }

        throw new NotImplementedException();
    }

    private static string GetAnswer(List<LlamaResponse> responses)
    {
        return responses[0].response;
    }

    private static TimeSpan GetDuration(List<LlamaResponse> responses)
    {
        var startTime = responses[0].created_at;
        var endTime = responses[1].created_at;

        var duration = endTime - startTime;
        return duration;
    }

    private static async Task<List<LlamaResponse>> GetLamaResponses(string prompt)
    {
        var client = new LlamaApiClient();

        string rawJson = await client.GenerateResponseAsync(prompt);

        // If it's actually a raw string with escaped quotes, unescape it
        string unescaped = System.Text.RegularExpressions.Regex.Unescape(rawJson);

        // Split into lines (each line is a valid JSON object)
        string[] jsonLines = unescaped.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        // Deserialize each line
        List<LlamaResponse> responses = new();
        foreach (string line in jsonLines)
        {
            var response = JsonSerializer.Deserialize<LlamaResponse>(line);
            if (response == null)
            {
                throw new LlamaResponseDeserializationException($"Could not deserialize {line} from {unescaped}");
            }
            responses.Add(response);
        }

        return responses;
    }
}
