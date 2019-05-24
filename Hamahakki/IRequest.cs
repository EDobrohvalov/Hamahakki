using HtmlAgilityPack;
using System;
using System.Threading.Tasks;

namespace Hamahakki
{
    internal interface IRequestable
    {
        Task<HtmlNode> Request();
        Task AddHandlerAction (Action<HtmlNode> action);
    }

}
