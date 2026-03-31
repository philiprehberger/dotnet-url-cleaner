# Philiprehberger.UrlCleaner

[![CI](https://github.com/philiprehberger/dotnet-url-cleaner/actions/workflows/ci.yml/badge.svg)](https://github.com/philiprehberger/dotnet-url-cleaner/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/Philiprehberger.UrlCleaner.svg)](https://www.nuget.org/packages/Philiprehberger.UrlCleaner)
[![Last updated](https://img.shields.io/github/last-commit/philiprehberger/dotnet-url-cleaner)](https://github.com/philiprehberger/dotnet-url-cleaner/commits/main)

Remove tracking parameters from URLs — strip UTM tags, fbclid, gclid, and more.

## Installation

```bash
dotnet add package Philiprehberger.UrlCleaner
```

## Usage

```csharp
using Philiprehberger.UrlCleaner;

// Clean a URL string
var clean = UrlCleaner.RemoveTracking(
    "https://example.com/page?utm_source=newsletter&utm_medium=email&id=42");
// => "https://example.com/page?id=42"

// All default tracking params removed
UrlCleaner.RemoveTracking("https://example.com/?fbclid=abc&gclid=xyz&q=hello");
// => "https://example.com/?q=hello"

// With a Uri overload
var uri = new Uri("https://example.com/?ref=twitter&page=1");
UrlCleaner.RemoveTracking(uri);
// => "https://example.com/?page=1"

// Add extra params to strip
UrlCleaner.RemoveTracking(
    "https://example.com/?custom_track=1&q=hi",
    additionalParams: ["custom_track"]);
// => "https://example.com/?q=hi"

// Fragment is preserved
UrlCleaner.RemoveTracking("https://example.com/?utm_source=x#section");
// => "https://example.com/#section"
```

### Custom Parameters

```csharp
using Philiprehberger.UrlCleaner;

var url = "https://example.com/page?ref=twitter&session=abc123&id=42";
var clean = UrlCleaner.RemoveTracking(url, new[] { "session" });
// "https://example.com/page?id=42"
```

### Uri Overload

```csharp
using Philiprehberger.UrlCleaner;

var uri = new Uri("https://example.com/page?utm_source=google&utm_medium=cpc&q=test");
var clean = UrlCleaner.RemoveTracking(uri);
// "https://example.com/page?q=test"
```

## API

### `UrlCleaner`

| Method | Description |
|--------|-------------|
| `RemoveTracking(string url, IEnumerable<string>? additionalParams = null)` | Strip tracking params from a URL string; returns the input unchanged if it is not a valid absolute URL |
| `RemoveTracking(Uri uri, IEnumerable<string>? additionalParams = null)` | Strip tracking params from a `Uri` |

**Default tracking parameters removed:**

`utm_source`, `utm_medium`, `utm_campaign`, `utm_term`, `utm_content`, `fbclid`, `gclid`, `msclkid`, `mc_eid`, `ref`, `_ga`, `_gl`

## Development

```bash
dotnet build src/Philiprehberger.UrlCleaner.csproj --configuration Release
```

## Support

If you find this project useful:

⭐ [Star the repo](https://github.com/philiprehberger/dotnet-url-cleaner)

🐛 [Report issues](https://github.com/philiprehberger/dotnet-url-cleaner/issues?q=is%3Aissue+is%3Aopen+label%3Abug)

💡 [Suggest features](https://github.com/philiprehberger/dotnet-url-cleaner/issues?q=is%3Aissue+is%3Aopen+label%3Aenhancement)

❤️ [Sponsor development](https://github.com/sponsors/philiprehberger)

🌐 [All Open Source Projects](https://philiprehberger.com/open-source-packages)

💻 [GitHub Profile](https://github.com/philiprehberger)

🔗 [LinkedIn Profile](https://www.linkedin.com/in/philiprehberger)

## License

[MIT](LICENSE)
