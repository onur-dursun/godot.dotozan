using Godot;
using System;

public partial class ButtonPause : Button
{
	public override void _Ready()
	{
		this.Pressed += ButtonPressed;
	}

	private new void ButtonPressed()
	{
		//TODO: Add lock and pause.
	}
}
