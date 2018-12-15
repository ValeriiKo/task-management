using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebIdentity.Data;
using WebIdentity.Models;

namespace WebIdentity.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProblemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Problems
        public async Task<IActionResult> Index()
        {
            var listTasks = _context.Problem.ToListAsync().Result;
            return View(await _context.Problem.ToListAsync());
        }

        public async Task<IActionResult> Hot()
        {
            var hotTasks = _context.Problem.ToListAsync().Result.Where(p => 
            (p.DateEnd.Date == DateTime.Now.Date) && (p.DateEnd.AddHours(-2) < DateTime.Now) && (p.DateEnd > DateTime.Now));
            return View("Index", (object)hotTasks);
        }

        // GET: Problems/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problem = await _context.Problem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (problem == null)
            {
                return NotFound();
            }

            return View(problem);
        }

        // GET: Problems/Create
        public IActionResult Create()
        {
            var managers = _context.Manager.ToListAsync().Result;
            var model = new ProblemViewModel
            {
                Managers = managers.Select(x => new SelectListItem
                {
                    Value = x.Id,
                    Text = x.Name
                })
            };
            return View(model);
        }

        // POST: Problems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProblemViewModel problemVM)       
        {
            if (ModelState.IsValid)
            {
                var managers = _context.Manager.ToListAsync().Result;
                _context.Add(new Problem {
                    Name = problemVM.Name,
                    DateBegin = problemVM.DateBegin,
                    DateEnd = problemVM.DateEnd,
                    Status = problemVM.Status,
                    ManagerId = problemVM.SelectedManagerId,
                    ManagerName = managers.Where(m => m.Id == problemVM.SelectedManagerId).First().Name
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(problemVM);
        }

        // GET: Problems/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problem = await _context.Problem.FindAsync(id);
            if (problem == null)
            {
                return NotFound();
            }
            return View(problem);
        }

        // POST: Problems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,DateBegin,DateEnd,Status")] Problem problem)
        {
            if (id != problem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(problem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProblemExists(problem.Id))
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
            return View(problem);
        }

        // GET: Problems/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problem = await _context.Problem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (problem == null)
            {
                return NotFound();
            }

            return View(problem);
        }

        // POST: Problems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var problem = await _context.Problem.FindAsync(id);
            _context.Problem.Remove(problem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProblemExists(string id)
        {
            return _context.Problem.Any(e => e.Id == id);
        }
    }
}
