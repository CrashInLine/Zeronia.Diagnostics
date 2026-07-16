[![NuGet](https://img.shields.io/nuget/v/Zeronia.Diagnostics.svg)](https://www.nuget.org/packages/Zeronia.Diagnostics/)

# Zeronia.Diagnostics

中文（简体）

Zeronia.Diagnostics 是一个轻量的兼容包，用于在 Avalonia v12 中继续使用旧版 Avalonia.Diagnostics 的功能。此包并非对原项目的完整复刻，而是提供最小的迁移/兼容层，方便在 Avalonia 12 环境中快速启用调试窗口（DevTools）。如果需要在 Avalonia v12 中使用 Avalonia.Diagnostics 的体验，可以使用本包。

快速安装（NuGet）

```powershell
dotnet add package Zeronia.Diagnostics
```

在应用中启用（示例）：

```csharp
public override void Initialize()
{
    AvaloniaXamlLoader.Load(this);
#if DEBUG
    this.AttachDeveloperTools(); // 保留与旧版相同的调用方式
#endif
}
```

说明与建议
- 本包旨在简化从 Avalonia.Diagnostics 到 Avalonia v12 的迁移，并在大多数常见场景下提供兼容性。
- 对于最新、完整的诊断体验，仍推荐使用官方的 Runtime 支持包和独立 Developer Tools：
  - AvaloniaUI.DiagnosticsSupport（运行时支持）
  - AvaloniaUI.DeveloperTools（独立工具）
- 若遇到兼容性问题或需要特定功能，请在仓库中创建 issue 说明你的 Avalonia 版本和使用场景。

License: MIT（详见 LICENSE 文件）

---

English

Zeronia.Diagnostics is a lightweight compatibility package that lets you continue using the legacy Avalonia.Diagnostics experience on Avalonia v12. It provides a minimal migration/compat layer so you can quickly enable the in-process DevTools window in a v12 environment. This package is intended for users who want to keep using Avalonia.Diagnostics behavior on v12.

Quick install (NuGet)

```powershell
dotnet add package Zeronia.Diagnostics
```

Enable in your application (example):

```csharp
public override void Initialize()
{
    AvaloniaXamlLoader.Load(this);
#if DEBUG
    this.AttachDeveloperTools(); // same call pattern as the legacy package
#endif
}
```

Notes & recommendations
- This package aims to ease migration and provide compatibility for common scenarios; it is not a full reimplementation of the original project.
- For the most complete and up-to-date diagnostics experience, prefer the official packages:
  - AvaloniaUI.DiagnosticsSupport (runtime support)
  - AvaloniaUI.DeveloperTools (standalone tool)
- If you encounter compatibility issues or need specific features, please open an issue with your Avalonia version and usage details.

License: MIT (see LICENSE)
