using Godot;
using System;

public class TileMap : Godot.TileMap
{
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		rand = new Random();
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
