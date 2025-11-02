using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Porfolio.Models;
using Supabase;

namespace Porfolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Client _client;

    //To get the tech stack
    private List<Project> Projects { get; set; } = new();
    [BindProperty]
    public List<string> TectStack { get; set; } = new();

    public HomeController(ILogger<HomeController> logger, Client client)
    {
        _logger = logger;
        _client = client;
    }

    public async Task<IActionResult> Index()
    {
        //Get the stacks
        await GetProjects();

        return View(TectStack);
    }

    private async Task GetProjects()
    {
        var list = await _client.From<Project>().Get();
        Projects = list.Models;

        //Extrect the tech stact from the projects
        foreach(var project in Projects)
        {
            var cuurentStack = project.TechnologyStack.Split(", ");
            for(int i = 0; i < cuurentStack.Length; i++)
            {
                //Add to @TechStack if does not yet added
                if (!TectStack.Contains(cuurentStack[i]))
                    TectStack.Add(cuurentStack[i]);
            }
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
