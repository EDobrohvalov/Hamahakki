using HtmlAgilityPack;
using System;
using System.Threading.Tasks;

namespace Hamahakki
{
    internal class RequestToHtml : IRequestable
    {
        private readonly HtmlNode htmlNode;

        public RequestToHtml(HtmlNode htmlNode)
        {
            this.htmlNode = htmlNode ?? throw new ArgumentNullException(nameof(htmlNode));
        }

        public async Task<HtmlNode> Request()
        {
            return await Task.FromResult(htmlNode);
        }
    }

}
