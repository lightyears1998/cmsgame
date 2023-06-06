# 开发者文档

## itch.io

Game Release

``` cmd
butler push --ignore .gdignore --ignore CodeCoverage --ignore "*.TestPlatform.*" --ignore "xunit.*" --ignore "testhost.*" --ignore "*.CodeCoverage.*" --ignore "*.CodeAnalysis.*" --ignore "InstrumentationEngine" --ignore "ThirdPartyNotices.txt" --ignore "*.VisualStudio.TraceDataCollector.*" --dry-run "Temp/Exports" lightyears1998/cmsgame:windows-64
```

Assets

``` cmd
butler push --ignore .gdignore --ignore "*.import" --dry-run "Assets" lightyears1998/cmsgame:assets
```
