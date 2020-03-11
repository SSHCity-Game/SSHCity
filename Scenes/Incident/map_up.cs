using Godot;
using System;

public class map_up : Node2D
{
    private TileMap tileMap1, tileMap2;
    private int x,y,index1,index2;
    private int min_x = -16, max_x = 31;
    private int min_y = -29, max_y = 19;
    private int min_house = 10;
    private int max_house = 20;
    private int grass = 0;
    private int house = 1;
    private int water = 2;
    private int accident = 3;
    private int route = 4;
    private int montagne = 5;
    private int sable = 6;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        tileMap1 = (TileMap) GetNode("Navigation2D/TileMap1");
        tileMap2 = (TileMap) GetNode("Navigation2D/TileMap2");
        var rand = new Random();
        int nb_house = rand.Next(min_house, max_house);
        for(int i = 0; i < nb_house; i++)
        {
            x = rand.Next(min_x,max_x);
            y = rand.Next(min_y,max_y);
            var index1 = tileMap1.GetCell(x,y);
            var index2 = tileMap2.GetCell(x,y);
            if(index1 == grass && index2 == -1)
                tileMap2.SetCell(x,y,house);
        }
		
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}