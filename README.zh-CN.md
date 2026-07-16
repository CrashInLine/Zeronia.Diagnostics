[![NuGet](https://img.shields.io/nuget/v/Zeronia.Diagnostics.svg)](https://www.nuget.org/packages/Zeronia.Diagnostics/)

# Zeronia.Diagnostics

[English](README.md) | 简体中文

`Zeronia.Diagnostics` 是将原本的`Avalonia.Diagnostics`简单迁移到[Avalonia](https://github.com/AvaloniaUI/Avalonia) 12版本，用于在 v12 中继续使用旧版 Avalonia.Diagnostics 的功能。如果需要在 Avalonia v12 中使用 `Avalonia.Diagnostics`, 可以使用本包。

## 快速开始

1. 移除原来的 `Avalonia.Diagnostic` 包:

```shell
dotnet remove package Avaloia.Diagnostics
```

2. 安装 `Zeronia.Diagnostics` 包
```shell
dotnet add package Zeronia.Diagnostics
```

3. 在你的 `.csproj` 文件中添加如下条件引用

```xml
<ItemGroup>
  ...
  <PackageReference Include="Zeronia.Diagnostics">
    <IncludeAssets Condition="'$(Configuration)' != 'Debug'">None</IncludeAssets>
    <PrivateAssets Condition="'$(Configuration)' != 'Debug'">All</PrivateAssets>
  </PackageReference>
  ...
</ItemGroup>
```

4. 接下来只需要在运行的窗口下按 **F12** 就可以唤出`Dev Tool`窗口.

## 说明与建议
- 本包只是简单的将 `Avalonia.Diagnostics` 迁移到 Avalonia v12, 用于应急.
- 对于最新、完整的诊断体验，仍推荐使用官方的 [Developer Tools](https://docs.avaloniaui.net/tools/developer-tools/installation)
- 若遇到兼容性问题或需要特定功能，请在仓库中创建 issue 说明你的 Avalonia 版本和使用场景。

## 许可
本项目根据 [MIT License](LICENSE)