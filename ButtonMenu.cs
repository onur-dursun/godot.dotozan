using Godot;
using System;

public partial class ButtonMenu : MenuButton
{

	PopupMenu popupMenu;
	public override void _Ready()
	{
		popupMenu = GetPopup();
		popupMenu.Connect("index_pressed", Callable.From<int>(PopupIdPressed));
	}

	private void PopupIdPressed(int index)
	{
		popupMenu.ToggleItemChecked(index);
		bool b = popupMenu.IsItemChecked(index);

		switch (index)
		{
			case 0:
				Preferences.IsSoundEnabled = b;
				break;
			case 1:
				Preferences.IsStackSoundEnabled = b;
				break;
			case 2:
				Preferences.IsNCSoundEnabled = b;
				break;
			default:
				return;
		}
	}
}
