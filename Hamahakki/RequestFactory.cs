using HtmlAgilityPack;

namespace Hamahakki
{
    internal sealed class RequestFactory : IRequestFactory
    {
        public IRequestable CreateHtmlRequest(HtmlNode node)
        {
            return new RequestToHtml(node);
        }

        public IRequestable CreateWebRequest(string url)
        {
            return new RequestToWeb(url);
        }
    }
}
