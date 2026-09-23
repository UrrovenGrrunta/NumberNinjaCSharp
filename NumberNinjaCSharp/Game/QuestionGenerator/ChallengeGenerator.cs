using System;

public class ChallengeGenerator
{
    private readonly Random _random = new();
    
    public Question GenerateQuestion()
    {
        var veryEasy = new VeryEasyGenerator();
        var easy = new EasyGenerator();
        var normal = new NormalGenerator();
        var hard = new HardGenerator();


        int mode = _random.Next(0,4);

        switch (mode)
        {
            case 0:
                return veryEasy.GenerateQuestion();
                
            case 1:
                return easy.GenerateQuestion();
                
            case 2:
                return normal.GenerateQuestion();
                
            case 3:
                return hard.GenerateQuestion();
                
            default:
                throw new InvalidOperationException("Invalid challenge mode");
            }

    } 
}