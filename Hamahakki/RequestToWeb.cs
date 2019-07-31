using System;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScrapySharp.Network;

namespace Hamahakki
{
    internal class RequestToWeb : Requestable
    {
        private readonly IBrowser browser;

        #region Members

        private readonly string url;
        private WebPage htmlPage;

        #endregion

        #region Ctor

        internal RequestToWeb(IBrowser browser, string url)
        {
            this.browser = browser;
            this.url = url;
        }

        public RequestToWeb(string url) : this(new ScrapySharpBrowser(), url)
        {
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