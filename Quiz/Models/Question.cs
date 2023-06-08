namespace Quiz.Models;

public class Question
{
	public Guid Id { get; set; }
	public string QuizQuestion { get; set; }
	public string CorrectAnswer { get; set; }

	public string IncorrectAnswer1 { get; set; }
	public string IncorrectAnswer2 { get; set; }
	public string IncorrectAnswer3 { get; set; }
	public string IncorrectAnswer4 { get; set; }

	public bool Correct { get; set; }
	public int NumberOfCorrectAnswer { get; set; }
}