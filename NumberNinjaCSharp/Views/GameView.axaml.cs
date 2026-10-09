using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace NumberNinjaCSharp.Views;

public partial class GameView : UserControl
{
    private GameController _gameController = new();
    private bool _isCorrect;

    public GameView()
    {
        InitializeComponent();
        _gameController.StartGame();
        UpdateQuestion();
    }
    private void UpdateQuestion()
    {
        Question? question = _gameController.GetQuestion();
        if (question == null)
        {
            throw new InvalidOperationException();
        }
        QuestionTextBox.Text = question.Equation;
        AnswerA.Content = question.Answers[0];
        AnswerB.Content = question.Answers[1];
        AnswerC.Content = question.Answers[2];
        AnswerD.Content = question.Answers[3];
    }
    private void AnswerA_Click(object? sender, RoutedEventArgs e)
    {
        Question? question = _gameController.GetQuestion();
        int answerA = Convert.ToInt16(AnswerA.Content);
        _isCorrect = _gameController.SubmitAnswer(answerA);
        if (_isCorrect)
        {
            Result.Text = "Correct!!!!!!!";
        }
        else
        {
            Result.Text = "Incorrect :(";
        }
        UpdateQuestion();
    }
    private void AnswerB_Click(object? sender, RoutedEventArgs e)
    {
        Question? question = _gameController.GetQuestion();
        int answerB = Convert.ToInt16(AnswerB.Content);
        _isCorrect = _gameController.SubmitAnswer(answerB);
        if (_isCorrect)
        {
            Result.Text = "Correct!!!!!!!";
        }
        else
        {
            Result.Text = "Incorrect :(";
        }
        UpdateQuestion();
    }
    private void AnswerC_Click(object? sender, RoutedEventArgs e)
    {
        Question? question = _gameController.GetQuestion();
        int answerC = Convert.ToInt16(AnswerC.Content);
        _isCorrect = _gameController.SubmitAnswer(answerC);
        if (_isCorrect)
        {
            Result.Text = "Correct!!!!!!!";
        }
        else
        {
            Result.Text = "Incorrect :(";
        }
        UpdateQuestion();
    }
    private void AnswerD_Click(object? sender, RoutedEventArgs e)
    {
        Question? question = _gameController.GetQuestion();
        int answerD = Convert.ToInt16(AnswerD.Content);
        _isCorrect = _gameController.SubmitAnswer(answerD);
        if (_isCorrect)
        {
            Result.Text = "Correct!!!!!!!";
        }
        else
        {
            Result.Text = "Incorrect :(";
        }
        UpdateQuestion();
    }
}