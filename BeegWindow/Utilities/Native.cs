using System;
using System.Runtime.InteropServices;

namespace BeegWindow.Utilities;

internal class Native
{
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPLACEMENT
    {
        public int length;
        public int flags;
        public int showCmd;
        public System.Drawing.Point ptMinPosition;
        public System.Drawing.Point ptMaxPosition;
        public System.Drawing.Rectangle rcNormalPosition;
    }

    private const int SW_SHOWMAXIMIZED = 3;

    public static bool IsWindowMaximized(IntPtr hWnd)
    {
        WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
        placement.length = Marshal.SizeOf(placement);
        GetWindowPlacement(hWnd, ref placement);
        return placement.showCmd == SW_SHOWMAXIMIZED;
    }

    public static void Maximize(IntPtr hWnd)
    {
        ShowWindow(hWnd, SW_SHOWMAXIMIZED);        
    }
}