# 开发者文档

## itch.io

### 推送到 itch.io 的 butler 指令

Game Release

``` cmd
butler push --ignore .gdignore --ignore CodeCoverage --ignore "*.TestPlatform.*" --ignore "xunit.*" --ignore "testhost.*" --ignore "*.CodeCoverage.*" --ignore "*.CodeAnalysis.*" --ignore "InstrumentationEngine" --ignore "ThirdPartyNotices.txt" --ignore "*.VisualStudio.TraceDataCollector.*" --dry-run "Temp/Exports" lightyears1998/cmsgame:windows-64
```

Assets

``` cmd
butler push --ignore .gdignore --ignore "*.import" --ignore "*~" --dry-run "Assets" lightyears1998/cmsgame:assets
```

对于 Assets， 可以考虑使用 `rsync` 等软件进行增量资源管理。

``` cmd
rsync -avi --dry-run a/ b
``` 
