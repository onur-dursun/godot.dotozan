using Godot;
using System;

public partial class ButtonClose : Button
{
	public override void _Ready()
	{
		this.Pressed += ButtonPressed;
	}

	private new void ButtonPressed()
	{
		GetTree().Quit();
		GetTree().Root.PropagateNotification((int)NotificationWMCloseRequest);
	}
}


