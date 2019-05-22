using HtmlAgilityPack;

namespace Hamahakki
{
    internal interface IRequestFactory
    {
        IRequestable CreateHtmlRequest(HtmlNode node);
        IRequestable CreateWebRequest(string url);
    }
}