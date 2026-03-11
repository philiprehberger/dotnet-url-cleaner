# Changelog

## 0.1.0 (2026-03-10)

- Initial release
- `UrlCleaner.RemoveTracking(string)` — remove tracking params from a URL string
- `UrlCleaner.RemoveTracking(Uri)` — remove tracking params from a `Uri`
- Built-in list: utm_*, fbclid, gclid, msclkid, mc_eid, ref, _ga, _gl
- Accepts additional params to remove via `additionalParams`
