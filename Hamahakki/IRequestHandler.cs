using System;
using HtmlAgilityPack;

namespace Hamahakki
{
    public interface IRequestHandler
    {
        IRequestHandler AddParserJob<T>(IParser<T> parser, Action<T> resultHandler);
        IRequestHandler AddHtmlHandler(Action<HtmlNode> htmlHandler);
    }

}
