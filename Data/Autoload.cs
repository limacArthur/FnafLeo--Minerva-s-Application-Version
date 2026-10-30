using System;
using System.IO;
using System.Text.Json;
using Godot;

namespace FNAFLEOv2
{
    
    public class Data
    {
        public int? night { get; set; }
        public int? maxNight { get; set; }
    }

    public partial class Autoload : Node
    {
        public static Data loadedData;

        
        string path = ProjectSettings.GlobalizePath("user://save.json");
        public Data data;

        public override void _Ready()
        {
            Load();
            GD.Print();
            GD.Print("FNAFLEO v2.0.1");
            GD.Print("Copyright 2026, Brasil.\nAll game rights reserved for Arthur Lima and Leonardo Bocayuva." +
                     "\nMade by Arthur Lima.\n\nMade with Godot Engine 4.\nThis is a free game. Don't sell it.\nOriginal " +
                     "franchise rights reserved to Scott Cawthon.\n" + "Share only with permission.");
        }

        public void Save()
        {
            if (data == null)
            {
                data = new Data();
            }

            if (data.maxNight == null || data.maxNight == 0)
            {
                data.maxNight = 1;
            }

            if (data.night == null)
            {
                data.night = data.maxNight;
            }

            string DataString = JsonSerializer.Serialize(data);
            string directory = Path.GetDirectoryName(path);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllText(path, DataString);

            loadedData = data;

            GD.Print("Saved successfully");
            GD.Print("Night: " + data.night);
            GD.Print("Max Night: " + data.maxNight);
        }

        public void Load()
        {
            if (File.Exists(path))
            {
                string DataString = File.ReadAllText(path);
                data = JsonSerializer.Deserialize<Data>(DataString);

                GD.Print("Loaded successfully");
            }
            else
            {
                GD.Print("Save file not found, creating new save file");
                Save();
            }

            loadedData = data;
            GD.Print("Night: " + loadedData.night);
            GD.Print("Max Night: " + loadedData.maxNight);
        }
    }
}
