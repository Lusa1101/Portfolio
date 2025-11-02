using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Porfolio.Data;
using Porfolio.Models;
using Porfolio.ViewModels;
using Supabase;

namespace Porfolio.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly Client _client;
        public ProjectsController(Client client)
        {
            _client = client;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var list = await _client.From<Project>().Get();
            var images = await _client.From<ProjectImage>().Get();
            List<ProjectViewModel> vms = new();
            
            foreach(var project in list.Models)
            {
                ProjectViewModel vm = new();
                vm.ProjectInstance = project;
                vm.ProjectImages = images.Models.Where(p => p.ProjectId == project.Id).ToList();
                vms.Add(vm);
            }

            //Order the projects in descending order by DateCreate
            vms = vms.OrderByDescending(p => p.ProjectInstance.StartDate).ToList();

            return View(vms);//(list.Models);
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id == null)
            {
                return NotFound();
            }

            var list = await _client.From<Project>().Get();
            var project = list.Models.FirstOrDefault(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);*/
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,StartDate,EndDate,TechnologyStack,Images")] Project project)
        {
            await Task.Delay(100000);
            return NotFound();/*
            if (ModelState.IsValid)
            {
                await _client.From<Project>().Insert(project);

                return RedirectToAction(nameof(Index));
            }
            return View(project);*/
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id == null)
            {
                return NotFound();
            }

            var list = await _client.From<Project>().Get();
            var project = list.Models.FirstOrDefault(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);*/
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,StartDate,EndDate,TechnologyStack,Images")] Project project)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _client.From<Project>().Update(project);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
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
            return View(project);*/
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id == null)
            {
                return NotFound();
            }

            var list = await _client.From<Project>().Get();
            var project = list.Models.FirstOrDefault(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);*/
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            var list = await _client.From<Project>().Get();
            var project = list.Models.FirstOrDefault(m => m.Id == id);
            if (project != null)
            {
                await _client.From<Project>().Delete(project);
            }

            return RedirectToAction(nameof(Index));*/
        }

        private bool ProjectExists(int id)
        {
            return false;// _client.From<Project>().Get().Result.Models.Any(e => e.Id == id);
        }

        //Images
        public List<IFormFile> Images { get; set; } = new();
        public IFormFile? Image { get; set; }
        public async Task<IActionResult> UploadImages(IFormFile file)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            await Task.Delay(10);
            if (file == null) 
            { 
                return NotFound();
            }

            if (file.Length > 0)
                Images.Add(file);

            return NoContent();*/
        }
    }
}
