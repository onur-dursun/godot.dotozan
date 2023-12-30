using Godot;
using System;
using System.Collections.Generic;

public static class NotificationManager
{
	public static AudioStreamPlayer2D audioStreamPlayer;
	
	public static Queue<string> paths = new Queue<string>();
}

public interface NotificationStrategy
{
	void Notify();
}

// Example notification strategy: SoundNotification
public class Notification : NotificationStrategy
{
	private string soundPath;
	private string log;
	private bool isAudioEnabled;

	public Notification(string log = "", string soundPath = "", bool isAudioEnabled = true)
	{
		this.soundPath = soundPath;
		this.log = log;
		this.isAudioEnabled = isAudioEnabled;
	}


	public void Notify()
	{
		if(isAudioEnabled && Preferences.IsSoundEnabled && !string.IsNullOrWhiteSpace(soundPath)){
			NotificationManager.paths.Enqueue(soundPath);
		}
		
		LabelLog.instance.LogNotification(log + " - " + TimeManager.GetFormattedTimeString());
		LabelLog.instance.UpdateLogLabel();
	}
}
