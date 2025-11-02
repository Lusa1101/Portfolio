using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Porfolio.Data;
using Porfolio.Models;
using Supabase;

namespace Porfolio.Controllers
{
    public class QualificationsController : Controller
    {
        private readonly Client _client;

        public QualificationsController(Client client)
        {
            _client = client;
        }

        // GET: Qualifications
        public async Task<IActionResult> Index()
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            var list = await _client.From<Qualification>().Get();
            return View(list.Models);*/
        }

        // GET: Qualifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id == null)
            {
                return NotFound();
            }

            var list = await _client.From<Qualification>().Get();
            var qualification = list.Models.FirstOrDefault(m => m.Id == id);
            if (qualification == null)
            {
                return NotFound();
            }

            return View(qualification);*/
        }

        // GET: Qualifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Qualifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,StartDate,EndDate")] Qualification qualification)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (ModelState.IsValid)
            {
                await _client.From<Qualification>().Insert(qualification);

                return RedirectToAction(nameof(Index));
            }
            return View(qualification);*/
        }

        // GET: Qualifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id == null)
            {
                return NotFound();
            }

            var list = await _client.From<Qualification>().Get();
            var qualification = list.Models.FirstOrDefault(m => m.Id == id);
            if (qualification == null)
            {
                return NotFound();
            }
            return View(qualification);*/
        }

        // POST: Qualifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,StartDate,EndDate")] Qualification qualification)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id != qualification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _client.From<Qualification>().Update(qualification);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QualificationExists(qualification.Id))
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
            return View(qualification);*/
        }

        // GET: Qualifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id == null)
            {
                return NotFound();
            }

            var list = await _client.From<Qualification>().Get();
            var qualification = list.Models.FirstOrDefault(m => m.Id == id);
            if (qualification == null)
            {
                return NotFound();
            }

            return View(qualification);*/
        }

        // POST: Qualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            var list = await _client.From<Qualification>().Get();
            var qualification = list.Models.FirstOrDefault(m => m.Id == id);
            if (qualification != null)
            {
                await _client.From<Qualification>().Delete(qualification);
            }

            return RedirectToAction(nameof(Index));*/
        }

        private bool QualificationExists(int id)
        {
            return false; // _client.From<Qualification>().Get().Result.Models.Any(e => e.Id == id);
        }
    }
}
