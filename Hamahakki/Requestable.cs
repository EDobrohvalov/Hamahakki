using HtmlAgilityPack;
using System;
using System.Threading.Tasks;

namespace Hamahakki
{
    internal abstract class Requestable : IRequestable
    {
        protected readonly Task<HtmlNode> RequestTask;

        public Requestable()
        {
            RequestTask = RequestTaskAction();
        }

        public Task AddHandlerAction(Action<HtmlNode> action)
        {
            return RequestTask.ContinueWith(request => action(request.Result));
        }

        public async Task<HtmlNode> Request()
        {
            RequestTask.Start();
            return await RequestTask;
        }

        protected abstract Task<HtmlNode> RequestTaskAction();
    }

}
