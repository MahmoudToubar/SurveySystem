using Microsoft.AspNetCore.Mvc;
using SurveySystem.Models;
using SurveySystem.Repositories;
using System.Diagnostics;

namespace SurveySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKPIRepository kpiRepository;

        public HomeController(ILogger<HomeController> logger, IKPIRepository kpiRepository)
        {
            _logger = logger;
            this.kpiRepository = kpiRepository;
        }

        public async Task <IActionResult> Index()
        {
            var kpi = await kpiRepository.GetAllAsync();
            return View(kpi);
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
}