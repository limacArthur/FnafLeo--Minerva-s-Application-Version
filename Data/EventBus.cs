using Godot;
using System;

public partial class EventBus : Node
{
    [Signal] public delegate void BlackoutCalledEventHandler();

    [Signal] public delegate void NewGameStartedEventHandler();

    [Signal] public delegate void ContinueGameEventHandler();

    [Signal] public delegate void TransitionOnEventHandler();

    [Signal] public delegate void TransitionOffEventHandler();


    public static EventBus Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }
}