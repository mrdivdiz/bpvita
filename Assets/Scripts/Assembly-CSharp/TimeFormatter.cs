using System;
using System.Text;

public static class TimeFormatter
{
	public static string Format2Minutes(TimeSpan time)
	{
		TimeFormatter.sb.Remove(0, TimeFormatter.sb.Length);
		if (time.Hours > 1)
		{
			TimeFormatter.sb.Append(time.Hours);
			TimeFormatter.sb.Append(' ');
			TimeFormatter.sb.Append(TimeFormatter.hours);
			TimeFormatter.sb.Append(' ');
		}
		else if (time.Hours > 0)
		{
			TimeFormatter.sb.Append(time.Hours);
			TimeFormatter.sb.Append(' ');
			TimeFormatter.sb.Append(TimeFormatter.hour);
			TimeFormatter.sb.Append(' ');
		}
		if (time.Minutes > 1)
		{
			TimeFormatter.sb.Append(time.Minutes);
			TimeFormatter.sb.Append(' ');
			TimeFormatter.sb.Append(TimeFormatter.minutes);
		}
		else if (time.Minutes > 0)
		{
			TimeFormatter.sb.Append(time.Minutes);
			TimeFormatter.sb.Append(' ');
			TimeFormatter.sb.Append(TimeFormatter.minute);
		}
		return TimeFormatter.sb.ToString();
	}

	public static string Format2Seconds(TimeSpan time)
	{
		TimeFormatter.sb.Remove(0, TimeFormatter.sb.Length);
		if (time.Hours > 1)
		{
			TimeFormatter.sb.Append(time.Hours);
			TimeFormatter.sb.Append(' ');
			TimeFormatter.sb.Append(TimeFormatter.hours);
			TimeFormatter.sb.Append(' ');
		}
		else if (time.Hours > 0)
		{
			TimeFormatter.sb.Append(time.Hours);
			TimeFormatter.sb.Append(' ');
			TimeFormatter.sb.Append(TimeFormatter.hour);
			TimeFormatter.sb.Append(' ');
		}
		if (time.Minutes > 1)
		{
			TimeFormatter.sb.Append(time.Minutes);
			TimeFormatter.sb.Append(' ');
			TimeFormatter.sb.Append(TimeFormatter.minutes);
			TimeFormatter.sb.Append(' ');
		}
		else if (time.Minutes > 0)
		{
			TimeFormatter.sb.Append(time.Minutes);
			TimeFormatter.sb.Append(' ');
			TimeFormatter.sb.Append(TimeFormatter.minute);
			TimeFormatter.sb.Append(' ');
		}
		if (time.Seconds > 1)
		{
			TimeFormatter.sb.Append(time.Seconds);
			TimeFormatter.sb.Append(' ');
			TimeFormatter.sb.Append(TimeFormatter.seconds);
		}
		else
		{
			TimeFormatter.sb.Append(time.Seconds);
			TimeFormatter.sb.Append(' ');
			TimeFormatter.sb.Append(TimeFormatter.second);
		}
		return TimeFormatter.sb.ToString();
	}

	private static StringBuilder sb = new StringBuilder();

	private static string hour = Singleton<Localizer>.Instance.Resolve("COMMON_HOUR", null).translation;

	private static string hours = Singleton<Localizer>.Instance.Resolve("COMMON_HOURS", null).translation;

	private static string minute = Singleton<Localizer>.Instance.Resolve("COMMON_MINUTE", null).translation;

	private static string minutes = Singleton<Localizer>.Instance.Resolve("COMMON_MINUTES", null).translation;

	private static string second = Singleton<Localizer>.Instance.Resolve("COMMON_SECOND", null).translation;

	private static string seconds = Singleton<Localizer>.Instance.Resolve("COMMON_SECONDS", null).translation;
}
