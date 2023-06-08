using Quiz.Models;

namespace Quiz.Data;

public interface IRestDataService
{
    Task<List<Question>> GetAllQuestionAsync();
}