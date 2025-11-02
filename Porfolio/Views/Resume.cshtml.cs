using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Porfolio.Models;

namespace Porfolio.Pages
{
    public class ResumeModel : PageModel
    {
        private readonly ILogger<ResumeModel> _logger;

        [BindProperty]
        public Resume ResumeData { get; set; } = new();

        public ResumeModel(ILogger<ResumeModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            await Task.Delay(10);
            // In a real app, you'd fetch this from a database/service
            ResumeData = new Resume
            {
                Names = "Omphulusa",
                Surname = "Mashau",
                Address = "Johannesburg, South Africa",
                Email = "your.email@example.com",
                Cell = "+27 12 345 6789",
                Certifications = new(),
                Qualifications = new List<Qualification>
                {
                    new Qualification
                    {
                        Name = "BSc Computer Science (Honours)",
                        Description = "Specialized in AI and Robotics. Thesis on IoT Security.",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2024, 12, 31)
                    },
                    // Add more qualifications
                },
                Experiences = new List<Experience>
                {
                    new Experience
                    {
                        Name = "Junior IoT Developer",
                        Description = "Developed embedded systems for smart home applications using Raspberry Pi and Arduino.",
                        StartDate = new DateTime(2023, 6, 1),
                        EndDate = new DateTime(2024, 5, 31)
                    },
                    // Add more experiences
                },
                References = new List<Reference>
                {
                    new Reference
                    {
                        Names = "Dr. Jane Smith",
                        Email = "j.smith@university.edu",
                        Cell = "+27 11 222 3333",
                        Relation = "Academic Supervisor"
                    },
                    // Add more references
                }
            };
        }
    }
}