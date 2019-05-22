# Small and stupid lib for parse ScrappySharp results into custom types

### Implement HtmlNode parser, with all the features of [ScrappySharp](https://github.com/rflechner/ScrapySharp) selectors

``` C#
    public interface IParser<T>
    {
        T Parse(HtmlNode node);
    }
```

### Parsers implementations example

``` C#
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
```

### How to use

```C#
    var hama = new Hamahakki.Agent();
    hama.FromWeb("https://google.com")
        .AddParserJob(new HelloWorldParser(), stringValue => {
            // stringValue - is result of HelloWorldParser work.
            // In current example value is equal 'Hello world!'
        })
        .AddParserJob(new FortyTwoParser(), intValue => {
            // intValue - is result of FortyTwoParser work.
            // In current example value is equal 42  
        })
        .AddHtmlHandler(htmlNode => {
            // htmlNode - contain HTML code of http://google.com site
        });
    await hama.Run(); // waiting for execution all requests and all parsers jobs
```
