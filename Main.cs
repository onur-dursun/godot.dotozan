using Godot;
using System;

//TODO: Add pause funtion

public partial class Main : Control
{
	Vector2I click_pos = Vector2I.Zero;

	public Main()
	{
		LoadManager.Load();
	}
	// Called when the node enters the scene tree for the first time.

	public override void _Ready()
	{
		GetTree().Root.GetWindow().TransparentBg = true;
		//GetTree().Root.GetWindow().MinSize = Vector2I.Zero;
		DisplayServer.WindowSetMinSize(Vector2I.Zero);
		DisplayServer.WindowSetSize(new Vector2I(70, 120));
		DisplayServer.WindowSetPosition(Preferences.WindowPosition);

		//DisplayServer.WindowSetMousePassthrough(new Vector2[]{});
	}

	public override void _Notification(int what)
	{
		if (what == NotificationWMCloseRequest)
		{
			Preferences.WindowPosition = DisplayServer.WindowGetPosition();
			SaveManager.Save();
		}
	}

}
