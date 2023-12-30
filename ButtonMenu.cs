using Godot;
using System;

public partial class ButtonMenu : MenuButton
{

	PopupMenu popupMenu;
	public override void _Ready()
	{
		GD.Print("ButtonMenu");
		popupMenu = GetPopup();
		popupMenu.Connect("index_pressed", Callable.From<int>(PopupIdPressed));
		popupMenu.SetItemChecked(0, Preferences.IsSoundEnabled);
		popupMenu.SetItemChecked(1, Preferences.IsStackSoundEnabled);
		popupMenu.SetItemChecked(2, Preferences.IsNCSoundEnabled);
		popupMenu.SetItemChecked(3, Preferences.IsBountySoundEnabled);
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
			case 3:
				Preferences.IsBountySoundEnabled = b;
				break;
			default:
				return;
		}

		SaveManager.Save();

	}
}
