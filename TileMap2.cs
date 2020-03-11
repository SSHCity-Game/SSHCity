using Godot;
using System;

public class TileMap2 : TileMap
{
	private TileMap TileMap1, TileMap2;
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
		TileMap1 = (TileMap) GetNode("Navigation2D/TileMap1");
		TileMap2 = (TileMap) GetNode("Navigation2D/TileMap2");
		rand = new Random();
		int nb_house = rand.Next(min_house, max_house);
		for(int i = 0; i < nb_house; i++)
		{
			x = rand.Next(min_x,max_x);
			y = rand.Next(min_y,max_y);
			index1 = TileMap1.GetCell(x,y);
			index2 = TileMap2.GetCell(x,y);
			if(index1 == grass && index2 == -1)
				TileMap2.SetCell(x,y,house);
		}
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
