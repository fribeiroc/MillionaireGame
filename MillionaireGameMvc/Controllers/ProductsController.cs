using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryModels;
using MillionaireGameMvc.Services;
using Microsoft.AspNetCore.Authorization;

namespace MillionaireGameMvc.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClientService _httpClient;

        public ProductsController(HttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Products
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _httpClient.GetProducts());
        }

        // GET: Products/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _httpClient.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            /*Reason to do the Cast and array:
             * JsonSerializationException: Cannot deserialize the current JSON object (e.g. {"name":"value"}) into type 'System.Collections.Generic.List`1[LibraryModels.Category]'
             * because the type requires a JSON array (e.g. [1,2,3]) to deserialize correctly. To fix this error either change the JSON to a JSON array (e.g. [1,2,3]) or change the
             * deserialized type so that it is a normal .NET type (e.g. not a primitive type like integer, not a collection type like an array or List<T>) that can be deserialized
             * from a JSON object. JsonObjectAttribute can also be added to the type to force it to deserialize from a JSON object.*/
            return View(product);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Stock,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _httpClient.CreateProduct(product.Id, product.Name, product.Description, product.CategoryId, 
                    product.Price, product.Stock);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _httpClient.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Stock,CategoryId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (product.Price < 0 || product.Stock <= -1)
                {
                    TempData["Error"] = "Price must be higher than 0, and Stock must be higher or equal to 0.";
                    return View(product);
                }
                    try
                {
                    await _httpClient.UpdateProduct(product.Id, product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_httpClient.GetProductById(product.Id) == null)
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
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _httpClient.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _httpClient.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
