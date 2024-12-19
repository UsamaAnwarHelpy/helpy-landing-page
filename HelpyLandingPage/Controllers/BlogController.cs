using HelpyLandingPage.Services.Blog;
using Microsoft.AspNetCore.Mvc;

namespace HelpyLandingPage.Controllers
{
    public class BlogController : Controller
    {
        private readonly WordPressService _wordPressService;

        public BlogController(WordPressService wordPressService)
        {
            _wordPressService = wordPressService;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _wordPressService.GetBlogPostsAsync();
            return View(posts);
        }
    }
}
