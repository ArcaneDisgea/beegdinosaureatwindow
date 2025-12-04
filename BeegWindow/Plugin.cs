using BeegWindow.Utilities;
using Dalamud.IoC;
using Dalamud.Plugin.Services;
using Dalamud.Plugin;
using System.Diagnostics;

namespace BeegWindow;

public sealed class Plugin : IDalamudPlugin
{
    private IDalamudPluginInterface PluginInterface { get; init; }
    [PluginService] internal static IPluginLog Log { get; private set; } = null!;

    public Plugin(IDalamudPluginInterface pluginInterface)
    {
        PluginInterface = pluginInterface;

        var GameWindow = Process.GetCurrentProcess().MainWindowHandle;
        if (!Native.IsWindowMaximized(GameWindow))
        {
            Log.Info("Window not maximized; Maximizing!");
            Native.Maximize(GameWindow);
        } else
        {
            Log.Info("Window already maximized.");
        }
    }

    public void Dispose()
    {

    }
}
