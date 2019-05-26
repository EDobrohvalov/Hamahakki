using System;
using ScrapySharp.Network;

namespace Hamahakki
{
    internal class ScrapySharpBrowser : IBrowser
    {
        private static readonly ScrapingBrowser Browser = new ScrapingBrowser();

        public WebPage NavigateToPage(Uri uri)
        {
            return Browser.NavigateToPage(uri);
        }
    }
}