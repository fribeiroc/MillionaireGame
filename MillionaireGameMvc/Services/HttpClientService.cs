using LibraryModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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

        public async Task<Category> GetCategoryById(int? id)
        {
            var response = await client.GetAsync("/Categories/GetById/" + id);
            var data = await response.Content.ReadAsStringAsync();
            var category = JsonConvert.DeserializeObject<Category>(data);

            return category;
        }

        public async Task<List<Product>> GetProducts()
        {
            var response = await client.GetAsync("/api/Products");
            var data = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<Product>>(data);

            return products;
        }

        public async Task<Product> GetProductById(int? id)
        {
            var response = await client.GetAsync("/Products/GetById/" + id);
            var data = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<Product>(data);

            return products;
        }

        public async Task<List<CartLine>> GetCartLines()
        {
            var response = await client.GetAsync("/api/CartLines");
            var data = await response.Content.ReadAsStringAsync();
            var cartLines = JsonConvert.DeserializeObject<List<CartLine>>(data);

            return cartLines;
        }

        public async Task<CartLine> GetCartLineById(int? id)
        {
            var response = await client.GetAsync("/CartLines/GetById/" + id);
            var data = await response.Content.ReadAsStringAsync();
            var cartLines = JsonConvert.DeserializeObject<CartLine>(data);

            return cartLines;
        }

        public async Task<List<CartLine>> GetCartLinesByText(string text)
        {
            var response = await client.GetAsync("/CartLines/GetCartLinesByProductText/" + text);
            var data = await response.Content.ReadAsStringAsync();
            var cartLines = JsonConvert.DeserializeObject<List<CartLine>>(data);

            return cartLines;
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
            var response = await client.PutAsync("/api/Answers/" + id + "?id=" + id + "&description=" + description, null);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateCategory(int id, Category category)
        {
            var response = await client.PutAsJsonAsync("/api/Categories/" + id, category);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateProduct(int id, Product product)
        {
            var response = await client.PutAsJsonAsync("/api/Products/" + id, product);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateCartLine(int id, CartLine cartLine)
        {
            var response = await client.PutAsJsonAsync("/api/CartLines/" + id, cartLine);
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

        public async Task<bool> CreateCategory(int id, string description)
        {
            var response = await client.PostAsync("/api/Categories?" + "Id=" + id + "&Description=" + description, null);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreateProduct(int id, string name, string description, int categoryId, decimal price=0, int stock=0)
        {
            if (price < 0 || stock <= -1) return false;

            //Products?Name=Lol&Description=lol&Price=88&Stock=23&CategoryId=8
            var response = await client.PostAsync("/api/Products?" + "Id=" + id + "&Name=" + name + "&Description=" + description + "&Price=" 
                + price + "&Stock=" + stock + "&CategoryId=" + categoryId, null);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreateCartLine(int id, int quantity, int? productId, int? buyingCartId)
        {
            var response = await client.PostAsync("/api/CartLines?" + "Id=" + id + "&Quantity=" + quantity + "&ProductId=" + productId
                + "&BuyingCartId=" + buyingCartId, null);
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

        public async Task<bool> DeleteCategory(int id)
        {
            var response = await client.DeleteAsync("/api/Categories/" + id);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var response = await client.DeleteAsync("/api/Products/" + id);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCartLine(int id)
        {
            var response = await client.DeleteAsync("/api/CartLines/" + id);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
