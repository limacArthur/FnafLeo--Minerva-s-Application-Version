using Godot;
using System;

public partial class LightControl : Node
{
	[Export] public bool leftLightOn;
	[Export] public bool rightLightOn;


	public override void _Ready()
	{
		leftLightOn = false;
		rightLightOn = false;
	}

	
	public override void _Process(double delta)
	{

	}
}
