using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hamahakki
{
    internal interface IJobsStorage
    {
        void AddRequestAction(IRequestable request);
        void AddResponseAction(IRequestable request, Action<HtmlNode> action);
        Task DoRequestActions();
        Task DoResponceActions();
    }
}
