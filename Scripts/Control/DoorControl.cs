using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace FNAFLEOv2.Scripts.Control
{
    internal partial class DoorControl : Node2D
    {
        [Export] public string sidePath;
        [Export] public bool inputState;
        [Export] public float yLimit;
        [Export] public float yFloor;
        [Export] public float speed;

        Node Switch;
        Node Doors;

        Vector2 movement = new Vector2(0, -1);
        [Export] double deltaTime;

        public override void _Ready()
        {
            Switch = GetNode<Area2D>($"/root/Office/Switch/{sidePath}/Area2D");
            Doors = GetNode<Node>("/root/Office/Doors");
            yFloor = Position.Y;
            speed = (float)Doors.Get("speed");
            speed = speed == 0 ? 1 : speed;
        }

        public override void _PhysicsProcess(double delta)
        {
            
            inputState = Switch.Get("state").AsBool();
            

            if (inputState)
            {
                if (Position.Y > yLimit)
                {
                    Position += GetMove(speed * movement);
                    if (Position.Y < yLimit) Position = new Vector2(Position.X, yLimit);
                }
            }
            else
            {
                if (Position.Y < yFloor)
                {
                    Position += GetMove(-speed * movement);
                    if (Position.Y > yFloor) Position = new Vector2(Position.X, yFloor);
                }
            }
        }
            
        

        Vector2 GetMove(Vector2 movement)
        {
            deltaTime = GetProcessDeltaTime();
            double chargeX = (double)movement.X * deltaTime;
            double chargeY = (double)movement.Y * deltaTime;
            Vector2 normMovement = new Vector2((float)chargeX, (float)chargeY);
            return normMovement;
        }
    }
}
