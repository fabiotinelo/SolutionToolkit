using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

public class WindowInfo
{
	public IntPtr Handle { get; set; }
	public string Title { get; set; } = "";

	public override string ToString()
	{
		return Title;
	}
}