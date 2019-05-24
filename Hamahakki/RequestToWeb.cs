using HtmlAgilityPack;
using ScrapySharp.Network;
using System;
using System.Threading.Tasks;

namespace Hamahakki
{
    internal class RequestToWeb : Requestable
    {
        private static ScrapingBrowser _browser = new ScrapingBrowser();
        private readonly string url;
        private WebPage htmlPage;

        public RequestToWeb(string url) :base()
        {
            this.url = url;
        }

        protected override Task<HtmlNode> RequestTaskAction()
        {
            return new Task<HtmlNode>(() =>
            {
                if (htmlPage == null)
                {
                    htmlPage = _browser.NavigateToPage(new Uri(url));
                }
                return htmlPage.Html;
            });
        }
    }
}
