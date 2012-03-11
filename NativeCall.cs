using System;
using System.Runtime.InteropServices;

namespace WindowController
{
	[System.Security.SuppressUnmanagedCodeSecurity()]
	internal sealed class NativeCall
	{
		internal static bool IsWindowInForeground(IntPtr hWnd)
		{
			return hWnd == GetForegroundWindow();
		}

		internal enum WindowShowStyle : uint
		{
			Hide = 0,
			ShowNormal = 1,
			ShowMinimized = 2,
			ShowMaximized = 3,
			Maximize = 3,
			ShowNormalNoActivate = 4,
			Show = 5,
			Minimize = 6,
			ShowMinNoActivate = 7,
			ShowNoActivate = 8,
			Restore = 9,
			ShowDefault = 10,
			ForceMinimized = 11
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct POINT
		{
			public int X;
			public int Y;

			public POINT(int x, int y)
			{
				this.X = x;
				this.Y = y;
			}

			public static implicit operator System.Drawing.Point(POINT p)
			{
				return new System.Drawing.Point(p.X, p.Y);
			}

			public static implicit operator POINT(System.Drawing.Point p)
			{
				return new POINT(p.X, p.Y);
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		internal struct RECT
		{
			public int left, top, right, bottom;
		}

		[DllImport("user32.dll")]
		internal static extern bool ShowWindow(IntPtr hWnd, WindowShowStyle nCmdShow);

		[DllImport("user32.dll")]
		internal static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool IsIconic(IntPtr hWnd);

		[DllImport("user32.dll")]
		internal static extern bool GetClientRect(IntPtr hwnd, out RECT lpRect);

		[DllImport("user32.dll")]
		internal static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

		[DllImport("user32.dll")]
		internal static extern bool ClientToScreen(IntPtr hwnd, out POINT lpPoint);
	}
}
