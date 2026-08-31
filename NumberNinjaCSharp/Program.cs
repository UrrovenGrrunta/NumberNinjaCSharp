using Avalonia;
using System;
using System.Collections.Generic;

namespace NumberNinjaCSharp;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        var veryEasy = new VeryEasyGenerator();
        var q = veryEasy.GenerateQuestion();

        Console.WriteLine($"Equation: {q.Equation}");
        Console.WriteLine($"Correct answer: {q.CorrectAnswer}");

        foreach (var answer in q.Answers)
        {
            Console.WriteLine($"Answer: {answer}");
        }















        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }


    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
#if DEBUG
            .WithDeveloperTools()
#endif
            .WithInterFont()
            .LogToTrace();
}
