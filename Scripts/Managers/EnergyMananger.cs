using Godot;
using System;
using System.Runtime.InteropServices;

public partial class EnergyMananger : Node
{
	[Export] float startEnergy = 2000;
	[Export] public float energy;
	float consumption;

	Node doors;
	Node light;
	Node monitor;

	public override void _Ready()
	{
		SetupNodes();
		energy = startEnergy;
	}
	
	
	public override void _Process(double delta)
	{
		float lightConsumption = General.ConvertBoolToInt(doors.Get("leftLightOn").AsBool())
			+ General.ConvertBoolToInt(doors.Get("rightLightOn").AsBool()) * 1.5f;
		float doorComsuption = General.ConvertBoolToInt(doors.Get("leftDoorClosed").AsBool())
            + General.ConvertBoolToInt(doors.Get("rightDoorClosed").AsBool()) * 3f;

        consumption = (lightConsumption +  doorComsuption + 0.2f);
		energy -= consumption * (float)GetProcessDeltaTime();
    }

	void SetupNodes()
	{
		doors = GetNode<Node>("../Doors");
        light = GetNode<Node>("../Lights");
    }
 

}
