using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Hamahakki
{
    internal class JobsStorage : IJobsStorage
    {
        private readonly List<IRequestable> requestActions = new List<IRequestable>();
        private readonly List<Task> responseActions = new List<Task>();
        private readonly Dictionary<IRequestable,HtmlNode> responseData = new Dictionary<IRequestable,HtmlNode>();
       
        public void AddRequestAction(IRequestable request)
        {
            requestActions.Add(request);
        }

        public void AddResponseAction(IRequestable request, Action<HtmlNode> action)
        {
            responseActions.Add(new Task(() =>
            {
                action(responseData[request]);
            }));
        }

        public async Task DoRequestActions()
        {
            foreach (var request in requestActions)
            {
                responseData[request] = await request.Request();
            }
        }

        public async Task DoResponceActions()
        {
             foreach (var action in responseActions) action.Start();
            await Task.WhenAll(responseActions);
        }
    }
}
