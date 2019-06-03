# Giphy4NET
[![NuGet](https://img.shields.io/nuget/v/Giphy4NET.svg)](https://www.nuget.org/packages/Giphy4NET/)

A .NET giphy api wrapper.

## `Features`
- Gif Search
- Gif Sticker
- Gif Translate
- Asynchronous interface
- Strongly-typed

___

## `Getting Started`

> ###### Prerequisites
> - Giphy API key ([Get](https://developers.giphy.com/dashboard/) / [Manual](https://support.giphy.com/hc/en-us/articles/360020283431-Request-A-GIPHY-API-Key))
> - .NET Core >= 2.0 ([Get](https://dotnet.microsoft.com/download/dotnet-core/2.0))
> - Install the [Giphy4NET-NuGet Package](https://www.nuget.org/packages/Giphy4NET/)

```csharp
var giphy = new GiphyService(new GiphyConfiguration {
    Token = "[MY API KEY]"
});

var gif = await SearchGifAsync("High Five!");
```

___

## `Dependencies`

- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) (used for HTTP payload deserialization)
