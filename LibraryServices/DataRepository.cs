using LibraryContext;
using LibraryModels;
using Microsoft.EntityFrameworkCore;
//using MillionaireGameMvc.Areas.Identity.Data;
//using MillionaireGameMvc.Data;
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
        private ContextDb _contextDb; //Custum database context
        //private LoginMvcContext _loginMvcContext; //Identity Core context

        public DataRepository(ContextDb dbInstance/*, LoginMvcContext loginMvcContext*/)
        {
            _contextDb = dbInstance;
            //_loginMvcContext = loginMvcContext;
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

        //--------GETs Users----------
        public IAsyncEnumerable<User> GetUsers()
        {
            return _contextDb.Users.AsAsyncEnumerable();
        }
        public IAsyncEnumerable<User> GetUsersByText(string text) //Get by text
        {
            return (IAsyncEnumerable<User>)_contextDb.Users.Where(c => c.Username.Contains(text));
        }
        public Task<User> GetUserById(int id) //Get by Id
        {
            return _contextDb.Users.SingleAsync(c => c.Id.Equals(id));
        }

        //--------GETs Identity Users--------
        /*public IAsyncEnumerable<LoginMvcUser> GetIdentityUsers()
        {
            return _loginMvcContext.Users.AsAsyncEnumerable();
        }
        public IAsyncEnumerable<LoginMvcUser> GetIdentityUsersByText(string text) //Get by text
        {
            return (IAsyncEnumerable<LoginMvcUser>)_loginMvcContext.Users.Where(c => c.Email.Contains(text));
        }
        public Task<LoginMvcUser> GetIdentityUserById(int id) //Get by Id
        {
            return _loginMvcContext.Users.SingleAsync(c => c.Id.Equals(id));
        }*/

        //--------GETs Products----------
        public IAsyncEnumerable<Product> GetProducts()
        {
            return _contextDb.Products.AsAsyncEnumerable();
        }
        public IAsyncEnumerable<Product> GetProductsByText(string text) //Get by text
        {
            return (IAsyncEnumerable<Product>)_contextDb.Products.Where(c => c.Name.Contains(text));
        }
        public Task<Product> GetProductById(int id) //Get by Id
        {
            return _contextDb.Products.SingleAsync(c => c.Id.Equals(id));
        }

        //--------GETs CartLines----------
        public IAsyncEnumerable<CartLine> GetCartLines()
        {
            return _contextDb.CartLines.Include(p => p.Product).AsAsyncEnumerable();
        }
        public IAsyncEnumerable<CartLine> GetCartLinesByBuyingCartId(int id) //Get by text
        {
            return (IAsyncEnumerable<CartLine>)_contextDb.CartLines.Where(c => c.BuyingCartId.Equals(id));
        }
        public Task<CartLine> GetCartLineById(int id) //Get by Id
        {
            return _contextDb.CartLines.SingleAsync(c => c.Id.Equals(id));
        }

        public IAsyncEnumerable<CartLine> GetCartLinesByProductText(string text) //Get by text
        {
            var query = from c in _contextDb.CartLines join pr in _contextDb.Products
                        on c.ProductId equals pr.Id where pr.Name.Contains(text) 
                        select pr.Name + pr.Price + pr.Description + c.Quantity;
            return (IAsyncEnumerable<CartLine>)query;
        }

        //--------GETs BuyingCarts----------
        public IAsyncEnumerable<BuyingCart> GetBuyingCarts()
        {
            return _contextDb.BuyingCarts.AsAsyncEnumerable();
        }
        public IAsyncEnumerable<BuyingCart> GetBuyingCartsByUserId(int id) //Get by text
        {
            return (IAsyncEnumerable<BuyingCart>)_contextDb.BuyingCarts.Where(c => c.UserId.Equals(id));
        }
        public Task<BuyingCart> GetBuyingCartById(int id) //Get by Id
        {
            return _contextDb.BuyingCarts.SingleAsync(c => c.Id.Equals(id));
        }

        //--------GETs Questions----------
        public IAsyncEnumerable<Question> GetQuestions()
        {
            return _contextDb.Questions.AsAsyncEnumerable();
        }

        public IAsyncEnumerable<Question> GetQuestionById(int id) //Get by text
        {
            return (IAsyncEnumerable<Question>)_contextDb.Questions.SingleAsync(c => c.Id.Equals(id));
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

        public Task<Category> GetCategoryById(int id) //Get by Id
        {
            return _contextDb.Categories.SingleAsync(c => c.Id.Equals(id));
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

        public async Task<Product> PostProduct(Product newProduct)
        {
            try
            {
                await _contextDb.AddAsync(newProduct);
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            return newProduct;
        }

        public async Task<User> PostUser(User newUser)
        {
            try
            {
                await _contextDb.AddAsync(newUser);
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            return newUser;
        }

        public async Task<CartLine> PostCartLine(CartLine newCartLine)
        {
            try
            {
                await _contextDb.AddAsync(newCartLine);
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            return newCartLine;
        }

        public async Task<BuyingCart> PostBuyingCart(BuyingCart newBuyingCart)
        {
            try
            {
                await _contextDb.AddAsync(newBuyingCart);
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            return newBuyingCart;
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

        public async Task<bool> PutProduct(int id, Product product)
        {
            if (product == null || id == 0 || product.Price < 0 || product.Stock <= -1) return false;

            try
            {
                _contextDb.Update(product);
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

        public async Task<bool> PutCategory(int id, Category category)
        {
            if (category == null || id == 0) return false;

            try
            {
                _contextDb.Update(category);
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return true;
        }

        public async Task<bool> PutCartLine(int id, CartLine cartLine)
        {
            if (cartLine == null || id == 0) return false;

            try
            {
                _contextDb.Update(cartLine);
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
                return false; //quero saber se o valor false/true é lido no HttpClientService MVC
            }
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var product = await _contextDb.Products.SingleAsync(x => x.Id == id);
                if (product == null) return false;

                _contextDb.Products.Remove(product);
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false; //quero saber se o valor false/true é lido no HttpClientService MVC
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

        public async Task<bool> DeleteCartLine(int id)
        {
            try
            {
                var cartLine = await _contextDb.CartLines.SingleAsync(x => x.Id == id);
                if (cartLine == null) return false;

                _contextDb.CartLines.Remove(cartLine);
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
