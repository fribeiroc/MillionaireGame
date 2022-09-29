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
    public class ProductsController : ControllerBase
    {
        private readonly DataRepository _dataRepository;

        public ProductsController(DataRepository dbRepository)
        {
            _dataRepository = dbRepository;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IAsyncEnumerable<Product> Get()
        {
            return _dataRepository.GetProducts();
        }

        // GET: api/<ProductsController>{text}
        [HttpGet]
        [Route("/[controller]/[action]/{text}")]
        public IAsyncEnumerable<Product> GetByText(string text)
        {
            return _dataRepository.GetProductsByText(text);
        }

        // GET: api/<ProductsController>{id}
        [HttpGet]
        [Route("/[controller]/[action]/{id}")]
        public Task<Product> GetById(int id)
        {
            return _dataRepository.GetProductById(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<Product> Post([FromQuery] Product newProduct)
        {
            return await _dataRepository.PostProduct(newProduct);
        }

        // PUT api/<ProductsController>{id}
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] Product product)
        {
            return await _dataRepository.PutProduct(id, product);
        }

        // DELETE api/<ProductsController>{id}
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _dataRepository.DeleteProduct(id);
        }
    }
}

