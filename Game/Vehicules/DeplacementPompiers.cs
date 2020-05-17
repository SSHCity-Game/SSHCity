using Godot;
using System;
using SshCity.Game.Vehicules;

public class DeplacementPompiers : Vehicules
{
    public override void _Ready()
    {
        
    }

    public void FindRoad(Vector2 pos1, Vector2 pos2)
    {
        Vector2 delta = pos1 - pos2;
        
    }
    
}
