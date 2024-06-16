using Dalamud.IoC;
using Dalamud.Plugin;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System;

namespace BeegWindow;

public sealed class Plugin : IDalamudPlugin
{
    private DalamudPluginInterface PluginInterface { get; init; }

    public Plugin(
        [RequiredVersion("1.0")] DalamudPluginInterface pluginInterface)
    {
        PluginInterface = pluginInterface;

        var GameWindow = Process.GetCurrentProcess().MainWindowHandle;
        ShowWindow(GameWindow, SW_SHOWMAXIMIZED);
    }

    public void Dispose()
    {

    }

    private const int SW_SHOWMAXIMIZED = 3;

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
}
