using Godot;
using System;
using System.Collections.Generic;

public partial class LabelLog : Label
{
	
	private List<string> notificationLog = new List<string>();
	
	public static LabelLog instance;
	public override void _Ready()
	{
		instance = this;
	}

	// Method to log a notification
	public void LogNotification(string notification)
	{
		notificationLog.Add(notification);

		// Keep only the last 3 notifications
		if (notificationLog.Count > 3)
		{
			notificationLog.RemoveAt(0);
		}
	}

	// Method to update the label with the last 3 notifications
	public void UpdateLogLabel()
	{
		Text = string.Join("\n", notificationLog);
	}
}
