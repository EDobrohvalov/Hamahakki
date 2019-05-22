using HtmlAgilityPack;
using System.Threading.Tasks;

namespace Hamahakki
{
    internal interface IRequestable
    {
        Task<HtmlNode> Request();
    }

}
