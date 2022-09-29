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
    public class CartLinesController : Controller
    {
        private readonly HttpClientService _httpClient;

        public CartLinesController(HttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: CartLines
        public async Task<IActionResult> Index()
        {
            return View(await _httpClient.GetCartLines());
        }

        // GET: CartLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartLine = await _httpClient.GetCartLineById(id);
            if (cartLine == null)
            {
                return NotFound();
            }
            /*Reason to do the Cast and array:
             * JsonSerializationException: Cannot deserialize the current JSON object (e.g. {"name":"value"}) into type 'System.Collections.Generic.List`1[LibraryModels.Category]'
             * because the type requires a JSON array (e.g. [1,2,3]) to deserialize correctly. To fix this error either change the JSON to a JSON array (e.g. [1,2,3]) or change the
             * deserialized type so that it is a normal .NET type (e.g. not a primitive type like integer, not a collection type like an array or List<T>) that can be deserialized
             * from a JSON object. JsonObjectAttribute can also be added to the type to force it to deserialize from a JSON object.*/
            return View(cartLine);
        }

        // GET: CartLines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CartLines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantity,ProductId,BuyingCartId")] CartLine cartLine)
        {
            if (ModelState.IsValid)
            {
                await _httpClient.CreateCartLine(cartLine.Id, cartLine.Quantity, cartLine.ProductId, cartLine.BuyingCartId);
                return RedirectToAction(nameof(Index));
            }
            return View(cartLine);
        }

        // GET: CartLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartLine = await _httpClient.GetCartLineById(id);
            if (cartLine == null)
            {
                return NotFound();
            }

            return View(cartLine);
        }

        // POST: CartLines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,ProductId,BuyingCartId")] CartLine cartLine)
        {
            if (id != cartLine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _httpClient.UpdateCartLine(cartLine.Id, cartLine);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_httpClient.GetCartLineById(cartLine.Id) == null)
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
            return View(cartLine);
        }

        // GET: CartLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartLine = await _httpClient.GetCartLineById(id);
            if (cartLine == null)
            {
                return NotFound();
            }

            return View(cartLine);
        }

        // POST: CartLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _httpClient.DeleteCartLine(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
