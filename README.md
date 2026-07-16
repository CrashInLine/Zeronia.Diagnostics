[![NuGet](https://img.shields.io/nuget/v/Zeronia.Diagnostics.svg)](https://www.nuget.org/packages/Zeronia.Diagnostics/)

# Zeronia.Diagnostics

English | [简体中文](README.zh-CN.md)

`Zeronia.Diagnostics` is a simple migration of the original `Avalonia.Diagnostics` to [Avalonia](https://github.com/AvaloniaUI/Avalonia) version 12, allowing you to continue using the classic Avalonia.Diagnostics functionality in v12. If you need to use `Avalonia.Diagnostics` in Avalonia v12, this package is for you.

## Quick Start

1. Remove the original `Avalonia.Diagnostics` package:

```shell
dotnet remove package Avalonia.Diagnostics
```

2. Install the `Zeronia.Diagnostics` package:

```shell
dotnet add package Zeronia.Diagnostics
```

3. Add the following conditional reference to your `.csproj` file:

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

4. Then simply press **F12** while your application window is focused to bring up the Dev Tools window.

## Notes and Recommendations

- This package is a straightforward migration of Avalonia.Diagnostics to Avalonia v12, intended as a temporary stopgap solution.

- For the latest and most complete diagnostic experience, we still recommend the official Developer Tools.

- If you encounter compatibility issues or need specific features, please open an issue in this repository with your Avalonia version and usage scenario.

## License
This project is licensed under the [MIT License](LICENSE).
