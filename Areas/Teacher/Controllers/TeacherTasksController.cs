using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPBoysGirlsIdentity.Data;
using ASPBoysGirlsIdentity.Models;

namespace ASPBoysGirlsIdentity.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class TeacherTasksController : Controller
    {
        private readonly ASPBoysGirlsIdentityContext _context;

        public TeacherTasksController(ASPBoysGirlsIdentityContext context)
        {
            _context = context;
        }

        // GET: Teacher/TeacherTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeacherTasks.ToListAsync());
        }

        // GET: Teacher/TeacherTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherTask = await _context.TeacherTasks
                .FirstOrDefaultAsync(m => m.id == id);
            if (teacherTask == null)
            {
                return NotFound();
            }

            return View(teacherTask);
        }

        // GET: Teacher/TeacherTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teacher/TeacherTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,desc,loc")] TeacherTask teacherTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacherTask);
        }

        // GET: Teacher/TeacherTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherTask = await _context.TeacherTasks.FindAsync(id);
            if (teacherTask == null)
            {
                return NotFound();
            }
            return View(teacherTask);
        }

        // POST: Teacher/TeacherTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,desc,loc")] TeacherTask teacherTask)
        {
            if (id != teacherTask.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherTaskExists(teacherTask.id))
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
            return View(teacherTask);
        }

        // GET: Teacher/TeacherTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherTask = await _context.TeacherTasks
                .FirstOrDefaultAsync(m => m.id == id);
            if (teacherTask == null)
            {
                return NotFound();
            }

            return View(teacherTask);
        }

        // POST: Teacher/TeacherTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherTask = await _context.TeacherTasks.FindAsync(id);
            _context.TeacherTasks.Remove(teacherTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherTaskExists(int id)
        {
            return _context.TeacherTasks.Any(e => e.id == id);
        }
    }
}
