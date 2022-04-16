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
    public class QuestionsController : ControllerBase
    {
        private DataRepository _dataRepository;

        public QuestionsController(DataRepository dbRepository)
        {
            _dataRepository = dbRepository;
        }

        // GET: api/<QuestionsController>
        [HttpGet]
        public IAsyncEnumerable<Question> Get()
        {
            return _dataRepository.GetQuestions();
        }

        // GET: api/<QuestionsController>{text}
        [HttpGet]
        [Route("/[controller]/[action]/{text}")]
        public IAsyncEnumerable<Question> GetByText(string text)
        {
            return _dataRepository.GetQuestionsByText(text);
        }

        // POST api/<QuestionsController>
        [HttpPost]
        public async Task<Question> Post([FromBody]Question newQuestion)
        {
            return await _dataRepository.PostQuestion(newQuestion);
        }

        // PUT api/<QuestionsController>{id}
        [HttpPut("{id}")]
        public async Task<bool> Put([FromQuery] int id, int answerId, int categoryId, string description)
        {
            return await _dataRepository.PutQuestion(id, answerId, categoryId, description);
        }

        // DELETE api/<QuestionsController>{id}
        [HttpDelete("{id}")]
        public async Task<bool> Delete([FromQuery] int id)
        {
            return await _dataRepository.DeleteQuestion(id);
        }
    }
}
