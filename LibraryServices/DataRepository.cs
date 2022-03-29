using LibraryContext;
using LibraryModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryServices
{
    /*
     * To add:
     * - Deletion of specific Question and Answers (linked)
     * - Get Questions of X category
     */
    public class DataRepository
    {
        private ContextDb _contextDb;

        public DataRepository(ContextDb dbInstance)
        {
            _contextDb = dbInstance;
        }

        //--------GETs Answers----------
        public IAsyncEnumerable<Answer> GetAnswers()
        {
            return _contextDb.Answers.AsAsyncEnumerable();
        }
        public IAsyncEnumerable<Answer> GetAnswersByText(string text) //Get by text
        {
            return (IAsyncEnumerable<Answer>)_contextDb.Answers.Where(c => c.Description.Contains(text));
        }
        public IAsyncEnumerable<Answer> GetAnswerById(int id) //Get by Id
        {
            return (IAsyncEnumerable<Answer>)_contextDb.Answers.Where(c => c.Id.Equals(id));
        }

        //--------GETs Questions----------
        public IAsyncEnumerable<Question> GetQuestions()
        {
            return _contextDb.Questions.AsAsyncEnumerable();
        }
        public IAsyncEnumerable<Question> GetQuestionsByText(string text) //Get by text
        {
            return (IAsyncEnumerable<Question>)_contextDb.Questions.Where(c => c.Description.Contains(text));
        }

        //--------GETs Categories----------
        public IAsyncEnumerable<Category> GetCategories()
        {
            return _contextDb.Categories.AsAsyncEnumerable();
        }
        public IAsyncEnumerable<Category> GetCategoriesByText(string text) //Get by text
        {
            return (IAsyncEnumerable<Category>)_contextDb.Categories.Where(c => c.Description.Contains(text));
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

        public async Task<Category> PostCategory(Category newCategory)
        {
            try
            {
                await _contextDb.AddAsync(newCategory);
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return newCategory;
        }
    }
}
