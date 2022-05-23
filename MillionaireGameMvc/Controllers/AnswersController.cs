using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryModels;
using MillionaireGameMvc.Services;
using Newtonsoft.Json;

namespace MillionaireGameMvc.Controllers
{
    public class AnswersController : Controller
    {
        private readonly HttpClientService _httpClient;

        public AnswersController(HttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Answers
        public async Task<IActionResult> Index()
        {
            return View(await _httpClient.GetAnswers());
        }
        
        // GET: Answers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _httpClient.GetAnswersById(id);
            if (answer == null)
            {
                return NotFound();
            }
            var converted = answer.Cast<Answer>().ToArray();

            return View(converted[0]);
        }
        // GET: Answers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                await _httpClient.CreateAnswer(answer.Id, answer.Description);
            }
            return View(answer);
        }

        // GET: Answers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _httpClient.GetAnswersById(id);
            if (answer == null)
            {
                return NotFound();
            }
            var converted = answer.Cast<Answer>().ToArray();
            return View(converted[0]);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] Answer answer)
        {
            if (id != answer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _httpClient.UpdateAnswer(answer.Id, answer.Description);
                    //await _httpClient.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_httpClient.GetAnswersById(answer.Id) == null)
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
            return View(answer);
        }

        // GET: Answers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var answer = await _context.Answer.FindAsync(id);
            _context.Answer.Remove(answer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnswerExists(int id)
        {
            return _context.Answer.Any(e => e.Id == id);
        }
    }
}
