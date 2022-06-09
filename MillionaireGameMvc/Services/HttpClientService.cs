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

        public async Task<List<Question>> GetQuestionsById(int? id)
        {
            var response = await client.GetAsync("/Questions/GetById/" + id);
            var data = await response.Content.ReadAsStringAsync();
            var question = JsonConvert.DeserializeObject<List<Question>>(data);

            return question;
        }

        public async Task<bool> UpdateAnswer(int id, string description)
        {
            //9?id=9&description=Ornintorrinco
            var response = await client.PutAsync("/api/Answers/" + id + "?id=" + id + "&description=" + description, null);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreateAnswer(int id, string description)
        {
            var response = await client.PostAsync("/api/Answers?" + "Id=" + id + "&Description=" + description, null);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAnswer(int id)
        {
            var response = await client.DeleteAsync("/api/Answers/" + id);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
