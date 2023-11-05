using IntroAspNet.Service.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace IntroAspNet.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        public HomeController(IArticleService articleService) => _articleService = articleService;

        public async Task<IActionResult> Index() => View(await _articleService.GetAllArticlesAsync());
    }
}
