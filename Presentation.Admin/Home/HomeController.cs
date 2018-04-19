using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Core.Presentation.Admin.Home.Views
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}