using IntroAspNet.Service.Services.Abstraction;
using IntroAspNet.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IntroAspNet.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;
        public HomeController(ILogger<HomeController> logger, IArticleService articleService) => (_logger, _articleService) = (logger, articleService);

        public async Task<IActionResult> Index() => View(await _articleService.GetAllArticlesAsync());

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}