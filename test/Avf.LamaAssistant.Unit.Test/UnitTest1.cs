using System.Diagnostics;

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
        string response = await client.GenerateResponseAsync("Answer always with 1 for yes and 0 for no only. Do you understand?");
        Assert.That(response, Is.Not.Null);
        Debug.WriteLine(response);
    }
}
