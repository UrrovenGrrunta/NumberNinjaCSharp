public class Question(
    string equation, 
    int[] answers, 
    int correctAnswer)
{
    public string Equation { get; } = equation;
    public int[] Answers { get; } = answers;
    public int CorrectAnswer { get; } = correctAnswer;
}