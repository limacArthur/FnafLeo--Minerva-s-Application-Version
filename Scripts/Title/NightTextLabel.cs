using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using System.Text;
using System.Threading.Tasks;

namespace FNAFLEOv2.Scripts.Title
{
    public partial class NightTextLabel : Label
    {

        public override void _Ready()
        {
            
            if (Autoload.loadedData != null)
            {
                Text = $"Night {Autoload.loadedData.maxNight}\n12:00 AM";
                GD.Print("NightTextLabel: Night " + Autoload.loadedData.maxNight);
            }
            else
            {
                Text = "Night 1\n12:00 AM";
            }
            Position = new Vector2(576 - Size.X / 2, 324 - Size.Y / 2);
        }
    }
}
