using Godot;
using System;

public partial class LabelTimer : Label
{
	string text;
	public override void _Process(double delta)
	{
		var time = TimeManager.GetFormattedTime();

		Text = time.minutes.ToString("D2") + ":" + time.seconds.ToString("D2");

		if (Text != text)
		{
			text = Text;
			Tick(time);
		}
	}

	void Tick(TimeInfo time)
	{
		if (Text == "00:00")
		{
			new Notification("Oyun başlıyor").Notify();
		}

		if (time.seconds == 40)
		{
			new Notification("Stack zamanı!", "res://Audio/stack.mp3").Notify();
		}

		if (time.seconds == 45 && time.minutes % 3 == 2)
		{
			new Notification("Lotus ve Bounty çıkıyo! 15 saniye!", "res://Audio/bounty.mp3").Notify();
		}

		if (time.minutes == 7 && time.seconds == 0)
		{
			new Notification("NC itemi lvl 1 çıktı!", "res://Audio/nc1.mp3", Preferences.IsNCSoundEnabled).Notify();
		}

		if (time.minutes == 17 && time.seconds == 0)
		{
			new Notification("NC itemi lvl 2 çıktı!", "res://Audio/nc2.mp3", Preferences.IsNCSoundEnabled).Notify();
		}

		if (time.minutes == 27 && time.seconds == 0)
		{
			new Notification("NC itemi lvl 3 çıktı!", "res://Audio/nc3.mp3", Preferences.IsNCSoundEnabled).Notify();
		}

		if (time.minutes == 37 && time.seconds == 0)
		{
			new Notification("NC itemi lvl 4 çıktı!", "res://Audio/nc4.mp3", Preferences.IsNCSoundEnabled).Notify();
		}

		if (time.minutes == 60 && time.seconds == 0)
		{
			new Notification("NC itemi lvl 5 çıktı!", "res://Audio/nc5.mp3", Preferences.IsNCSoundEnabled).Notify();
		}

		if (time.minutes == 19 && time.seconds == 30)
		{
			new Notification("Tormentor çıkıyo!", "res://Audio/tormentor.mp3").Notify();
		}

		if (time.minutes >= 5 && time.seconds == 45 && time.minutes % 2 == 1)
		{
			new Notification("Power rune çıkıyo!", "res://Audio/rune.mp3").Notify();
		}

		if (time.seconds == 45 && time.minutes % 10 == 4)
		{
			new Notification("Gece oluyo! Roshan yukarı çıkıyo!", "res://Audio/gece.mp3").Notify();
		}

		if (time.seconds == 45 && time.minutes % 10 == 9)
		{
			new Notification("Gündüz oluyo! Roshan aşağı iniyo!", "res://Audio/gündüz.mp3").Notify();
		}
	}

	private bool dragging = false;
	private Vector2 clickPos = new Vector2();

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton eventMouseButton)
		{
			if (eventMouseButton.ButtonIndex == MouseButton.Left && eventMouseButton.Pressed)
			{
				if (RectHasMouse(GetRect(), eventMouseButton.Position))
				{
					if (!dragging)
					{
						clickPos = GetLocalMousePosition();
						dragging = true;
					}
				}
			}

			if (dragging && !eventMouseButton.Pressed)
			{
				dragging = false;
			}
		}

		if (@event is InputEventMouseMotion eventMouseMotion && dragging)
		{
			GetViewport().GetWindow().Position += (Vector2I)(GetGlobalMousePosition() - clickPos - Position);
		}
	}

	// Helper method to check if a point is within a Rect2
	private bool RectHasMouse(Rect2 rect, Vector2 point)
	{
		return rect.HasPoint(point);
	}
}


