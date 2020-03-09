using Godot;
using System;

public class Plan : Node2D
{

    private Random rand;
    private TileMap _tileMap1;
    private TileMap _tileMap2;
    private int max_x = 31;
    private int min_x = -16;
    private int max_y = 19;
    private int min_y = -29;
    private int max_flaque_eau = 4;
    private int min_flaque_eau = 2;
    private int max_block_flaque_eau = 10;
    private int min_block_flaque_eau = 5;


    public override void _Ready()
    {
        rand = new Random();
        int nbr_flaque_eau = rand.Next(min_flaque_eau, max_flaque_eau+1);
        _tileMap1 = (TileMap) GetNode("Navigation2D/TileMap1");
        _tileMap2 = (TileMap) GetNode("Navigation2D/TileMap2");
        for (int i = 0; i < nbr_flaque_eau; i++)
        {
            int rand_x = rand.Next(min_x, max_x+1);
            int rand_y = rand.Next(min_y, max_y+1);
            int indexe = _tileMap1.GetCell(rand_x, rand_y);
            if (indexe == 2)
            {
                int nbr_block_eau = rand.Next(min_block_flaque_eau, max_block_flaque_eau+1);
                int j = 0;
                while (j < nbr_block_eau)
                {
                    int deplacement = rand.Next(0, 4);

                    switch (deplacement)
                    {
                        case 0:
                        {
                            if (_tileMap1.GetCell(rand_x+1, rand_y) == 0)
                            {
                                rand_x++;
                                _tileMap1.SetCell(rand_x, rand_y, 2);
                                j++;
                                if (_tileMap1.GetCell(rand_x+1, rand_y) == 0)
                                {
                                    _tileMap1.SetCell(rand_x+1, rand_y, 2);
                                    j++;
                                }
                                if (_tileMap1.GetCell(rand_x, rand_y+1) == 0)
                                {
                                    _tileMap1.SetCell(rand_x, rand_y+1, 2);
                                    j++;
                                }

                                if (_tileMap1.GetCell(rand_x, rand_y - 1) == 0)
                                {
                                    _tileMap1.SetCell(rand_x, rand_y - 1, 2);
                                    j++;
                                }
                            }
                            break;
                        }

                        case 1:
                        {
                            if (_tileMap1.GetCell(rand_x-1, rand_y) == 0)
                            {
                                rand_x--;
                                _tileMap1.SetCell(rand_x-1, rand_y, 2);
                                j++;
                                if (_tileMap1.GetCell(rand_x-1, rand_y) == 0)
                                {
                                    _tileMap1.SetCell(rand_x-1, rand_y, 2);
                                    j++;
                                }
                                if (_tileMap1.GetCell(rand_x, rand_y+1) == 0)
                                {
                                    _tileMap1.SetCell(rand_x, rand_y+1, 2);
                                    j++;
                                }
                                if (_tileMap1.GetCell(rand_x, rand_y-1) == 0)
                                {
                                    _tileMap1.SetCell(rand_x, rand_y-1, 2);
                                    j++;
                                }
                            }
                            break;
                        }

                        case 2:
                        {
                            if (_tileMap1.GetCell(rand_x, rand_y+1) == 0)
                            {
                                rand_y++;
                                _tileMap1.SetCell(rand_x, rand_y, 2);
                                j++;
                                if (_tileMap1.GetCell(rand_x+1, rand_y) == 0)
                                {
                                    _tileMap1.SetCell(rand_x+1, rand_y, 2);
                                    j++;
                                }
                                if (_tileMap1.GetCell(rand_x-1, rand_y) == 0)
                                {
                                    _tileMap1.SetCell(rand_x-1, rand_y, 2);
                                    j++;
                                }
                                if (_tileMap1.GetCell(rand_x, rand_y+1) == 0)
                                {
                                    _tileMap1.SetCell(rand_x, rand_y+1, 2);
                                    j++;
                                }
                                
                            }
                            break;
                        }
                        case 3:
                        {
                            if (_tileMap1.GetCell(rand_x, rand_y-1) == 0)
                            {
                                rand_y--;
                                _tileMap1.SetCell(rand_x, rand_y, 2);
                                j++;
                                if (_tileMap1.GetCell(rand_x+1, rand_y) == 0)
                                {
                                    _tileMap1.SetCell(rand_x+1, rand_y, 2);
                                    j++;
                                }
                                if (_tileMap1.GetCell(rand_x-1, rand_y) == 0)
                                {
                                    _tileMap1.SetCell(rand_x-1, rand_y, 2);
                                    j++;
                                }
                                if (_tileMap1.GetCell(rand_x, rand_y-1) == 0)
                                {
                                    _tileMap1.SetCell(rand_x, rand_y-1, 2);
                                    j++;
                                }
                            }
                            break;
                        }
                    }
                    
    
                }
            }
        }
    }
    
}
