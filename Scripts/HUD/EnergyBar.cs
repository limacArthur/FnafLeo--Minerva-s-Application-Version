using System;
using Godot;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNAFLEOv2.Scripts.HUD
{
    public partial class EnergyBar : ProgressBar
    {
        float energy;

        public override void _PhysicsProcess(double delta)
        {
            energy = (float)GetNode<Node>("/root/Office/Energy").Get("energy");
            this.Value = energy;
        }
    }
}
