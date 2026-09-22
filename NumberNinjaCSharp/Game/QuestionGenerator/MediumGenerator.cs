using System;

public class MediumGenerator
{
    private readonly Random _random = new();

    public Question GenerateQuestion()
    {
        string operation = _random.GetString("+-*", 1);
        string equation;

        int a = _random.Next(1, 41);
        int b = _random.Next(1, 41);

        int aMult = _random.Next(0,11);
        int bMult = _random.Next(0,11);


        int result;
        int[] answers = new int[4];

        switch (operation)
        {
            case "+":
                result = a + b;
                break;
            case "-":
                if (a < b)
                {
                    b = _random.Next(1, a + 1);
                }
                result = a - b;
                break;
            case "*":
                result = aMult * bMult;
                break;
            default:
                throw new InvalidOperationException("Unsupported operation, sry m8");
        }

        answers[0] = result;

        int index = 1;

        while (index < 4)
        {
            int fake = result + _random.Next(-10, 11);
            bool isDuplicate = false;

            for (int i = 0; i < index; i++)
            {
                if (fake == answers[i])
                {
                    isDuplicate = true;
                    break;
                }
            }

            if (fake >= 0 && !isDuplicate)
            {
                answers[index] = fake;
                index++;
            }
        }

        if (operation == "*")
        {
            equation = $"{aMult}{operation}{bMult}= ";
        }
        else
        {
            equation = $"{a}{operation}{b}= ";
        }

        _random.Shuffle(answers);

        return new Question(equation, answers, result);
    }

}
