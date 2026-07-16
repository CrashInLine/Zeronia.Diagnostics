[![NuGet](https://img.shields.io/nuget/v/Zeronia.Diagnostics.svg)](https://www.nuget.org/packages/Zeronia.Diagnostics/)

# Zeronia.Diagnostics

简体中文说明：

Zeronia.Diagnostics 是 Avalonia 诊断工具的历史归档，记录了从 Avalonia 11 时代的内嵌 DevTools 到 Avalonia 12+ 推荐迁移方案的说明。本仓库用于参考旧版实现和迁移步骤，不再用于发布新功能。

主要内容
- 说明如何从旧的 `Avalonia.Diagnostics` 迁移到新版诊断支持（AvaloniaUI.DiagnosticsSupport）和独立的 Developer Tools。
- 提供在应用中启用开发者工具的示例代码。

快速迁移指南

1. 从项目移除旧包（如存在）：

```powershell
dotnet remove package Avalonia.Diagnostics
```

2. 安装新的诊断支持包（运行时依赖）：

```powershell
dotnet add package AvaloniaUI.DiagnosticsSupport
```

3. 安装独立的 Developer Tools（可选，全局工具）：

```powershell
dotnet tool install --global AvaloniaUI.DeveloperTools
```

4. 在应用中启用（通常在 DEBUG 下）：

```csharp
public override void Initialize()
{
    AvaloniaXamlLoader.Load(this);
#if DEBUG
    this.AttachDeveloperTools();
#endif
}
```

5. 启动应用并按 F12 打开 Developer Tools（或运行已安装的独立工具）。

更多信息
- 官方文档：https://docs.avaloniaui.net/tools/developer-tools/installation

贡献与历史
- 本仓库保留旧版实现以供参考。若需迁移帮助或提交改进建议，请打开 issue 或发起 PR。

许可证
- 本项目遵循 MIT 许可证。详情见 LICENSE 文件。

如需针对特定版本或迁移场景的帮助，请在仓库中发起 issue，描述你的 Avalonia 版本和使用场景。
