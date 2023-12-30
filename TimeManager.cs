using Godot;
using System;

public static class TimeManager
{

	public static ulong startTime;
	public static ulong currentTime;

	public static void StartTimer()
	{
		startTime = Time.GetTicksMsec();
	}

	public static void StartTimer(int time)
	{
		startTime =  (ulong)(time * -1000) + Time.GetTicksMsec();
	}

	public static int GetElapsedTimeMsec()
	{
		return (int)(Time.GetTicksMsec() - startTime);
	}


	public static string GetFormattedTime()
	{
		TimeSpan timeSpan = TimeSpan.FromMilliseconds(GetElapsedTimeMsec());

		return $"{(int)timeSpan.TotalMinutes:D2}:{timeSpan.Seconds:D2}";
	}
}
