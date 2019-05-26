using HtmlAgilityPack;
using System;
using System.Threading.Tasks;

namespace Hamahakki
{
    internal abstract class Requestable : IRequestable
    {
        #region Members

        private readonly Task<HtmlNode> requestTask;
        #endregion

        #region Ctor
        public Requestable()
        {
            requestTask = RequestTaskAction();
        }
        #endregion

        #region IRequestable implementation
        public Task AddHandlerAction(Action<HtmlNode> action)
        {
            return requestTask.ContinueWith(request => action(request.Result));
        }

        public async Task<HtmlNode> Request()
        {
            requestTask.Start();
            return await requestTask;
        }
        #endregion

        #region Protected methods
        protected abstract Task<HtmlNode> RequestTaskAction();
        #endregion
    }

}
