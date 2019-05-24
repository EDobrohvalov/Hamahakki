using HtmlAgilityPack;
using System;
using System.Threading.Tasks;

namespace Hamahakki
{
    internal abstract class Requestable : IRequestable
    {
        #region Members
        protected readonly Task<HtmlNode> RequestTask;
        #endregion

        #region Ctor
        public Requestable()
        {
            RequestTask = RequestTaskAction();
        }
        #endregion

        #region IRequestable implementation
        public Task AddHandlerAction(Action<HtmlNode> action)
        {
            return RequestTask.ContinueWith(request => action(request.Result));
        }

        public async Task<HtmlNode> Request()
        {
            RequestTask.Start();
            return await RequestTask;
        }
        #endregion

        #region Protected methods
        protected abstract Task<HtmlNode> RequestTaskAction();
        #endregion
    }

}
