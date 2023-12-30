using Godot;
using System;

public partial class AudioStreamInit : AudioStreamPlayer2D
{
	public override void _Ready()
	{
		NotificationManager.audioStreamPlayer = this;	
	}

    public override void _Process(double delta)
    {
      	if(!Playing && NotificationManager.paths.Count > 0)
		{
			var path = NotificationManager.paths.Dequeue();
			
			Stream = (AudioStream)GD.Load(path);
			Play();
		}
    }
}
