using HtmlAgilityPack;
using System;
using System.Threading.Tasks;

namespace Hamahakki
{
    internal interface IRequestable
    {
        void Request();
        Task AddHandlerAction(Action<HtmlNode> action);
    }

}
