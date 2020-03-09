using Godot;
using System;

public class Plan : Node2D
{

    private Random rand;
    private TileMap _tileMap1;
    private TileMap _tileMap2;
    
    
    public override void _Ready()
    {
        rand = new Random();
        _tileMap1 = (TileMap) GetNode("Navigation2D/TileMap1");
        _tileMap2 = (TileMap) GetNode("Navigation2D/TileMap2");
        _tileMap1.SetCell( 5, 5, 2, false, false, false);
    }
    
}
