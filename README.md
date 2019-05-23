﻿# Getting started
 
Hamahakki - it's simple wrapper for [ScrappySharp](https://github.com/rflechner/ScrapySharp) for minification boilerplate code for actions like HTTP request, handling html response and parse it to custom structures.

## Basic examples of usages

### 

### Implement IParser interface

``` C#
    public interface IParser<T>
    {
        T Parse(HtmlNode node);
    }
```

### Like this, for example.

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

### Define scenario with result handlers, and run angent.

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
