using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPBoysGirlsIdentity.Data;
using ASPBoysGirlsIdentity.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASPBoysGirlsIdentity.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = "Students")]
    public class StudentTasksController : Controller
    {
        private readonly ASPBoysGirlsIdentityContext _context;

        public StudentTasksController(ASPBoysGirlsIdentityContext context)
        {
            _context = context;
        }

        // GET: Student/StudentTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentTasks.ToListAsync());
        }

        // GET: Student/StudentTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTask = await _context.StudentTasks
                .FirstOrDefaultAsync(m => m.id == id);
            if (studentTask == null)
            {
                return NotFound();
            }

            return View(studentTask);
        }

        // GET: Student/StudentTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/StudentTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,desc,loc")] StudentTask studentTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentTask);
        }

        // GET: Student/StudentTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTask = await _context.StudentTasks.FindAsync(id);
            if (studentTask == null)
            {
                return NotFound();
            }
            return View(studentTask);
        }

        // POST: Student/StudentTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,desc,loc")] StudentTask studentTask)
        {
            if (id != studentTask.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentTaskExists(studentTask.id))
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
            return View(studentTask);
        }

        // GET: Student/StudentTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTask = await _context.StudentTasks
                .FirstOrDefaultAsync(m => m.id == id);
            if (studentTask == null)
            {
                return NotFound();
            }

            return View(studentTask);
        }

        // POST: Student/StudentTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentTask = await _context.StudentTasks.FindAsync(id);
            _context.StudentTasks.Remove(studentTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentTaskExists(int id)
        {
            return _context.StudentTasks.Any(e => e.id == id);
        }
    }
}
