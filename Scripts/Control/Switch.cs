using Godot;
using System;
using System.IO.Compression;
using System.Threading.Tasks;

public partial class Switch : Area2D
{
    [Export] public bool state;
    [Export] public bool originalState;
    [Export] public bool isDoor;
    public bool mouseInside;

    Node energyManager;


    AudioStreamPlayer audioStream;

    [Export] public float energy;
    public override void _Ready()
    {
        state = originalState;
        MouseEntered += OnMouseEntered;
        MouseExited += OnMouseExited;
        string path;

        if (isDoor) 
        {
            path = "/root/Office/Switch/DoorAudio";
        }
        else
        {
            path = "/root/Office/Switch/LightAudio";
        }
        audioStream = GetNode<AudioStreamPlayer>(path);
        energyManager = GetNode<Node>("/root/Office/Energy");
    }

    void OnMouseEntered()
    {
        mouseInside = true;
    }
    
    void OnMouseExited()
    {
        mouseInside = false;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        
        if (mouseInside && @event is InputEventMouseButton mouseEvent && mouseEvent.ButtonIndex == MouseButton.Left)
        {
            energy = (float)energyManager.Get("energy");
            if (mouseEvent.Pressed && energy > 0)
            {
                state = !state;
                float pitch = (float)(GD.RandRange(0.8, 1.2));
                audioStream.PitchScale = pitch;
                audioStream.Play();
            }

        }

    }

    
}
