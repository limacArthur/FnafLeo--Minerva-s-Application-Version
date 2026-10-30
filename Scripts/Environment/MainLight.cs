using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class MainLight : DirectionalLight2D
{
	[Export] public bool on;
	[Export] public float regularEnergy;
	float tEnergy;
	bool alreadyPlayed;

	AudioStreamPlayer blackoutAudio;
    AudioStreamPlayer tinnitus;

    Node energyManager;

	public override void _Ready()
	{
		alreadyPlayed = false;
		blackoutAudio = GetNode<AudioStreamPlayer>("../BlackoutSd");
        tinnitus = GetNode<AudioStreamPlayer>("../Tinnitus");
        energyManager = GetNode<Node>("/root/Office/Energy");
		on = true;
	}

	
	public override void _Process(double delta)
	{

        if (energyManager == null) return;

        tEnergy = energyManager.Get("energy").As<float>();

        if (tEnergy < 0)
		{
			on = false;
		} else
		{
			alreadyPlayed = false;
		}

		if (!on)
		{
			Energy = 0;
			if (!alreadyPlayed)
			{
				blackoutAudio.Play();
				tinnitus.Play();
				alreadyPlayed = true;
			}
		} 
	}

	
	async void Blackout()
	{
		blackoutAudio.Play();
		Energy = 0;
        await ToSignal(GetTree().CreateTimer(5.0f), SceneTreeTimer.SignalName.Timeout);
		int i = 0;

		while (i < 10)
		{
			Energy = regularEnergy;
            await ToSignal(GetTree().CreateTimer(0.1f), SceneTreeTimer.SignalName.Timeout);
			Energy = 0;
            await ToSignal(GetTree().CreateTimer(0.1f), SceneTreeTimer.SignalName.Timeout);
			i++;
        }

		Energy = regularEnergy;
		
    }
}
