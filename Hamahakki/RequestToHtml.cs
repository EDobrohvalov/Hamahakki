using System;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Hamahakki
{

    internal class RequestToHtml : Requestable
    {
        #region Members
        private readonly HtmlNode resultNode;
        #endregion

        #region Ctor
        public RequestToHtml(HtmlNode htmlNode)
        {
            resultNode = htmlNode ?? throw new ArgumentNullException(nameof(htmlNode));
        }
        #endregion

        #region Protected methods
        protected override Task<HtmlNode> RequestTaskAction()
        {
            return new Task<HtmlNode>(() => resultNode);
        }
        #endregion
    }

}
