using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Alloy.AndAsync.Models.Pages;
using Alloy.AndAsync.Models.ViewModels;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Routing;
using Microsoft.Ajax.Utilities;

namespace Alloy.AndAsync.Controllers
{
    public class TestArticlePageController : PageControllerBase<TestArticlePage>
    {
        public async Task<ViewResult> Index(TestArticlePage currentPage)
        {
            var result = new TestArticlePageViewModel(currentPage)
            {
                SomeExternalData = await GetExternalDataAsync(),
                SiteStartPageId = SiteDefinition.Current.IfNotNull(x => x.StartPage.ID),
                PageName = ServiceLocator.Current.GetInstance<PageRouteHelper>().Page.Name
            };

            return View(result);
        }

        public async Task<string> GetExternalDataAsync()
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync("http://google.com");
            }
        }

        public string GetExternalData()
        {
            using (var client = new HttpClient())
            {
                return client.GetStringAsync("http://google.com").Result;
            }
        }

        public ViewResult Action(TestArticlePage currentPage)
        {
            var result = new TestArticlePageViewModel(currentPage)
            {
                SomeExternalData = GetExternalData(),
                SiteStartPageId = SiteDefinition.Current.IfNotNull(x => x.StartPage.ID)
            };

            return View(result);
        }
    }
}