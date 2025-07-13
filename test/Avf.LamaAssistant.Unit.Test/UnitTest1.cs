using System.Diagnostics;
using System.Text.Json;
using Avf.OllamaToolkit;

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
        var ollamaToolkitWrapperBool = new OllamaToolkitWrapper<bool>();

        var ollamaAnswer = await ollamaToolkitWrapperBool.GetOllamaAnswer("Answer always with 1 for yes and 0 for no only. Do you understand?");

        Assert.Multiple(() =>
        {
            Assert.That(ollamaAnswer.Duration, Is.LessThan(TimeSpan.FromSeconds(10)));
            Assert.That(ollamaAnswer.Value, Is.True);
        });
    }

    [Test]
    public async Task Test2()
    {
        var ollamaToolkitWrapperBool = new OllamaToolkitWrapper<bool>();

        var ollamaAnswer = await ollamaToolkitWrapperBool.GetOllamaAnswer("Answer always with true for yes and false for no only. Do you understand?");

        Assert.Multiple(() =>
        {
            Assert.That(ollamaAnswer.Duration, Is.LessThan(TimeSpan.FromSeconds(10)));
            Assert.That(ollamaAnswer.Value, Is.True);
        });
    }
}
