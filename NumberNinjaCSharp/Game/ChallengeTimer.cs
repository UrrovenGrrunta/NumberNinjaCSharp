using System;

public class ChallengeTimer
{
    private const int StartTime = 300;
    public int TimeRemaining {get; private set;} = StartTime;

    public int Penalize()
    {
        if (TimeRemaining > 10)
        {
            TimeRemaining -= 10;
        }
        else
        {
            TimeRemaining = 0;
        }
        return TimeRemaining;
    }
    public int Tick()
    {
        if (TimeRemaining > 0)
        {
            TimeRemaining--;
        }
        return TimeRemaining;
    }
    public int Reset()
    {
        TimeRemaining = StartTime;
        return TimeRemaining; 
    }
}