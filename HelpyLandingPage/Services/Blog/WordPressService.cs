using System.Text.Json;

namespace HelpyLandingPage.Services.Blog
{
    public class WordPressService
    {
        private readonly HttpClient _httpClient;

        public WordPressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BlogPost>> GetBlogPostsAsync()
        {
            var response = await _httpClient.GetAsync("https://helpyapp.blog/wp-json/wp/v2/posts");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var posts = JsonSerializer.Deserialize<List<BlogPost>>(jsonResponse, options);
            return posts;
        }
    }
}
