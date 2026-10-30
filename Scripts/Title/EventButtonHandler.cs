using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace FNAFLEOv2.Scripts.Title
{
    public partial class EventButtonHandler : Button
    {
        [Export] public string eventName;
        [Export] public bool hideIfJustStarted = false;

        public void OnMouseEntered()
        {
            this.Modulate = new Color(2f, 2f, 2f);
        }

        public void OnMouseExited()
        {
            this.Modulate = new Color(0.5f, 0.5f, 0.5f);
        }

        public override void _Ready()
        {
            this.Pressed += OnButtonPressed;
            this.MouseEntered += OnMouseEntered;
            this.MouseExited += OnMouseExited;
            this.Modulate = new Color(0.5f, 0.5f, 0.5f);

            if (hideIfJustStarted)
            {
                if (Autoload.loadedData == null || Autoload.loadedData.maxNight == 1)
                {
                    Visible = false;
                }
                else
                {
                    Visible = true;
                }
            }
        }

        public void OnButtonPressed()
        {
            switch (eventName)
            {
                case "NewGame":
                    EventBus.Instance.EmitSignal(EventBus.SignalName.NewGameStarted);
                    break;
                case "Continue":
                    EventBus.Instance.EmitSignal(EventBus.SignalName.ContinueGame);
                    break;
                default:
                    GD.PrintErr($"Unknown event name: {eventName}");
                    break;
            }
        }
    }
}
