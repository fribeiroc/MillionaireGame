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

        // GET: api/<CategoriesController>{id}
        [HttpGet]
        [Route("/[controller]/[action]/{id}")]
        public Task<Category> GetById(int id)
        {
            return _dataRepository.GetCategoryById(id);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<Category> Post([FromQuery] Category newCategory)
        {
            return await _dataRepository.PostCategory(newCategory);
        }

        // PUT api/<CategoriesController>{id}
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] Category category)
        {
            return await _dataRepository.PutCategory(id, category);
        }

        // DELETE api/<CategoriesController>{id}
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _dataRepository.DeleteCategory(id);
        }
    }
}
