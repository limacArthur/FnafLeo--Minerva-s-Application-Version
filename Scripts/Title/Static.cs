using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Godot;

namespace FNAFLEOv2.Scripts.Title
{
    public partial class Static : Sprite2D
    {
        Stopwatch watch = new();
        VideoStreamPlayer video;
        int mark;

        public override void _Ready()
        {
            watch.Start();
            mark = (int)watch.ElapsedMilliseconds + 20;
            Visible = false;
            video = GetParent().GetNode<VideoStreamPlayer>("/root/TitleScreen/CanvasLayer/VideoStreamPlayer");
            video.Finished += OnVideoFinished;
        }

        public override void _Process(double delta)
        {
            

            if ((int)watch.ElapsedMilliseconds >= mark)
            {
                mark = (int)watch.ElapsedMilliseconds + 20;
                Frame++;
               
            }

            if (Frame > 30)
            {
                Frame = 0;
            }
            
        }

        void OnVideoFinished()
        {
            Visible = true;
        }
    }
}
