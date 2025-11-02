using Porfolio.Models;

namespace Porfolio.ViewModels
{
    public class ProjectViewModel
    {
        //Project model with an inclusion of Images
        public Project ProjectInstance { get; set; } = new();
        public List<ProjectImage> ProjectImages { get; set; } = new();
    }
}
