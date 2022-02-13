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

        // POST api/<AnswersController>
        [HttpPost]
        public async Task<Answer> Post([FromBody]Answer newAnswer)
        {
            return await _dataRepository.PostAnswer(newAnswer);
        }
    }
}
