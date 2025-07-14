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

    [TestCase("Answer with one sentence in one line with less then 255 characters. Summarize software development.")]
    public async Task TestString(string input)
    {
        var ollamaToolkitWrapperBool = new OllamaToolkitWrapper<string>();

        var ollamaAnswer = await ollamaToolkitWrapperBool.GetOllamaAnswer(input);

        Assert.Multiple(() =>
        {
            Assert.That(ollamaAnswer.Duration, Is.LessThan(TimeSpan.FromSeconds(30)));
            //Assert.That(ollamaAnswer.Value.Length, Is.LessThanOrEqualTo(255));
        });
    }

    [TestCase("give me ten colors each in a new line")]
    public async Task TestString2(string input)
    {
        var ollamaToolkitWrapperBool = new OllamaToolkitWrapper<string>();

        var ollamaAnswer = await ollamaToolkitWrapperBool.GetOllamaAnswer(input);

        Assert.Multiple(() =>
        {
            Assert.That(ollamaAnswer.Duration, Is.LessThan(TimeSpan.FromSeconds(30)));
            //Assert.That(ollamaAnswer.Value.Length, Is.LessThanOrEqualTo(255));
        });
    }

    [TestCase("give me ten colors each in a new line, no other text output")]
    public async Task TestString3(string input)
    {
        var ollamaToolkitWrapperBool = new OllamaToolkitWrapper<string[]>();

        var ollamaAnswer = await ollamaToolkitWrapperBool.GetOllamaAnswer(input);

        var array = ollamaAnswer.Value;

        Assert.Multiple(() =>
        {
            Assert.That(ollamaAnswer.Duration, Is.LessThan(TimeSpan.FromSeconds(30)));
            Assert.That(array!.Length, Is.EqualTo(10));
        });
    }
}
