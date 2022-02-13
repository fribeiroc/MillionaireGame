using LibraryModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MillionaireGame.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Game()
        {
            //Connecting to /api/Questions and getting the data
            //Probably better to change this api connection and data gathering to the frontend (Js)
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:44342");
            //var response = await client.GetAsync("/api/Questions");
            //var data = await response.Content.ReadAsStringAsync();
            //var questions = JsonConvert.DeserializeObject<List<Question>>(data);
            //return View(questions);
            return View();
        }
    }
}
