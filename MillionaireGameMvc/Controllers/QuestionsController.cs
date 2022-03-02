using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MillionaireGameMvc.Controllers
{
    public class QuestionsController : Controller
    {
        public IActionResult Index() //API connection will be done in the View so the processing happens in client side and not in our server
        {
            return View();
        }
    }
}
