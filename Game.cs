using Godot;
using System;
using System.Collections.Generic;

public partial class Game : Node
{
    public Broadcast broadcast;
    public List<Player> players = new ();
    public List<int> playerOrder;
    public override void _Ready()
    {
        broadcast = new Broadcast();
        broadcast.Connect(Broadcast.SignalName.PosEnd, new Callable(this, MethodName.PlayerEnd));

        // new 4 player
        for (int i = 0; i < 4; i++)
        {
            Player nPlayer = new();
            nPlayer.ConnectToGame(broadcast);
            players.Add(nPlayer);
        }
        // decide players order.
        // can randomly generate
        playerOrder = new List<int> { 0, 3, 2, 1 };
        GD.Print("Order: 0, 3, 2, 1");
        // record index into player 
        for (int i = 0; i < playerOrder.Count; i++)
        {
            players[playerOrder[i]].index = i;
        }

    }

    public void PlayerEnd(int pos)
    {
        int next = playerOrder.IndexOf(pos) + 1;
        if (next < playerOrder.Count)
        {
            broadcast.EmitSignal(Broadcast.SignalName.TurnTo, playerOrder[next]);
        }else{
            GD.Print("-- Game End --");
        }
    }

    public void StartGame()
    {
        GD.Print("-- Game Start --");
        broadcast.EmitSignal(Broadcast.SignalName.TurnTo, playerOrder[0]);
    }
}
