using Godot;
using System;

public partial class Broadcast : Node
{
    [Signal]
	public delegate void TurnToEventHandler(int pos); // turn to player at pos
    
    [Signal]
	public delegate void PosEndEventHandler(int pos);  // player at pos end turn
}
