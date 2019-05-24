﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Hamahakki
{
    public class Agent : IAgent
    {
        #region Private members

        private readonly IUrlParamsBuilder urlParamsBuilder = new UrlParamsBuilder();
        private readonly List<IResponseTasksProvider> handlers = new List<IResponseTasksProvider>();

        #endregion
        internal Agent(IUrlParamsBuilder urlParamsBuilder)
        {
            this.urlParamsBuilder = urlParamsBuilder;
        }

        public Agent() : this(new UrlParamsBuilder())
        {
        }

        #region IAgent implementation

        public IRequestHandler FromNode(HtmlNode node)
        {
            var req = new RequestToHtml(node);
            return MakeRequestHandler(req);
        }

        public IRequestHandler FromWeb(string url, params (string arg, string value)[] args)
        {
            return FromWeb(urlParamsBuilder.BuildUrl(url, args));
        }

        public IRequestHandler FromWeb(string url)
        {
            var req = new RequestToWeb(url);
            return MakeRequestHandler(req);
        }

        public async Task Run()
        {
            foreach (var item in handlers)
            {
                await item.Do();
            }
            await Task.WhenAll(handlers.SelectMany(h => h.Tasks));
        }

        #endregion

        #region Private methods
        private IRequestHandler MakeRequestHandler(IRequestable request)
        {
            var handler = new RequestHandler(request);
            handlers.Add(handler);
            return handler;
        }
        #endregion
    }
}
