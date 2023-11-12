using System;
using System.Collections.Generic;
using Godot;

public partial class Player : Node
{

    public int index;
    public Broadcast broadcast;
    public void ConnectToGame(Broadcast gbroadcast)
    {
        broadcast = gbroadcast;
        gbroadcast.Connect(Broadcast.SignalName.TurnTo, new Callable(this, MethodName.PlayerTurn));
        gbroadcast.Connect(Broadcast.SignalName.PosEnd, new Callable(this, MethodName.PlayerEnd));
    }

    public List<int> order=new();

    public void PlayerTurn(int pos)
    {
        order.Add(pos);
        GD.Print("    Player ", index, " receive TurnToEvent: to ", pos," |  ", string.Join(",", order));

        if (pos == index)
        {
            GD.Print("[Player ", index, " In Turn]");
            // var b = Time.GetTicksMsec();
            // while((Time.GetTicksMsec()- b )<1000){};
            broadcast.EmitSignal(Broadcast.SignalName.PosEnd, index);
        }
    }

    public void PlayerEnd(int pos)
    {

    }

}