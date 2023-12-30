using Godot;
using System;

public partial class LabelTimer : Label
{
	string text;
	public override void _Process(double delta)
	{
		Text = TimeManager.GetFormattedTime();

		if(Text!=text)
		{
			text = Text;
			Tick();
		}
	}

	void Tick()
	{
		if(Text == "00:01")
		{
			new Notification("Oyun başlıyor").Notify();
		}

		if(Text == "00:03")
		{
			new Notification("Oyun başlıyor").Notify();
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


