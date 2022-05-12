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

        #region ------------GETs------------
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

        public IAsyncEnumerable<Question> GetQuestionById(int id) //Get by text
        {
            return (IAsyncEnumerable<Question>)_contextDb.Questions.Where(c => c.Id.Equals(id));
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
        #endregion

        #region ------------POSTs------------
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
        #endregion

        #region ------------PUTs------------
        public async Task<bool> PutAnswer(int id, string description)
        {
            try
            {
                var answer = await _contextDb.Answers.FindAsync(id);
                if (answer == null) return false;

                answer.Description = description;
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return true;
        }

        public async Task<bool> PutQuestion(int id, int answerId, int categoryId, string description)
        {
            try
            {
                var question = await _contextDb.Questions.FindAsync(id);
                if (question == null) return false;

                question.Description = description;
                question.AnswerId = answerId;
                question.CategoryId = categoryId;
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return true;
        }

        public async Task<bool> PutCategory(int id, string description)
        {
            try
            {
                var category = await _contextDb.Categories.FindAsync(id);
                if (category == null) return false;

                category.Description = description;
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return true;
        }
        #endregion

        #region ------------DELETEs------------
        //Categories and Answers deletion don't delete the associated Questions, but a check must be made so that users don't leave a Question without Category or Answers. A check on both frontend and backend.
        public async Task<bool> DeleteAnswer(int id)
        {
            try
            {
                var answer = await _contextDb.Answers.SingleAsync(x => x.Id == id);
                if (answer == null) return false;

                _contextDb.Answers.Remove(answer);
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return true;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                var category = await _contextDb.Categories.SingleAsync(x => x.Id == id);
                if (category == null) return false;

                _contextDb.Categories.Remove(category);
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return true;
        }

        public async Task<bool> DeleteQuestion(int id)
        {
            try
            {
                var question = await _contextDb.Questions.SingleAsync(x => x.Id == id);
                if (question == null) return false;

                _contextDb.Questions.Remove(question);
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return true;
        }

        #endregion
    }
}
