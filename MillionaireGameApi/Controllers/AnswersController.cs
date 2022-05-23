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
    public class AnswersController : ControllerBase
    {
        private DataRepository _dataRepository;

        public AnswersController(DataRepository dbRepository)
        {
            _dataRepository = dbRepository;
        }

        // GET: api/<AnswersController>
        [HttpGet]
        public IAsyncEnumerable<Answer> Get()
        {
            return _dataRepository.GetAnswers();
        }

        // GET: api/<AnswersController>{text}
        [HttpGet]
        [Route("/[controller]/[action]/{text}")]
        public IAsyncEnumerable<Answer> GetByText(string text)
        {
            return _dataRepository.GetAnswersByText(text);
        }

        // GET: api/<AnswersController>{id}
        [HttpGet]
        [Route("/[controller]/[action]/{id}")]
        public IAsyncEnumerable<Answer> GetById(int id)
        {
            return _dataRepository.GetAnswerById(id);
        }

        // POST api/<AnswersController>
        [HttpPost]
        public async Task<Answer> Post([FromQuery]Answer newAnswer)
        {
            return await _dataRepository.PostAnswer(newAnswer);
        }

        // PUT api/<AnswersController>{id}
        [HttpPut("{id}")]
        public async Task<bool> Put([FromQuery]int id, string description)
        {
            return await _dataRepository.PutAnswer(id, description);
        }

        // DELETE api/<AnswersController>{id}
        [HttpDelete("{id}")]
        public async Task<bool> Delete([FromQuery] int id)
        {
            return await _dataRepository.DeleteAnswer(id);
        }
    }
}
