using System.Net;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace NumberNinjaCSharp;

public partial class MainWindow : Window
{
    private GameController _gameController = new();
    public MainWindow()
    {
        InitializeComponent();
        _gameController.SetDifficulty(Difficulty.VeryEasy);
        _gameController.StartGame();
        QuestionTextBox.Text = _gameController.GenerateQuestion().Equation;
        AnswerA.Content = _gameController.GenerateQuestion().Answers[0];
        AnswerB.Content = _gameController.GenerateQuestion().Answers[1];
        AnswerC.Content = _gameController.GenerateQuestion().Answers[2];
        AnswerD.Content = _gameController.GenerateQuestion().Answers[3];

    }
    private void AnswerA_Click(object? sender, RoutedEventArgs e)
    {
        
    }
    private void AnswerB_Click(object? sender, RoutedEventArgs e)
    {
        
    }
    private void AnswerC_Click(object? sender, RoutedEventArgs e)
    {
        
    }
    private void AnswerD_Click(object? sender, RoutedEventArgs e)
    {
        
    }
}