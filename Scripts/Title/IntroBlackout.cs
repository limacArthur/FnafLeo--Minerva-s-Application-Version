using System;
using System.Diagnostics;
using Godot;

namespace FNAFLEOv2.Scripts.Title
{
    public partial class IntroBlackout : Sprite2D
    {
        private Tween tween;
        private Stopwatch stopwatch = new();
        public event Action OnFadeIn;
        public AudioStreamPlayer audio;

        public override async void _Ready()
        {
            audio = GetNode<AudioStreamPlayer>("../AudioStreamPlayer");
            audio.VolumeDb = -10f;
            EventBus.Instance.EmitSignal(EventBus.SignalName.TransitionOff);
            this.Modulate = new Color(1f, 1f, 1f, 1f);
            FadeOut(5.0f);
            stopwatch.Start();
            float timing = 5.0f;
            await ToSignal(GetTree().CreateTimer(timing), SceneTreeTimer.SignalName.Timeout);
            stopwatch.Stop();
            OnFadeIn?.Invoke();
            FadeIn(2.0f); 
        }

        public void FadeOut(float time)
        {
            tween?.Kill();
            tween = CreateTween();
            tween.TweenProperty(this, "modulate:a", 0f, time);
        }

        public void FadeIn(float time)
        {
            tween?.Kill();
            tween = CreateTween();
            tween.TweenProperty(this, "modulate:a", 1f, time);
            tween.Finished += () => { CallGame(); EventBus.Instance.EmitSignal(EventBus.SignalName.TransitionOn); };
        }

        void CallGame()
        {
            Error result = GetTree().ChangeSceneToFile("res://Scenes/Office.tscn");

            if (result != Error.Ok)
            {
                GD.PrintErr("Erro ao carregar a cena: " + result);
            }
        }
    }
}
