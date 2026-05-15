# Changelog

## 0.1.10 (2026-05-15)

- Add NuGet package icon (`package-card.png`) — appears as the package icon on nuget.org

## 0.1.9 (2026-03-31)

- Standardize README to 3-badge format with emoji Support section
- Update CI actions to v5 for Node.js 24 compatibility
- Add GitHub issue templates, dependabot config, and PR template

## 0.1.8 (2026-03-24)

- Add unit tests
- Add test step to CI workflow

## 0.1.7 (2026-03-23)

- Sync .csproj description with README

## 0.1.6 (2026-03-22)

- Add dates to changelog entries

## 0.1.5 (2026-03-20)

- Expand README with custom parameters and Uri overload examples
- Add LangVersion and TreatWarningsAsErrors to csproj

## 0.1.4 (2026-03-16)

- Add Development section to README
- Add GenerateDocumentationFile and RepositoryType to .csproj

## 0.1.1 (2026-03-10)

- Fix README path in csproj so README displays on nuget.org

## 0.1.0 (2026-03-10)

- Initial release
- `UrlCleaner.RemoveTracking(string)` — remove tracking params from a URL string
- `UrlCleaner.RemoveTracking(Uri)` — remove tracking params from a `Uri`
- Built-in list: utm_*, fbclid, gclid, msclkid, mc_eid, ref, _ga, _gl
- Accepts additional params to remove via `additionalParams`
