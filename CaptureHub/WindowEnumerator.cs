using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

public static class WindowEnumerator
{
	private delegate bool EnumWindowsProc(
		IntPtr hWnd,
		IntPtr lParam);

	[DllImport("user32.dll")]
	private static extern bool EnumWindows(
		EnumWindowsProc lpEnumFunc,
		IntPtr lParam);

	[DllImport("user32.dll")]
	private static extern int GetWindowText(
		IntPtr hWnd,
		StringBuilder lpString,
		int nMaxCount);

	[DllImport("user32.dll")]
	private static extern int GetWindowTextLength(
		IntPtr hWnd);

	[DllImport("user32.dll")]
	private static extern bool IsWindowVisible(
		IntPtr hWnd);

	public static List<WindowInfo> GetOpenWindows()
	{
		var windows = new List<WindowInfo>();

		EnumWindows((hWnd, lParam) =>
		{
			if (!IsWindowVisible(hWnd))
				return true;

			int length = GetWindowTextLength(hWnd);

			if (length == 0)
				return true;

			var builder = new StringBuilder(length + 1);
			GetWindowText(hWnd, builder, builder.Capacity);

			string title = builder.ToString().Trim();

			if (string.IsNullOrWhiteSpace(title))
				return true;

			windows.Add(new WindowInfo
			{
				Handle = hWnd,
				Title = title
			});

			return true;
		}, IntPtr.Zero);

		windows = windows
			.OrderBy(w => w.Title).ToList();

		windows.Insert(0, new WindowInfo
		{
			Handle = IntPtr.Zero,
			Title = "Tela Inteira"
		});

		return windows;
			
	}
}