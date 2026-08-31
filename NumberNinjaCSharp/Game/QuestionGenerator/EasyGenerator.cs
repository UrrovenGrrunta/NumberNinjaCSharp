using System;
using System.Runtime.CompilerServices;

public class EasyGenerator
{
    private readonly Random _random = new();

    public Question GenerateQuestion()
    {
        string equation = "";
        int[] answers = new int[4];
        int correctAnswer = 0;
        int innerResult = 0;
        
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
            correctAnswer = optionTwo switch
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
            correctAnswer = optionOne switch
            {
                '+' => a + innerResult,
                '-' => a - innerResult,
                _ =>  0
            };
            equation = $"{a}{optionOne}({b}{optionTwo}{c})= ";
        }
        return new Question(equation, answers, correctAnswer);
    }
}

// 

/*
By some miracle this code needs to be ressolved using C#

class AdditionSubtractionWithBrackets: ## Easy diff
    def __init__(self):
        pass

    def generateQuestion(self):
        # Generate three numbers in range 1-40
        a, b, c = [rint(1, 40) for _ in range(3)]

        form = rchoice([0, 1])


        if form == 0:
            # a ± (b ± c)
            op1 = rchoice(["+", "-"])
            op2 = rchoice(["+", "-"])
            equation = f"{a}{op1}({b}{op2}{c})"
            result = eval(equation)
        else:
            # (a ± b) ± c
            op1 = rchoice(["+", "-"])
            op2 = rchoice(["+", "-"])
            equation = f"({a}{op1}{b}){op2}{c}"
            result = eval(equation)


        # Ensure non-negative result
        if result < 0:
            return self.generateQuestion()


        # Generate answers set including the correct one
        answers = {result}
        while len(answers) < 4:
            fake = result + rint(-10, 10)
            if fake >= 0:
                answers.add(fake)
        answer_list = list(answers)
        rshuffle(answer_list)

        return f"{equation} = ", answer_list, result

*/