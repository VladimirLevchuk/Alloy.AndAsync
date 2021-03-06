using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Alloy.AndAsync.Models.Pages;
using Alloy.AndAsync.Models.ViewModels;
using EPiServer.Web;
using Microsoft.Ajax.Utilities;

namespace Alloy.AndAsync.Controllers
{
    public class TestArticlePageController : PageControllerBase<TestArticlePage>
    {
        public async Task<ViewResult> Index(TestArticlePage currentPage)
        {
            var result = new TestArticlePageViewModel(currentPage)
            {
                SomeExternalData = await GetExternalData(),
                SiteStartPageId = SiteDefinition.Current.IfNotNull(x => x.StartPage.ID)
            };

            return View(result);
        }

        public async Task<string> GetExternalData()
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync("http://google.com");
            }
        }

        public async Task<ActionResult> AsyncAction(TestArticlePage currentPage)
        {
            var result = new TestArticlePageViewModel(currentPage)
            {
                SomeExternalData = await GetExternalData(),
                SiteStartPageId = SiteDefinition.Current.IfNotNull(x => x.StartPage.ID)
            };

            return PartialView(result);
        }
    }
}