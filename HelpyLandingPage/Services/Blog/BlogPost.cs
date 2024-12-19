namespace HelpyLandingPage.Services.Blog
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Link { get; set; }

        public RenderedContent Title { get; set; }
        public RenderedContent Content { get; set; }
        public RenderedContent Excerpt { get; set; }
        public FeaturedImageUrls RttpgFeaturedImageUrl { get; set; }

        public class RenderedContent
        {
            public string Rendered { get; set; }
        }
        public class FeaturedImageUrls
        {
            public List<object> Full { get; set; }
        }
    }
}
