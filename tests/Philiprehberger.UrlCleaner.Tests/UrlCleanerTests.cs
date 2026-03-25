using Xunit;
using Philiprehberger.UrlCleaner;

namespace Philiprehberger.UrlCleaner.Tests;

public class UrlCleanerTests
{
    [Fact]
    public void RemoveTracking_UrlWithUtmParams_RemovesAllUtm()
    {
        var url = "https://example.com/page?utm_source=google&utm_medium=cpc&utm_campaign=test&keep=1";
        var result = Philiprehberger.UrlCleaner.UrlCleaner.RemoveTracking(url);

        Assert.Contains("keep=1", result);
        Assert.DoesNotContain("utm_source", result);
        Assert.DoesNotContain("utm_medium", result);
        Assert.DoesNotContain("utm_campaign", result);
    }

    [Fact]
    public void RemoveTracking_UrlWithFbclid_RemovesFbclid()
    {
        var url = "https://example.com/?fbclid=abc123&page=2";
        var result = Philiprehberger.UrlCleaner.UrlCleaner.RemoveTracking(url);

        Assert.DoesNotContain("fbclid", result);
        Assert.Contains("page=2", result);
    }

    [Fact]
    public void RemoveTracking_NoTrackingParams_ReturnsUnchanged()
    {
        var url = "https://example.com/page?id=5&sort=name";
        var result = Philiprehberger.UrlCleaner.UrlCleaner.RemoveTracking(url);

        Assert.Contains("id=5", result);
        Assert.Contains("sort=name", result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void RemoveTracking_NullOrEmpty_ReturnsSameValue(string? input)
    {
        var result = Philiprehberger.UrlCleaner.UrlCleaner.RemoveTracking(input!);

        Assert.Equal(input, result);
    }

    [Fact]
    public void RemoveTracking_InvalidUrl_ReturnsOriginal()
    {
        var result = Philiprehberger.UrlCleaner.UrlCleaner.RemoveTracking("not-a-url");

        Assert.Equal("not-a-url", result);
    }

    [Fact]
    public void RemoveTracking_NoQueryString_ReturnsUnchanged()
    {
        var url = "https://example.com/page";
        var result = Philiprehberger.UrlCleaner.UrlCleaner.RemoveTracking(url);

        Assert.Equal("https://example.com/page", result);
    }

    [Fact]
    public void RemoveTracking_AdditionalParams_RemovesCustomParams()
    {
        var url = "https://example.com/?custom=val&keep=1";
        var result = Philiprehberger.UrlCleaner.UrlCleaner.RemoveTracking(url, new[] { "custom" });

        Assert.DoesNotContain("custom", result);
        Assert.Contains("keep=1", result);
    }

    [Fact]
    public void RemoveTracking_UriOverload_WorksCorrectly()
    {
        var uri = new Uri("https://example.com/?gclid=abc&page=1");
        var result = Philiprehberger.UrlCleaner.UrlCleaner.RemoveTracking(uri);

        Assert.DoesNotContain("gclid", result);
        Assert.Contains("page=1", result);
    }

    [Fact]
    public void RemoveTracking_CaseInsensitiveParamNames_RemovesRegardlessOfCase()
    {
        var url = "https://example.com/?UTM_SOURCE=test&keep=1";
        var result = Philiprehberger.UrlCleaner.UrlCleaner.RemoveTracking(url);

        Assert.DoesNotContain("UTM_SOURCE", result);
        Assert.Contains("keep=1", result);
    }

    [Fact]
    public void RemoveTracking_AllParamsAreTracking_ReturnsUrlWithoutQuery()
    {
        var url = "https://example.com/page?utm_source=google&fbclid=abc";
        var result = Philiprehberger.UrlCleaner.UrlCleaner.RemoveTracking(url);

        Assert.DoesNotContain("?", result);
    }
}
