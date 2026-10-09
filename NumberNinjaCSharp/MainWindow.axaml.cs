using Avalonia.Controls;
using NumberNinjaCSharp.Views;

namespace NumberNinjaCSharp;

public partial class MainWindow : Window
{  
    public MainWindow()
    {
        InitializeComponent();
        ShowScreen(new GameView());

    }
    private void ShowScreen(UserControl userControl)
    {
        ScreenHost.Content = userControl;
    }
   
}
