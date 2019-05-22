using Hamahakki;
using HtmlAgilityPack;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class HelloWorldParser : IParser<string>
    {
        public string Parse(HtmlNode node)
        {
            return "Hello world!";
        }
    }

    public class FortyTwoParser : IParser<int>
    {
        public int Parse(HtmlNode node)
        {
            return 42;
        }
    }

    public class HisAliveTest
    {

        [Test]
        public async Task Run()
        {
            var actualSting = "";
            var actualInt = 0;
            HtmlNode actualNode = null;

            var hama = new Hamahakki.Agent();
            hama.FromWeb("http://google.com")
                .AddParserJob(new HelloWorldParser(), str => actualSting = str)
                .AddParserJob(new FortyTwoParser(), v => actualInt = v)
                .AddHtmlHandler(v => actualNode = v);
            await hama.Run();

            Assert.AreEqual("Hello world!", actualSting);
            Assert.AreEqual(42, actualInt);
            Assert.IsNotEmpty(actualNode.InnerHtml);
        }
    }
}