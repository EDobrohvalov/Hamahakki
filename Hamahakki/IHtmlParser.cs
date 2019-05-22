using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hamahakki
{
    public interface IParser<T>
    {
        T Parse(HtmlNode node);
    }
}
