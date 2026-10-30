using Godot;
using System;

public partial class CameraControl : Camera2D
{

	Node monitor;

	[Export] public float cameraLimit;
	[Export] bool ControlModeMouse; //true -> Mouse, false -> Keys
	[Export] public float cameraMovementLimit;
	[Export]public float cameraSpeed = 150f;

    float cameraInput;
    Vector2 viewportSize;
    Vector2 Mouse;

	public override void _Ready()
	{
        EventBus.Instance.EmitSignal(EventBus.SignalName.TransitionOff);
        viewportSize = GetViewport().GetVisibleRect().Size;
        Position = new Vector2 (0, 0);
		Zoom = new Vector2 (1.285f, 1.285f);
		monitor = GetNode<Node>("/root/Office/Monitor");

		if (cameraLimit < 1)
		{
			cameraLimit = 100f;
		}
	}


    public override void _Process(double delta)
    {
        Mouse = GetViewport().GetMousePosition();
        float currentSpeed = cameraSpeed * (float)delta;
        float mouseLimit = viewportSize.X / 3f;

        if (!ControlModeMouse)
        {
            Position += new Vector2(cameraInput * currentSpeed, 0f);
            float clampedX = Mathf.Clamp(Position.X, -cameraLimit, cameraLimit);
            Position = new Vector2(clampedX, Position.Y);
        } else
		{
            float newX = (Position.X + Mathf.Clamp(Mathf.Floor((Mouse.X - mouseLimit)/mouseLimit), -1, 1) * 
                cameraSpeed * (float)delta);

            Position = new Vector2(Mathf.Clamp(newX, -cameraLimit, cameraLimit), 0f);
		}
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        cameraInput = Input.GetAxis("Left", "Right");
    }

	
}
