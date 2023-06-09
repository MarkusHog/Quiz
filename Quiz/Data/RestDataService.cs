using Quiz.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;

namespace Quiz.Data;

public class RestDataService : IRestDataService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseAdress;
    private readonly string _url;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    public RestDataService()
    {
        _httpClient = new HttpClient();
        _baseAdress = "https://markusquiz--bsvbg18.gentlebush-8ad4885e.westeurope.azurecontainerapps.io";
        _url = $"{_baseAdress}/questions";

        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }
    public async Task<List<Question>> GetAllQuestionAsync()
    {
        List<Question> questions = new();

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                questions = JsonSerializer.Deserialize<List<Question>>(content, _jsonSerializerOptions);
            }
            else
            {
                Debug.WriteLine("Non http 2xx response");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return questions;
    }
}