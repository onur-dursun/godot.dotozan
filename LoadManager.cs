using System;
using Godot;

public static class LoadManager
{
    public static void Load()
    {
        ConfigFile config = new ConfigFile();

        // Load data from a file.
        Error err = config.Load("user://settings.cfg");

        // If the file didn't load, ignore it.
        if (err != Error.Ok)
        {
            return;
        }

        // Iterate over all sections.
        foreach (String settings in config.GetSections())
        {
            // Fetch the data for each section.
            Preferences.IsSoundEnabled = (bool)config.GetValue(settings, nameof(Preferences.IsSoundEnabled));
            Preferences.IsStackSoundEnabled = (bool)config.GetValue(settings, nameof(Preferences.IsStackSoundEnabled));
            Preferences.IsNCSoundEnabled = (bool)config.GetValue(settings, nameof(Preferences.IsNCSoundEnabled));
            Preferences.IsBountySoundEnabled = (bool)config.GetValue(settings, nameof(Preferences.IsBountySoundEnabled));
            Preferences.WindowPosition = (Vector2I)config.GetValue(settings, nameof(Preferences.WindowPosition));
        }

        GD.Print("load");
    }
}