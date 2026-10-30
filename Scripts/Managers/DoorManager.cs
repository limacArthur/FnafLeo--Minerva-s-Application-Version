using Godot;
using System;

public partial class DoorManager : Node
{
	[Export] public bool leftDoorClosed;
	[Export] public bool rightDoorClosed;
    [Export] public float speed;

    bool canCloseDoor;

    Node energyMananger;

    public override void _Ready()
    {
        energyMananger = GetNode<Node>("../Energy");
        leftDoorClosed = false;
        rightDoorClosed = false;
    }

    
}
