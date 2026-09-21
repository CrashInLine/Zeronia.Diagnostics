using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using JetBrains.Rider.PathLocator;

namespace Avalonia.Diagnostics;

internal static class RiderXamlHelper
{
    private static RiderPathLocator.RiderInfo? _riderInfo;
    private static string RiderPath
    {
        get
        {
            if (_riderInfo is not null) return _riderInfo.Value.Path;
            var _locator = new RiderPathLocator(new RiderLocatorEnvironment());
            var rider = _locator.GetAllRiderPaths()
                .Where(r => IsRider(r.Path))
                .OrderByDescending(r => r.BuildNumber)
                .FirstOrDefault();
            _riderInfo = rider;
            Installed = rider.Path != string.Empty;

            return _riderInfo.Value.Path;
        }
    }

    private static bool IsRider(string path)
    {
        if (string.IsNullOrEmpty(path) || path.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            return false;

        return Path.GetFileName(path).StartsWith("rider", StringComparison.OrdinalIgnoreCase);
    }

    public static bool Installed { get; set; }

    public static void NavigateToXamlSource(int lineNumber, int columnNumber, string? filePath)
    {
        if (filePath is null || RiderPath == string.Empty || !Installed) return;
        var arguments = $"--line {lineNumber} --column {columnNumber} {filePath}";

        Process.Start(new ProcessStartInfo(RiderPath, arguments));
    }
}

internal class RiderLocatorEnvironment : IRiderLocatorEnvironment
{
    public T FromJson<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json) ?? throw new InvalidOperationException();
    }

    public void Info(string message, Exception e = null) { }
    public void Warn(string message, Exception e = null) { }
    public void Error(string message, Exception e = null) { }
    public void Verbose(string message, Exception e = null) { }
    public OS CurrentOS => GetOS();

    private static OS GetOS()
    {
        if (OperatingSystem.IsWindows()) return OS.Windows;
        return OperatingSystem.IsLinux() ? OS.Linux : OS.MacOSX;
    }
}