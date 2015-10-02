using Alloy.AndAsync.Models.Pages;

namespace Alloy.AndAsync.Models.ViewModels
{
    public class TestArticlePageViewModel : PageViewModel<TestArticlePage>
    {
        public TestArticlePageViewModel(TestArticlePage currentPage) : base(currentPage)
        {}

        public string SomeExternalData { get; set; }

        public int SiteStartPageId { get; set; }

        public string PageName { get; set; }
    }
}