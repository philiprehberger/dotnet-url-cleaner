using System.Web;

namespace Philiprehberger.UrlCleaner;

public static class UrlCleaner
{
    private static readonly HashSet<string> DefaultTrackingParams = new(StringComparer.OrdinalIgnoreCase)
    {
        "utm_source", "utm_medium", "utm_campaign", "utm_term", "utm_content",
        "fbclid", "gclid", "msclkid", "mc_eid", "ref", "_ga", "_gl"
    };

    public static string RemoveTracking(string url, IEnumerable<string>? additionalParams = null)
    {
        if (string.IsNullOrEmpty(url))
            return url;

        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
            return url;

        return RemoveTracking(uri, additionalParams);
    }

    public static string RemoveTracking(Uri uri, IEnumerable<string>? additionalParams = null)
    {
        var paramsToRemove = BuildParamSet(additionalParams);

        var query = uri.Query;
        if (string.IsNullOrEmpty(query))
            return uri.ToString();

        var parsed = HttpUtility.ParseQueryString(query);
        var keysToRemove = parsed.AllKeys
            .Where(k => k is not null && paramsToRemove.Contains(k))
            .ToList();

        foreach (var key in keysToRemove)
            parsed.Remove(key);

        var builder = new UriBuilder(uri)
        {
            Query = parsed.Count > 0 ? parsed.ToString() : string.Empty
        };

        return builder.Uri.ToString();
    }

    private static HashSet<string> BuildParamSet(IEnumerable<string>? additionalParams)
    {
        if (additionalParams is null)
            return DefaultTrackingParams;

        var set = new HashSet<string>(DefaultTrackingParams, StringComparer.OrdinalIgnoreCase);
        foreach (var param in additionalParams)
            set.Add(param);

        return set;
    }
}
