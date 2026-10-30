using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace FNAFLEOv2.Scripts.Title
{
    public partial class Splash : VideoStreamPlayer
    {
        public override void _Ready()
        {
            Finished += OnVideoFinished;
        }

        private void OnVideoFinished()
        {
            
            this.Visible = false;
            QueueFree();
        }
    }
}
