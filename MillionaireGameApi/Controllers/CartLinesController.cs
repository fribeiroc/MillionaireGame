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
    public class CartLinesController : ControllerBase
    {
        private DataRepository _dataRepository;

        public CartLinesController(DataRepository dbRepository)
        {
            _dataRepository = dbRepository;
        }

        // GET: api/<CartLinesController>
        [HttpGet]
        public IAsyncEnumerable<CartLine> Get()
        {
            return _dataRepository.GetCartLines();
        }

        // GET: api/<CartLinesController>{text}
        [HttpGet]
        [Route("/[controller]/[action]/{text}")]
        public IAsyncEnumerable<CartLine> GetCartLinesByProductText(string text)
        {
            return _dataRepository.GetCartLinesByProductText(text);
        }

        // GET: api/<CartLinesController>{id}
        [HttpGet]
        [Route("/[controller]/[action]/{id}")]
        public Task<CartLine> GetById(int id)
        {
            return _dataRepository.GetCartLineById(id);
        }

        // POST api/<CartLinesController>
        [HttpPost]
        public async Task<CartLine> Post([FromQuery] CartLine newCartLine)
        {
            return await _dataRepository.PostCartLine(newCartLine);
        }

        // PUT api/<CartLinesController>{id}
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] CartLine cartLine)
        {
            return await _dataRepository.PutCartLine(id, cartLine);
        }

        // DELETE api/<CartLinesController>{id}
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _dataRepository.DeleteCartLine(id);
        }
    }
}
