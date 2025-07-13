using System;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;

namespace Avf.LamaAssistant.AvaloniaApp.ViewModels;

public class MainViewModel : ViewModelBase
{
   public ReactiveCommand<Unit, Unit> SayHelloCommand { get; }

   private string _description = "string.Empty";
   public string Description
   {
      get => _description;
      set => this.RaiseAndSetIfChanged(ref _description, value);
   }

   public MainViewModel()
   {
      SayHelloCommand = ReactiveCommand.CreateFromTask(async () =>
        {
           Description = "Thinking...";
           await Task.Delay(1500); // Simulate async work
           Description = $"Hello at {DateTime.Now:T}";

           Avf.OllamaToolkit.OllamaToolkitWrapper<string> ollamaToolkitWrapper = new OllamaToolkit.OllamaToolkitWrapper<string>();
           var result = await ollamaToolkitWrapper.GetOllamaAnswer("Answer with one word only. Give me the surname of a random German chancelor.");
           Description = $"{result.Duration.TotalSeconds} {result.Value}";
        });
   }
}
