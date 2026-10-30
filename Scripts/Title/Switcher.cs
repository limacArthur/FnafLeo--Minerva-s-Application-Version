using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace FNAFLEOv2.Scripts.Title
{
    public partial class Switcher : AnimatedSprite2D
    {
        int mark;

        
        Tween tween;
        Random random;
        Stopwatch Stopwatch = new();
        VideoStreamPlayer video;
        public override void _Ready()
        {

            mark = (int)Stopwatch.ElapsedMilliseconds + 6000;
            video = GetNode<VideoStreamPlayer>("/root/TitleScreen/CanvasLayer/VideoStreamPlayer");
            video.Finished += OnFinished;
            Frame = 0;
            Visible = false;
            random = new Random();
            this.Modulate = new Color(0.3f, 0.3f, 0.3f);
        }
        public override void _Process(double delta)
        {
            if ((int)Stopwatch.ElapsedMilliseconds >= mark)
            {
                mark = (int)Stopwatch.ElapsedMilliseconds + random.Next(8000, 9000);
                Switch();
            }

        }

        public void Switch()
        {
            Oscilate(1f, 30);
            tween.Finished += ChangeFrame;
        }


        void OnFinished()
        {
            Visible = true;
            Stopwatch.Start();
        }

        public void Oscilate(float duration = 0.5f, int times = 3)
        {
            
            tween?.Kill();
            tween = CreateTween();

            
            for (int i = 0; i < times; i++)
            {
                tween.TweenProperty(this, "modulate:a", 0.0f, duration / (times * 2)); 
                tween.TweenProperty(this, "modulate:a", 1.0f, duration / (times * 2)); 
            }
            
        }

        void ChangeFrame()
        {
            int oldFrame = Frame;
            Frame = random.Next(0, 6);

            if (Frame == oldFrame)
            {
                ChangeFrame();
            }
        }
    }
}
