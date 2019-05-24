using System;
using HtmlAgilityPack;

namespace Hamahakki
{
    public interface IRequestHandler
    {
        IRequestHandler ParseTo<T>(IParser<T> parser, Action<T> resultHandler);
        IRequestHandler RawHtmlNode(Action<HtmlNode> htmlHandler);
    }
}
