using LibraryModels;
using LibraryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MillionaireGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private DataRepository _dataRepository;

        public CategoriesController(DataRepository dbRepository)
        {
            _dataRepository = dbRepository;
        }

        // GET: api/<QuestionsController>
        [HttpGet]
        public IAsyncEnumerable<Category> Get()
        {
            return _dataRepository.GetCategories();
        }

        // GET: api/<QuestionsController>{text}
        [HttpGet]
        [Route("/[controller]/[action]/{text}")]
        public IAsyncEnumerable<Category> GetByText(string text)
        {
            return _dataRepository.GetCategoriesByText(text);
        }

        // POST api/<QuestionsController>
        [HttpPost]
        public async Task<Category> Post([FromBody] Category newCategory)
        {
            return await _dataRepository.PostCategory(newCategory);
        }
    }
}
