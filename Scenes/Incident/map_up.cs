using Godot;
using System;

public class map_up : Node2D
{
    private TileMap _tileMap1, _tileMap2;
    private int x,y,index1,index2;
    /* dimension de la map */
    private int min_x = -16, max_x = 31;
    private int min_y = -29, max_y = 19;
    /* nombre de maison */
    private int min_house = 10;
    private int max_house = 20;
    /* index des differents blocs */
    private int grass = 0;
    private int house = 1;
    private int water = 2;
    //private int tds = 3;
    //private int montagne = 4;
    private int sand = 5;
    private int fire = 6;
    private int accident = 7;
    private int incident = 8;
    private int street = 9;
    private bool exist_accident;
    private bool exist_incident;
    private bool exist_fire;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _tileMap1 = (TileMap) GetNode("Navigation2D/TileMap1");
        _tileMap2 = (TileMap) GetNode("Navigation2D/TileMap2");
        var rand = new Random();
        int nb_house = rand.Next(min_house, max_house);
        for(int i = 0; i < nb_house; i++)
        {
            x = rand.Next(min_x,max_x);
            y = rand.Next(min_y,max_y);
            index1 = _tileMap1.GetCell(x,y);
            index2 = _tileMap2.GetCell(x,y);
            if(index1 == grass && index2 == -1)
                _tileMap2.SetCell(x,y,house);
        }
        x = rand.Next(min_x,max_x);
        y = rand.Next(min_y,max_y);
        index1 = _tileMap1.GetCell(x,y);
        index2 = _tileMap2.GetCell(x,y);
        if (!exist_fire && index1 != water && index1 != sand)
        {
            exist_incident = true;
            _tileMap2.SetCell(x,y,fire);
        }
        
        x = rand.Next(min_x,max_x);
        y = rand.Next(min_y,max_y);
        index1 = _tileMap1.GetCell(x,y);
        index2 = _tileMap2.GetCell(x,y);
        if (!exist_accident && index1 == grass || index1 == street && index2 == -1 || index2 == house)
        {
            exist_accident = true;
            _tileMap2.SetCell(x,y,accident);
        }
        x = rand.Next(min_x,max_x);
        y = rand.Next(min_y,max_y);
        index1 = _tileMap1.GetCell(x,y);
        index2 = _tileMap2.GetCell(x,y);
        if (!exist_incident)
        {
            exist_fire = true;
            _tileMap2.SetCell(x,y,incident);
        }
		
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}