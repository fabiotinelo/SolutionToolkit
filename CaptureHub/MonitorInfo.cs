public class MonitorInfo
{
	public string Name { get; set; } = "";
	public string DeviceName { get; set; } = "";
	public bool Primary { get; set; }

	public override string ToString()
	{
		return Name;
	}
}
