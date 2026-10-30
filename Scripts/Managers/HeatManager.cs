using Godot;
using Godot.NativeInterop;
using System;

public partial class HeatManager : Node
{
	[Export] float heat;
	[Export] float temperature;
	[Export] float entropy;
	[Export] bool counting;

    public float seasonModifier;
    public float heatConstraint = 0.3495f;

    [Export(PropertyHint.Range, "1,4,1")] int season;

	Node EnergyManager;	

    public override void _Ready()
	{
		EnergyManager = GetNode<Node>("../Energy");
		seasonModifier = 2 / season;
		entropy = 0;
		heat = 0;
		counting = true;

		if (Random.Shared.Next(0, 100) > 79)
		{
			temperature = -50;
		} else
		{
			temperature = 0;
		}
	}

    public override void _Process(double delta)
    {
		float consumption = (float)EnergyManager.Get("consumption");
		heat += 0.3f * consumption;
		entropy = 0.45f * heat;

		temperature -= (heat - entropy);
    }
	
}
