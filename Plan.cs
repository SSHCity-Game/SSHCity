using Godot;
using System;

public class Plan : Node2D
{

    private Random rand;
    private TileMap _tileMap1;
    private TileMap _tileMap2;
    private int block_eau = 15;
    
    
    public override void _Ready()
    {
        rand = new Random();
        _tileMap1 = (TileMap) GetNode("Navigation2D/TileMap1");
        _tileMap2 = (TileMap) GetNode("Navigation2D/TileMap2");
        for (int i = 0; i < block_eau; i++)
        {
            int rand_x = rand.Next(-16, 31);
            int rand_y = rand.Next(-29, 19);
            int indexe = _tileMap1.GetCell(rand_x, rand_y);
            if (indexe == -1)
            {
                i--;
            }
            else
            {
                _tileMap1.SetCell(rand_x, rand_y, 2, false, false, false);
            }
        }
    }
    
}
