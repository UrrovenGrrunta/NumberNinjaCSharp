using Microsoft.VisualBasic;
using System;

public class GameController
{
    private Difficulty _currentDifficulty;
    private GameState _currentState = GameState.Menu;
    private Question? _currentQuestion;
    private bool _isAnswerCorrect;
    private int _score = 0;
    private int _streak = 1;
    private int _counter = 0;




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
    
    public GameState OpenDifficultySelection()
    {
        _currentState = GameState.DifficultySelection;
        return _currentState;
    }
    public GameState StartGame()
    {
        _currentState = GameState.Playing;
        return _currentState;
    }
    public GameState EndGame()
    {
        _currentState = GameState.DifficultySelection;
        return _currentState;
    }
    public GameState EndChallenge()
    {
        _currentState = GameState.GameOver;
        return _currentState;
    }

    public Question? GetQuestion() 
    {
        return _currentQuestion;
    }
    public Question GenerateQuestion() 
    {
        Question question;
        switch (_currentDifficulty)
        {
            case (Difficulty.VeryEasy):
                question = new VeryEasyGenerator().GenerateQuestion();
                break;
            case (Difficulty.Easy):
                question = new EasyGenerator().GenerateQuestion();
                break;
            case (Difficulty.Normal):
                question = new NormalGenerator().GenerateQuestion();
                break;
            case (Difficulty.Hard):
                question = new HardGenerator().GenerateQuestion();
                break;
            case (Difficulty.Challenge):
                question = new ChallengeGenerator().GenerateQuestion();
                break;
            default:
                throw new InvalidOperationException("Can not indentify difficulty");
        }
        _currentQuestion = question;
        return question;
    }

    public bool SubmitAnswer(int userAnswer)
    {
        _isAnswerCorrect = false;
        if (_currentQuestion == null)
        {
            throw new InvalidOperationException("_currentQuestion is null");
        }
        if (_currentQuestion.CorrectAnswer == userAnswer)
        {
            _isAnswerCorrect = true;
        }
        GenerateQuestion();
        return _isAnswerCorrect;
    }

    // Challenge-specific logic

    public int GetScore()
    {
        return _score;
    }

    public int GetStreak()
    {
        return _streak;
    }

    public int CalculateCounter()
    {
        if (_isAnswerCorrect)
        {
            _counter++;
        }
        else
        {
            _counter = 0;
        }

        return _counter;
    }

    public int CalculateStreak()
    {
        if (!_isAnswerCorrect)
        {
            _streak = 1;
        }
        else if (_counter % 5 == 0)
        {
            _streak++;
        }

        return _streak;
    }

    public int CalculateScore()
    {
        if (_isAnswerCorrect)
        {
            _score += 10 * _streak;
        }

        return _score;
    }

    public void UpdateChallengeScore()
    {
        CalculateCounter();
        CalculateStreak();
        CalculateScore();
    }

    public Tuple<int, int, int, bool> ResetChalange()
    {
        _score = 0;
        _streak = 1;
        _counter = 0;
        _isAnswerCorrect = false;
        return Tuple.Create(_score, _streak, _counter, _isAnswerCorrect);
    }
}
