using Godot;
using System;

public class Building : Node
{
    private int size;
    private int level;
    private int price;
    private int time_to_build;
    private int money = 100000000;

    public Building(int size, int level)
    {
        this.size = size;
        this.level = level;
    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//
//  }
}
