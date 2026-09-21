using System;

public class GameController
{
    private Difficulty _currentDifficulty;

    public Difficulty GetDifficulty()
    {
        return _currentDifficulty;
    }

    public void SetDifficulty(Difficulty difficulty)
    {
        _currentDifficulty = difficulty;
    }
}