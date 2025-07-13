using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using Avf.LamaAssistant.AvaloniaApp.ViewModels;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;

namespace Avf.LamaAssistant.AvaloniaApp;

public partial class MainWindow : ReactiveWindow<MainViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        // Create and set ViewModel
        ViewModel = new MainViewModel();

        DataContext = ViewModel;

        // Set up bindings
        this.WhenActivated(disposables =>
        {
            // Bind ViewModel.Name <-> TextBox.Text
            //this.Bind(ViewModel, vm => vm.Description, v => v.NameTextBox.Text)
              //  .DisposeWith(disposables);

            // Bind command
            //this.BindCommand(ViewModel, vm => vm.SayHelloCommand, v => v.HelloButton)
                //.DisposeWith(disposables);
        });
    }

    private void SendButton_Click(object sender, RoutedEventArgs e)
    {
        // Add your button click event logic here
        // var box = MessageBoxManager
        //     .GetMessageBoxStandard("Caption", "Are you sure you would like to delete appender_replace_page_1?",
        //         ButtonEnum.YesNo);

        // var result = box.ShowAsync(); //Todo async!!!
        var box2 = MessageBoxManager
            .GetMessageBoxStandard("Caption", "Test",
                ButtonEnum.YesNo);

        var result2 = box2.ShowAsync(); //Todo async!!!
    }
}