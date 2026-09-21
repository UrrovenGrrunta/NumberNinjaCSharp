using System;


public class EasyGenerator
{
    private readonly Random _random = new();

    public Question GenerateQuestion()
    {
        var (equation, result) = GenerateEquation();
        int[] answers = new int[4];
        while (result < 0)
        {
            (equation, result) = GenerateEquation();
        }
        int index = 1;
        answers[0] = result;

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
        _random.Shuffle(answers);
        return new Question(equation, answers, result);
    }
    private (string equation, int result) GenerateEquation()
    {
        string equation = "";
        int innerResult = 0;
        int result = 0;
        
        int a = _random.Next(1, 41),
            b = _random.Next(1, 41),
            c = _random.Next(1, 41);

        int questionForm = Convert.ToInt16(_random.GetString("01", 1));
        // Form 0 --  a ± (b ± c)
        // Form 1 -- (a ± b) ± c
        char optionOne = Convert.ToChar(_random.GetString("+-", 1));
        char optionTwo = Convert.ToChar(_random.GetString("+-", 1));
        if (questionForm == 1)
        {
            innerResult = optionOne switch
            {
                '+' => a + b,
                '-' => a - b,
                _ => 0
            };
            result = optionTwo switch
            {
                '+' => innerResult + c,
                '-' => innerResult - c,
                _ => 0
            };
            equation = $"({a}{optionOne}{b}){optionTwo}{c}= ";
        }
        if (questionForm == 0)
        {
            innerResult = optionTwo switch
            {
                '+' => b + c,
                '-' => b - c,
                _ => 0
            };
            result = optionOne switch
            {
                '+' => a + innerResult,
                '-' => a - innerResult,
                _ =>  0
            };
            equation = $"{a}{optionOne}({b}{optionTwo}{c})= ";
        }
        return (equation, result);
    }
}
