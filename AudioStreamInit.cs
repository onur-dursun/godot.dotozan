using Godot;
using System;

public partial class AudioStreamInit : AudioStreamPlayer2D
{
	public override void _Ready()
	{
		NotificationManager.audioStreamPlayer = this;	
	}
}
