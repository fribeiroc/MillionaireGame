using LibraryContext;
using LibraryModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServices
{
    public class DataRepository
    {
        private ContextDb _contextDb;

        public DataRepository(ContextDb dbInstance)
        {
            _contextDb = dbInstance;
        }
        //--------GETs----------
        public Answer[] GetAnswers()
        {
            return _contextDb.Answers.ToArray();
        }

        public Question[] GetQuestions()
        {
            return _contextDb.Questions.ToArray();
        }

        //--------POSTs---------
        public async Task<Answer> PostAnswer(Answer newAnswer)
        {
            try
            {
                await _contextDb.AddAsync(newAnswer);
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            
            return newAnswer;
        }

        public async Task<Question> PostQuestion(Question newQuestion)
        {
            try
            {
                await _contextDb.AddAsync(newQuestion);
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            return newQuestion;
        }
    }
}
