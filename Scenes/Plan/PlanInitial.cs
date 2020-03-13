using Godot;
using System;

public class PlanInitial : Node2D
{

    public TileMap TileMap1;
    public TileMap TileMap2;
    public TileMap TileMap3;
    public TileMap TileMap4;
    public string str_TileMap1 = "Navigation2D/TileMap1";
    public string str_TileMap2 = "Navigation2D/TileMap2";
    public string str_TileMap3 = "Navigation2D/TileMap3";
    public string str_TileMap4 = "Navigation2D/TileMap4";
    
    public override void _Ready()
    {
        TileMap1 = (TileMap) GetNode("Navigation2D/TileMap1");
        TileMap2 = (TileMap) GetNode("Navigation2D/TileMap2");
        TileMap3 = (TileMap) GetNode("Navigation2D/TileMap3");
        TileMap4 = (TileMap) GetNode("Navigation2D/TileMap4");
    }

    public void SetBlock(TileMap tileMap, int x, int y, int index)
    {
        tileMap.SetCell(x, y, index);
    }
    
    public int GetBlock(TileMap tileMap, int x, int y)
    {
        return tileMap.GetCell(x, y);
    }
    
}
