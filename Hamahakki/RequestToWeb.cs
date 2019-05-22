using HtmlAgilityPack;
using ScrapySharp.Network;
using System;
using System.Threading.Tasks;

namespace Hamahakki
{
    internal class RequestToWeb : IRequestable
    {
        private static ScrapingBrowser _browser = new ScrapingBrowser();

        private readonly string url;
        private WebPage htmlPage;

        public RequestToWeb(string url)
        {
            this.url = url;
        }

        public async Task<HtmlNode> Request()
        {
            if (htmlPage == null)
            {
                htmlPage = await _browser.NavigateToPageAsync(new Uri(url));
            }
            return htmlPage.Html;
        }
    }

}
