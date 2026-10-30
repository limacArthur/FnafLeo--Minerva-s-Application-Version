using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace FNAFLEOv2.Scripts.Title
{
    public partial class Blackout : Sprite2D
    {
        AudioStreamPlayer audio;
        AudioStreamPlayer music;
        public override void _Ready()
        {
            Visible = false;
            if (EventBus.Instance != null)
            { 
                EventBus.Instance.BlackoutCalled += OnBlackoutCalled;
                EventBus.Instance.NewGameStarted += OnNewGameStarted;
                EventBus.Instance.ContinueGame += OnGameStarted;
            }

            audio = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
            music = GetParent().GetNode<AudioStreamPlayer>("AudioStreamPlayer");
        }

        private void OnNewGameStarted()
        {
            Autoload.loadedData.maxNight = 1;
            Autoload.loadedData.night = 1;
            OnBlackoutCalled();
            GD.Print("New Game Started, Night: " + Autoload.loadedData.night);
        }


        private void OnGameStarted() {
            OnBlackoutCalled();
            GD.Print("Game Started, Night: " + Autoload.loadedData.night);
        }

        private void OnBlackoutCalled()
        {
            Visible = true;
            audio.Play();
            FadeOut();
        }

        void FadeOut()         {
            var tween = CreateTween();
            tween.TweenProperty(music, "volume_db", -80f, 10f);
            tween.Finished += () => {
                CallIntro();
            };
        }

        void CallIntro()
        {
            EventBus.Instance.EmitSignal(EventBus.SignalName.TransitionOn);
            Error result = GetTree().ChangeSceneToFile("res://Scenes/Intro.tscn");

            if (result != Error.Ok)
            {
                GD.PrintErr("Erro ao carregar a cena: " + result);
            }
        }
    }
}
