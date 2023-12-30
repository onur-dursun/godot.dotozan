using Godot;
using System;

public partial class ButtonStart : Button
{
	public override void _Ready()
	{
		this.Pressed += ButtonPressed;
	}

	private new void ButtonPressed()
	{
		if(!int.TryParse(GetNode<LineEdit>("/root/Control/BoxContainer/VBoxContainer/BoxContainer/LineEditMin").Text, out int minutes)) return;
		if(!int.TryParse(GetNode<LineEdit>("/root/Control/BoxContainer/VBoxContainer/BoxContainer/LineEditSec").Text, out int seconds)) return;

		TimeManager.StartTimer(minutes * 60 + seconds);
	}
}
