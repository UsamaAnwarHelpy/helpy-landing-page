using HelpyLandingPage.Models;
using HelpyLandingPage.Services.Blog;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HelpyLandingPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WordPressService _wordPressService;

        public HomeController(ILogger<HomeController> logger, WordPressService wordPressService)
        {
            _logger = logger;
            _wordPressService = wordPressService;
        }

        public IActionResult Index()
        {
            return View();
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

        public async Task<IActionResult> CommingSoonLandingPage()
        {
            var posts = await _wordPressService.GetBlogPostsAsync();
            return View(posts);
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmail(string name, string email)
        {
            // Base URL for your API
            var baseUrl = "https://localhost:7238";

            // API Endpoint
            var endpoint = $"https://localhost:7238/user/InsertEmail?name={name}&email={email}";

            // Authorization token
            var authorizationToken = "0f910af0-db08-4d2e-8533-f79028b98345";

            using (var client = new HttpClient())
            {
                // Set the base URL
                client.BaseAddress = new Uri(baseUrl);

                // Add authorization header
                client.DefaultRequestHeaders.Add("Authorization", authorizationToken);

                try
                {
                    // Make the POST request
                    var response = await client.PostAsync(endpoint, null);

                    // Ensure the response is successful
                    response.EnsureSuccessStatusCode();

                    // Optionally, read the response content
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return Ok(new { Success = true, Response = responseContent });
                }
                catch (HttpRequestException ex)
                {
                    // Handle HTTP errors
                    return BadRequest(new { Success = false, Error = ex.Message });
                }
            }
        }

    }
}
