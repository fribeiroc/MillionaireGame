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

        // GET: api/<CategoriesController>
        [HttpGet]
        public IAsyncEnumerable<Category> Get()
        {
            return _dataRepository.GetCategories();
        }

        // GET: api/<CategoriesController>{text}
        [HttpGet]
        [Route("/[controller]/[action]/{text}")]
        public IAsyncEnumerable<Category> GetByText(string text)
        {
            return _dataRepository.GetCategoriesByText(text);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<Category> Post([FromBody] Category newCategory)
        {
            return await _dataRepository.PostCategory(newCategory);
        }

        // PUT api/<CategoriesController>{id}
        [HttpPut("{id}")]
        public async Task<bool> Put([FromQuery] int id, string description)
        {
            return await _dataRepository.PutCategory(id, description);
        }

        // DELETE api/<CategoriesController>{id}
        [HttpDelete("{id}")]
        public async Task<bool> Delete([FromQuery] int id)
        {
            return await _dataRepository.DeleteCategory(id);
        }
    }
}
