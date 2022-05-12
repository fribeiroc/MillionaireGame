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
    public class QuestionsController : Controller
    {
        private readonly HttpClientService _httpClient;

        public QuestionsController(HttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            return View(await _httpClient.GetQuestions());
        }
        
        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _httpClient.GetQuestionsById(id);
            if (answer == null)
            {
                return NotFound();
            }
            var converted = answer.Cast<Question>().ToArray();

            return View(converted[0]);
        }
        /*
        // GET: Questions/Create
        public IActionResult Create()
        {
            ViewData["AnswerId"] = new SelectList(_context.Set<Answer>(), "Id", "Id");
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,AnswerId,CategoryId")] Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnswerId"] = new SelectList(_context.Set<Answer>(), "Id", "Id", question.AnswerId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", question.CategoryId);
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["AnswerId"] = new SelectList(_context.Set<Answer>(), "Id", "Id", question.AnswerId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", question.CategoryId);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,AnswerId,CategoryId")] Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
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
            ViewData["AnswerId"] = new SelectList(_context.Set<Answer>(), "Id", "Id", question.AnswerId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", question.CategoryId);
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .Include(q => q.Answer)
                .Include(q => q.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Question.FindAsync(id);
            _context.Question.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Question.Any(e => e.Id == id);
        }*/
    }
}
