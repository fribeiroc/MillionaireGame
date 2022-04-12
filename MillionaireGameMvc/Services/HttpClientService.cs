using LibraryModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MillionaireGameMvc.Services
{
    public class HttpClientService
    {
        public HttpClient client = new HttpClient();

        public HttpClientService()
        {
            client.BaseAddress = new Uri("https://localhost:44387");
        }

        public async Task<List<Answer>> GetAnswers()
        {
            var response = await client.GetAsync("/api/Answers");
            var data = await response.Content.ReadAsStringAsync();
            var answers = JsonConvert.DeserializeObject<List<Answer>>(data);

            return answers;
        }

        public async Task<List<Answer>> GetAnswersById(int? id)
        {
            var response = await client.GetAsync("/Answers/GetById/" + id);
            var data = await response.Content.ReadAsStringAsync();
            var answer = JsonConvert.DeserializeObject<List<Answer>>(data);

            return answer;
        }

        public async Task<List<Category>> GetCategories()
        {
            var response = await client.GetAsync("/api/Categories");
            var data = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<Category>>(data);

            return categories;
        }

        public async Task<List<Question>> GetQuestions()
        {
            var response = await client.GetAsync("/api/Questions");
            var data = await response.Content.ReadAsStringAsync();
            var questions = JsonConvert.DeserializeObject<List<Question>>(data);

            return questions;
        }
    }
}
