using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace Avf.LamaAssistant.AvaloniaApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
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