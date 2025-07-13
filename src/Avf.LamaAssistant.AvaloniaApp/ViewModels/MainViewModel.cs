using System;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;

namespace Avf.LamaAssistant.AvaloniaApp.ViewModels;

public class MainViewModel : ViewModelBase
{
   public ReactiveCommand<Unit, Unit> SayHelloCommand { get; }

    private string _prompt = "Answer with one word only. Give me the surname of a random German chancelor.";

public string Prompt
   {
    get => _prompt;
      set => this.RaiseAndSetIfChanged(ref _prompt, value);
}

    private string _description = "string.Empty";
   public string Description
   {
      get => _description;
      set => this.RaiseAndSetIfChanged(ref _description, value);
   }
   private string _data = "";
   public string Data
   {
      get => _data;
      set => this.RaiseAndSetIfChanged(ref _data, value);
   }

   public MainViewModel()
   {
      //Prompt = "Answer with one word only. What is the german word for the english word rain?";
      //Prompt = "Answer with one word only.";

      SayHelloCommand = ReactiveCommand.CreateFromTask(async () =>
        {
           var ollamaToolkitWrapper = new OllamaToolkit.OllamaToolkitWrapper<string>();
           Description = "Thinking...";
           //await Task.Delay(1500); // Simulate async work
           //Description = $"Hello at {DateTime.Now:T}";           
           var result = await ollamaToolkitWrapper.GetOllamaAnswer(Prompt, Data);
           Description = $"{result.Duration.TotalSeconds} {result.Value}";
        });
   }
}
