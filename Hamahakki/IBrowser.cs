using System;
using ScrapySharp.Network;

namespace Hamahakki
{
    internal interface IBrowser
    {
        WebPage NavigateToPage(Uri uri);
    }
}