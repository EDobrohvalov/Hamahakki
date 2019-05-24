using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hamahakki
{

    internal class RequestToHtml : Requestable
    {
        private readonly HtmlNode resultNode;
        public RequestToHtml(HtmlNode htmlNode) : base()
        {
            resultNode = htmlNode ?? throw new ArgumentNullException(nameof(htmlNode));
        }

        protected override Task<HtmlNode> RequestTaskAction()
        {
            return new Task<HtmlNode>(() => resultNode);
        }
    }

}
