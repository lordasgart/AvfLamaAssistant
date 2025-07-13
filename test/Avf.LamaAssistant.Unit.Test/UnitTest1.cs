using System.Diagnostics;
using System.Text.Json;

namespace Avf.LamaAssistant.Unit.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        var client = new Avf.LamaAssistant.LlamaApiClient();
        string rawJson = await client.GenerateResponseAsync("Answer always with 1 for yes and 0 for no only. Do you understand?");

        // If it's actually a raw string with escaped quotes, unescape it
        string unescaped = System.Text.RegularExpressions.Regex.Unescape(rawJson);

        // Split into lines (each line is a valid JSON object)
        string[] jsonLines = unescaped.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        // Deserialize each line
        List<LlamaResponse> responses = new();
        foreach (string line in jsonLines)
        {
            var response = JsonSerializer.Deserialize<LlamaResponse>(line);
            responses.Add(response);
        }

        var startTime = responses[0].created_at;
        var endTime = responses[1].created_at;

        var duration = endTime - startTime;

        var answer = responses[0].response;

        bool booleanAnswer = Convert.ToBoolean(Convert.ToInt32(answer));

        Assert.That(booleanAnswer, Is.True);

        Assert.That(duration, Is.LessThan(TimeSpan.FromSeconds(10)));

        Assert.That(responses, Is.Not.Null);
        Debug.WriteLine(responses);
    }
}
