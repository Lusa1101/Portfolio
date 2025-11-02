using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Porfolio.Models;
using Supabase;
using System.Diagnostics;

namespace Porfolio.Controllers
{
    public class ResumeController : Controller
    {
        //Samples
        Resume resume = new();
        Resume resume1 = new();

        //Lists to get values from db
        List<Reference> References { get; set; } = new();
        List<Qualification> Qualifications { get; set; } = new();
        List<Experience> Experiences { get; set; } = new();
        List<Certification> Certifications { get; set; } = new();

        //Client instance
        private readonly Client _client;

        //The constructor
        public ResumeController(Client client)
        {
            _client = client;
        }

        // GET: ResumeController
        public async Task<IActionResult> Index()
        {
            //Get data from the db
            await GetData();

            //Set data
            Set();

            return View(resume);
        }

        private void Set()
        {
            resume = new Resume
            {
                Names = "Omphulusa",
                Initials = "O",
                Surname = "Mashau",
                Address = "Gauteng, South Africa",
                Cell = "0783887879",
                Email = "omphu.shau@outlook.com",
                Certifications = this.Certifications,
                Qualifications = this.Qualifications,
                Experiences = this.Experiences,
                References = this.References
            };
        }

        private async Task GetData()
        {
            //Experiences
            var list = await _client.From<Experience>().Get();
            Experiences = list.Models;

            //References
            var list2 = await _client.From<Reference>().Get();
            References = list2.Models;

            //Qualifications
            var list3 = await _client.From<Qualification>().Get();
            Qualifications = list3.Models;

            //Certifications
            var list4 = await _client.From<Certification>().Get();
            Certifications = list4.Models;

            foreach(var item in Qualifications)
                Debug.WriteLine(item.Name);

            //Arrange the lists
            ArrangeLists();
        }

        private void ArrangeLists()
        {
            //Arrange the lists in a specific order if needed
            References = References.OrderBy(r => r.DateCreated).ToList();
            Qualifications = Qualifications.OrderByDescending(q => q.StartDate).ToList();
            Experiences = Experiences.OrderByDescending(e => e.StartDate).ToList();
            Certifications = Certifications.OrderByDescending(c => c.IssueDate).ToList();
        }

        // GET: ResumeController/Details/5
        public ActionResult Details(int id)
        {
            return NotFound();
        }

        // GET: ResumeController/Create
        public ActionResult Create()
        {
            return NotFound();
        }

        // POST: ResumeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return NotFound();
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: ResumeController/Edit/5
        public ActionResult Edit(int id)
        {
            return NotFound();
        }

        // POST: ResumeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return NotFound();
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: ResumeController/Delete/5
        public ActionResult Delete(int id)
        {
            return NotFound();
        }

        // POST: ResumeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            return NotFound();
        }
    }
}
