using Godot;
using System;

public static class NotificationManager
{
	public static AudioStreamPlayer2D audioStreamPlayer;
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

	public Notification(string _log = "", string path = "")
	{
		soundPath = path;
		log = _log;
	}

	public void Notify()
	{
		if(!string.IsNullOrWhiteSpace(soundPath)){
			NotificationManager.audioStreamPlayer.Stream = (AudioStream)GD.Load(soundPath);
			NotificationManager.audioStreamPlayer.Play();
		}
		
		LabelLog.instance.LogNotification(log + " - " + TimeManager.GetFormattedTime());
		LabelLog.instance.UpdateLogLabel();

	}
}
