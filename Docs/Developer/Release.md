# Release

## 游戏发布：itch.io

将游戏发布在 itch.io 时，主要使用 itch.io 的官方制作的工具程序 [`butler`](https://itch.io/docs/butler/)。该程序可以通过 itch App 安装。

``` sh
# 将游戏推送到 itch.io
butler push --ignore .gdignore --ignore CodeCoverage --ignore "*.TestPlatform.*" --ignore "xunit.*" --ignore "testhost.*" --ignore "*.CodeCoverage.*" --ignore "*.CodeAnalysis.*" --ignore "InstrumentationEngine" --ignore "ThirdPartyNotices.txt" --ignore "*.VisualStudio.TraceDataCollector.*" --dry-run "Temp/Exports" lightyears1998/cmsgame:windows-64
```
