using System;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Hamahakki
{
    public interface IRequestHandler 
    {
        IRequestHandler ParseTo<T>(IParser<T> parser, Action<T> action);
        IRequestHandler RawHtmlNode(Action<HtmlNode> handler);
        void Run();
    }
}
