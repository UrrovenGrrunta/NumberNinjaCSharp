using System;

public class GameController
{
    private Difficulty _currentDifficulty;
    private GameState _currentState = GameState.Menu;

    public Difficulty GetDifficulty()
    {
        return _currentDifficulty;
    }

    public void SetDifficulty(Difficulty difficulty)
    {
        _currentDifficulty = difficulty;
    }
    public GameState GetGameState()
    {
        return _currentState;
    }
    public GameState StartGame()
    {
        _currentState = GameState.Playing;
        return _currentState;
    }
    public GameState EndGame()
    {
        _currentState = GameState.GameOver;
        return _currentState;
    }
}   