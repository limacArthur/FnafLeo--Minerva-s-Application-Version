using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNAFLEOv2.Scripts.Tech
{
    public partial class Transition : Sprite2D
    {
        

        public override void _Ready()
        {
            Visible = false;
            EventBus.Instance.TransitionOff += OnTransitionOff;
            EventBus.Instance.TransitionOn += OnTransitionOn;
        }

        public void OnTransitionOn()
        {
            Visible = true;
        }

        public void OnTransitionOff()
        {
            Visible = false;
        }
    }
}
