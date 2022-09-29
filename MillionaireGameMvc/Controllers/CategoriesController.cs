using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryModels;
using MillionaireGameMvc.Services;

namespace MillionaireGameMvc.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly HttpClientService _httpClient;

        public CategoriesController(HttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _httpClient.GetCategories());
        }
        
        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _httpClient.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            /*Reason to do the Cast and array:
             * JsonSerializationException: Cannot deserialize the current JSON object (e.g. {"name":"value"}) into type 'System.Collections.Generic.List`1[LibraryModels.Category]'
             * because the type requires a JSON array (e.g. [1,2,3]) to deserialize correctly. To fix this error either change the JSON to a JSON array (e.g. [1,2,3]) or change the
             * deserialized type so that it is a normal .NET type (e.g. not a primitive type like integer, not a collection type like an array or List<T>) that can be deserialized
             * from a JSON object. JsonObjectAttribute can also be added to the type to force it to deserialize from a JSON object.*/
            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                await _httpClient.CreateCategory(category.Id, category.Description);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _httpClient.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _httpClient.UpdateCategory(category.Id, category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_httpClient.GetCategoryById(category.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _httpClient.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _httpClient.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }

        /*private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }*/
    }
}
