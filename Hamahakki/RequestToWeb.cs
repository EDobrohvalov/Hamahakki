using HtmlAgilityPack;
using ScrapySharp.Network;
using System;
using System.Threading.Tasks;

namespace Hamahakki
{
    internal class RequestToWeb : Requestable
    {
        #region Members
        private static ScrapingBrowser browser = new ScrapingBrowser();
        private readonly string url;
        private WebPage htmlPage;
        #endregion

        #region Ctor
        public RequestToWeb(string url) :base()
        {
            this.url = url;
        }
        #endregion

        #region Protected methods
        protected override Task<HtmlNode> RequestTaskAction()
        {
            return new Task<HtmlNode>(() =>
            {
                if (htmlPage == null)
                {
                    htmlPage = browser.NavigateToPage(new Uri(url));
                }
                return htmlPage.Html;
            });
        }
        #endregion
    }
}
