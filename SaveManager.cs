// Create new ConfigFile object.
using Godot;

public static class SaveManager
{
    public static void Save()
    {
        var config = new ConfigFile();

        // Store some values.
        config.SetValue("Settings", nameof(Preferences.IsSoundEnabled), Preferences.IsSoundEnabled);
        config.SetValue("Settings", nameof(Preferences.IsStackSoundEnabled), Preferences.IsStackSoundEnabled);
        config.SetValue("Settings", nameof(Preferences.IsNCSoundEnabled), Preferences.IsNCSoundEnabled);
        config.SetValue("Settings", nameof(Preferences.IsBountySoundEnabled), Preferences.IsBountySoundEnabled);
        config.SetValue("Settings", nameof(Preferences.WindowPosition), Preferences.WindowPosition);

        // Save it to a file (overwrite if already exists).
        config.Save("user://settings.cfg");

        GD.Print("save");
    }
}

