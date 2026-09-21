using System;
using System.Runtime.Serialization;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;
using Avalonia.Controls.Converters;

public static class Tests
{
    public static void Run()
    {
        var veryEasy = new VeryEasyGenerator();
        var easy = new EasyGenerator();
        int errors = 0;
        Console.WriteLine("=== Very easy ===");
        for (int i =0; i<1000; i++)
        {
            if (!ValidateQuestion(veryEasy.GenerateQuestion()))
            {
                errors++;
            }
        }
        Console.WriteLine("=== Easy ===");
        for (int i =0; i<1000; i++)
        {
            if (!ValidateQuestion(easy.GenerateQuestion()))
            {
                errors++;
            }
        }
        Console.WriteLine($"Tests finished. Errors found: {errors}");

    }

    private static bool ValidateQuestion(Question q)
    {
        bool isValid = true;
        int errors = 0;
        int dublicateCount = 0;

        if (q.CorrectAnswer < 0)
        {
            errors++;
            Console.WriteLine("ERROR: negative correct answer");
            Console.WriteLine(q.Equation);
            Console.WriteLine(string.Join(", ", q.Answers));
            Console.WriteLine($"Correct: {q.CorrectAnswer}");
            Console.WriteLine();
        }
        if (q.Answers.GetLength(0) != 4)
        {
            errors++;
            Console.WriteLine("ERROR: length of answer list is not 4");
            Console.WriteLine(q.Answers);
            Console.WriteLine(string.Join(", ", q.Answers));
            Console.WriteLine($"Correct: {q.CorrectAnswer}");
            Console.WriteLine();
        }
        if (!q.Answers.Contains(q.CorrectAnswer))
        {
            errors++;
            Console.WriteLine("ERROR: correct answer missing");
            Console.WriteLine(q.Equation);
            Console.WriteLine(string.Join(", ", q.Answers));
            Console.WriteLine($"Correct: {q.CorrectAnswer}");
            Console.WriteLine();
        }
        for (int i = 0; i < q.Answers.GetLength(0); i++)
        {
            if (q.Answers[i] < 0)
            {
                errors++;
                Console.WriteLine("ERROR: answers in answer list must be non negative");
                Console.WriteLine(q.Answers);
                Console.WriteLine(string.Join(", ", q.Answers));
                Console.WriteLine($"Correct: {q.CorrectAnswer}");
                Console.WriteLine();
            }
            for (int j = i + 1; j < q.Answers.GetLength(0); j++)
            {
                if (q.Answers[i] == q.Answers[j])
                {
                    errors++;
                    dublicateCount++;
                    Console.WriteLine("ERROR: dublicateFound");
                    Console.WriteLine(q.Answers);
                    Console.WriteLine(string.Join(", ", q.Answers));
                    Console.WriteLine($"Correct: {q.CorrectAnswer}");
                    Console.WriteLine();
                }
            }
        }
        if (q.Equation == "")
        {
            errors++;
            Console.WriteLine(q.Equation);
            Console.WriteLine(string.Join(", ", q.Answers));
            Console.WriteLine($"Correct: {q.CorrectAnswer}");
            Console.WriteLine();
        }

        if (errors > 0)
        {
            Console.WriteLine($"Found {dublicateCount}, dublicates.");
            isValid = false;
        }
        return isValid;
    }
}