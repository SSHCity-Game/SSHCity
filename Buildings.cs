using Godot;
using System;
using System.Collections.Generic;

public class Buildings : Node2D
{

    private Random rand;
    private TileMap _tileMap1;
    private TileMap _tileMap2;
    private TileMap _tileMap3;
    private TileMap _tileMap4;
    private int max_x = 31;
    private int min_x = -16;
    private int max_y = 19;
    private int min_y = -29;
    private int max_flaque_eau = 4;
    private int min_flaque_eau = 2;
    private int max_block_flaque_eau = 10;
    private int min_block_flaque_eau = 5;
    private int m_max = 5; //Nombre bocks montagnes à trois etages max
    private int m_min = 3; 
    private int indexe_terre      = 0;  
    private int indexe_maison     = 1;
    private int indexe_eau        = 2;
    private int indexe_accident   = 3;
    private int indexe_route      = 4; 
    private int indexe_montagne   = 5;
    private int indexe_sable      = 6; 
    


    public override void _Ready()
    {
        
        rand = new Random();
        int nbr_flaque_eau = rand.Next(min_flaque_eau, max_flaque_eau + 1);
        _tileMap1 = (TileMap) GetNode("Navigation2D/TileMap1");
        _tileMap2 = (TileMap) GetNode("Navigation2D/TileMap2");
        _tileMap3 = (TileMap) GetNode("Navigation2D/TileMap3");
        _tileMap4 = (TileMap) GetNode("Navigation2D/TileMap4");
        Montagne();
        List<(int, int)> coordonnes_base_flaques = new List<(int, int)>();
        for (int i = 0; i < nbr_flaque_eau; i++)
        {
            int rand_x = rand.Next(min_x, max_x + 1);
            int rand_y = rand.Next(min_y, max_y + 1);
            int indexe = _tileMap1.GetCell(rand_x, rand_y);
            if (indexe == 0)
            {
                coordonnes_base_flaques.Add((rand_x, rand_y));
                int nbr_block_eau = rand.Next(min_block_flaque_eau, max_block_flaque_eau + 1);
                _tileMap1.SetCell(rand_x, rand_y, indexe_eau);
                nbr_block_eau++;
                int j = 0;
                while (j < nbr_block_eau)
                {
                    int deplacement = rand.Next(0, 4);

                    switch (deplacement)
                    {
                        case 0:
                        {
                            rand_x++;
                            if (_tileMap1.GetCell(rand_x, rand_y) == indexe_terre)
                            {
                                _tileMap1.SetCell(rand_x, rand_y, indexe_eau);
                            }

                            if (_tileMap1.GetCell(rand_x + 1, rand_y) == indexe_terre)
                            {

                                _tileMap1.SetCell(rand_x, rand_y, indexe_eau);
                                j++;
                                if (_tileMap1.GetCell(rand_x + 1, rand_y) == indexe_terre)
                                {
                                    _tileMap1.SetCell(rand_x + 1, rand_y, indexe_eau);
                                    j++;
                                }

                                if (_tileMap1.GetCell(rand_x, rand_y + 1) == indexe_terre)
                                {
                                    _tileMap1.SetCell(rand_x, rand_y + 1, indexe_eau);
                                    j++;
                                }

                                if (_tileMap1.GetCell(rand_x, rand_y - 1) == indexe_terre)
                                {
                                    _tileMap1.SetCell(rand_x, rand_y - 1, indexe_eau);
                                    j++;
                                }
                            }

                            break;
                        }

                        case 1:
                        {
                            rand_x--;
                            if (_tileMap1.GetCell(rand_x, rand_y) == indexe_terre)
                            {
                                _tileMap1.SetCell(rand_x, rand_y, indexe_eau);
                            }

                            if (_tileMap1.GetCell(rand_x - 1, rand_y) == indexe_terre)
                            {

                                _tileMap1.SetCell(rand_x - 1, rand_y, indexe_eau);
                                j++;
                                if (_tileMap1.GetCell(rand_x - 1, rand_y) == indexe_terre)
                                {
                                    _tileMap1.SetCell(rand_x - 1, rand_y, indexe_eau);
                                    j++;
                                }

                                if (_tileMap1.GetCell(rand_x, rand_y + 1) == indexe_terre)
                                {
                                    _tileMap1.SetCell(rand_x, rand_y + 1, indexe_eau);
                                    j++;
                                }

                                if (_tileMap1.GetCell(rand_x, rand_y - 1) == indexe_terre)
                                {
                                    _tileMap1.SetCell(rand_x, rand_y - 1, indexe_eau);
                                    j++;
                                }
                            }

                            break;
                        }

                        case 2:
                        {
                            rand_y++;
                            if (_tileMap1.GetCell(rand_x, rand_y) == indexe_terre)
                            {
                                _tileMap1.SetCell(rand_x, rand_y, indexe_eau);
                            }

                            if (_tileMap1.GetCell(rand_x, rand_y + 1) == indexe_terre)
                            {
                                _tileMap1.SetCell(rand_x, rand_y, indexe_eau);
                                j++;
                                if (_tileMap1.GetCell(rand_x + 1, rand_y) == indexe_terre)
                                {
                                    _tileMap1.SetCell(rand_x + 1, rand_y, indexe_eau);
                                    j++;
                                }

                                if (_tileMap1.GetCell(rand_x - 1, rand_y) == indexe_terre)
                                {
                                    _tileMap1.SetCell(rand_x - 1, rand_y, indexe_eau);
                                    j++;
                                }

                                if (_tileMap1.GetCell(rand_x, rand_y + 1) == indexe_terre)
                                {
                                    _tileMap1.SetCell(rand_x, rand_y + 1, indexe_eau);
                                    j++;
                                }
                            }

                            break;
                        }
                        case 3:
                        {
                            rand_y--;
                            if (_tileMap1.GetCell(rand_x, rand_y) == indexe_terre)
                            {
                                _tileMap1.SetCell(rand_x, rand_y, indexe_eau);
                            }

                            if (_tileMap1.GetCell(rand_x, rand_y - 1) == indexe_terre)
                            {
                                _tileMap1.SetCell(rand_x, rand_y, indexe_eau);
                                j++;
                                if (_tileMap1.GetCell(rand_x + 1, rand_y) == indexe_terre)
                                {
                                    _tileMap1.SetCell(rand_x + 1, rand_y, indexe_eau);
                                    j++;
                                }

                                if (_tileMap1.GetCell(rand_x - 1, rand_y) == indexe_terre)
                                {
                                    _tileMap1.SetCell(rand_x - 1, rand_y, indexe_eau);
                                    j++;
                                }

                                if (_tileMap1.GetCell(rand_x, rand_y - 1) == indexe_terre)
                                {
                                    _tileMap1.SetCell(rand_x, rand_y - 1, indexe_eau);
                                    j++;
                                }
                            }

                            break;
                        }
                    }
                }
            }
            else
            {
                i--;
            }
        }

        foreach (var coord in coordonnes_base_flaques)
        {
            (int x, int y) = coord;
            GD.Print(coord);


            SableGauche(x, y);
            SableHaut(x, y);
            SableBas(x, y);
            SableDroite(x, y);
        }

        int x2 = rand.Next(min_x + 8, max_x - 8);
        int y2 = rand.Next(min_y + 8, max_y - 8);
        int acc = 0;
        for (int i = x2; i < x2 + 5; i += 2) //cONSTRUCTION DES BATIMENTS
        {
            for (int j = y2; j < y2 + 5; j += 2)
            {
                if (_tileMap1.GetCell(i, j) == indexe_terre)
                {
                    _tileMap2.SetCell(i, j, indexe_maison);
                }
            }

        }

        for (int i = x2 + 1; i < x2 + 6; i++) //placement des routes
        {
            for (int j = y2 + 1; j < y2 + 6; j++)
            {
                if (_tileMap1.GetCell(i, j) == indexe_terre)
                {
                    _tileMap1.SetCell(i, j, indexe_route);
                }
            }
        }


        for (int i = min_x; i < max_x; i++) //route hg ->bd
        {
            bool continuer = true;
            if (acc > 0)
            {
                if (_tileMap1.GetCell(i, y2 - 1) == indexe_terre )
                {
                    _tileMap1.SetCell(i, y2, indexe_route);
                    _tileMap1.SetCell(i, y2 - 1, indexe_route);
                    acc -= 1;
                    y2 -= 1;
                    continuer = false;
                }
            }
            else if (acc < 0)
            {
                if (_tileMap1.GetCell(i, y2 + 1) == indexe_terre)
                {
                    _tileMap1.SetCell(i, y2, indexe_route);
                    _tileMap1.SetCell(i, y2 + 1, indexe_route);
                    acc += 1;
                    y2 += 1;
                    continuer = false;
                }
            }

            if (continuer)
            {
                if (avant(i, y2))
                {
                    if (gauche(i-1, y2))
                    {
                       _tileMap1.SetCell(i-1,y2,indexe_route);
                       _tileMap1.SetCell(i-2,y2-1,indexe_route);
                       _tileMap1.SetCell(i-2,y2,indexe_route);
                       i -= 2;
                       acc -= 1;
                       y2 -= 1;
                    }
                    else
                    {
                        _tileMap1.SetCell(i - 1, y2 - 1, indexe_route);
                        y2 -= 1;
                        i -= 1;
                        acc -= 1;
                    }
                }
                else
                {
                    if (_tileMap1.GetCell(i, y2) == indexe_terre)
                    {
                        _tileMap1.SetCell(i, y2, indexe_route);
                    }
                }

            }
        }

        int acc2 = 0;//route hd ->bg
        int refer = x2;
        for (int i = min_y; i < max_y; i++)
        {
            bool continuer2 = true;
            if (acc2 > 0)
            {
                if (_tileMap1.GetCell(x2 - 1, i) == indexe_terre)
                {
                    _tileMap1.SetCell(x2, i, indexe_route);
                    _tileMap1.SetCell(x2 - 1, i, indexe_route);
                    acc2 -= 1;
                    x2 -= 1;
                    continuer2 = false;
                }
            }
            else if (acc2 < 0)
            {
                if (_tileMap1.GetCell(x2 + 1, i) == indexe_terre )
                {
                    _tileMap1.SetCell(x2, i, indexe_route);
                    _tileMap1.SetCell(x2 + 1, i, indexe_route);
                    acc2 += 1;
                    x2 += 1;
                    continuer2 = false;
                }
            }
            
            if (avant2(x2, i) && (_tileMap1.GetCell(x2-1, i-1) == indexe_route))
            {
                x2 = refer - 1;
                refer -= 1;
            }
            else
            {
                if (avant2(x2, i))
                {
                    if (gauche2(x2, i-1))
                    {
                            _tileMap1.SetCell(i-1,x2,indexe_route);
                            _tileMap1.SetCell(i-2,x2-1,indexe_route);
                            _tileMap1.SetCell(i-2,x2,indexe_route);
                            i -= 3;
                            x2 -= 1;
                            acc2 -= 1;
                    }
                    else
                    {
                        _tileMap1.SetCell(x2 - 1, i - 1, indexe_route);
                        x2 -= 1;
                        i -= 1;
                        acc2 -= 1;
                    }
                }
                else
                {
                    if (_tileMap1.GetCell(x2, i) == indexe_terre)
                    {
                        _tileMap1.SetCell(x2, i, indexe_route);
                    }
                }
            }
        }
    }

        private bool avant(int x, int y)
         {
             return _tileMap1.GetCell(x , y) == indexe_sable || _tileMap2.GetCell(x, y) == indexe_montagne;
         }
         private bool gauche(int x, int y)
         {
             return _tileMap1.GetCell(x , y-1) == indexe_sable || _tileMap2.GetCell(x, y-1) == indexe_montagne;
         }
         private bool avant2(int x, int y)
         {
             return _tileMap1.GetCell(x , y) == indexe_sable|| _tileMap2.GetCell(x, y) == indexe_montagne || _tileMap1.GetCell(x-1,y) == indexe_eau;
         }
         private bool gauche2(int x, int y)
         {
             return _tileMap1.GetCell(x-1 , y) == indexe_sable || _tileMap2.GetCell(x-1, y) == indexe_montagne || _tileMap1.GetCell(x-1,y) == indexe_eau;
         }

    private void SableDroite(int x, int y)
    {
        if (_tileMap1.GetCell(x, y) == indexe_terre || _tileMap1.GetCell(x, y) == indexe_sable)
        {
            _tileMap1.SetCell(x, y, indexe_sable);
        }
        else 
        {
            if (_tileMap1.GetCell(x, y) == indexe_eau)
            {
                SableDroite(x+1, y+1);
                SableDroite(x+1, y);
                SableDroite(x+1, y-1);
            }
        }
    }

    private void SableGauche(int x, int y)
    {
        if (_tileMap1.GetCell(x, y) == indexe_terre || _tileMap1.GetCell(x, y) == indexe_sable)
        {
            _tileMap1.SetCell(x, y, indexe_sable);
        }
        else 
        {
            if (_tileMap1.GetCell(x, y) == indexe_eau)
            {
                SableGauche(x-1, y+1);
                SableGauche(x-1, y);
                SableGauche(x-1, y-1);
            }
        }
    }
    
    private void SableHaut(int x, int y)
    {
        if (_tileMap1.GetCell(x, y) == indexe_terre || _tileMap1.GetCell(x, y) == indexe_sable)
        {
            _tileMap1.SetCell(x, y, indexe_sable);
        }

        if (_tileMap1.GetCell(x, y) == indexe_eau)
        {
            SableHaut(x+1, y+1);
            SableHaut(x, y+1);
            SableHaut(x-1, y+1);
        }
        
    }
    
    private void SableBas(int x, int y)
    {
        if (_tileMap1.GetCell(x, y) == indexe_terre || _tileMap1.GetCell(x, y) == indexe_sable)
        {
            _tileMap1.SetCell(x, y, indexe_sable);
        }
        else 
        {
            if (_tileMap1.GetCell(x, y) == indexe_eau)
            {
                SableBas(x+1, y-1);
                SableBas(x, y-1);
                SableBas(x-1, y-1);
            }
        }
    }

     private void Montagne()
    {
        int nbr_m = rand.Next(m_min, m_max);
        int rand_m_x = rand.Next(min_x, max_x+1);
        int rand_m_y = rand.Next(min_y, max_y+1);
        int indexe_m = _tileMap1.GetCell(rand_m_x, rand_m_y);
        if (indexe_m == 0)
        {
            _tileMap4.SetCell(rand_m_x, rand_m_y, indexe_montagne);
            _tileMap1.SetCell(rand_m_x, rand_m_y, indexe_montagne);
            Montagne_Lv2(rand_m_x+1, rand_m_y+1);
            int i = 1;
            while (i < nbr_m)
            {
                int alea = rand.Next(0,4);
                switch (alea)
                {
                    case 0:
                    {
                        if (_tileMap1.GetCell(rand_m_x-2, rand_m_y-2) == indexe_terre)
                        {
                            rand_m_x-=2;
                            rand_m_y-=2;
                            _tileMap1.SetCell(rand_m_x, rand_m_y, indexe_montagne);
                            _tileMap4.SetCell(rand_m_x, rand_m_y, indexe_montagne);
                            Montagne_Lv2(rand_m_x+1, rand_m_y+1);
                            i++;
                        }

                        break;
                    }

                    case 1:
                    {
                        if (_tileMap1.GetCell(rand_m_x+2, rand_m_y+2) == indexe_terre)
                        {
                            //Montagne_Lv3(rand_m_x+1, rand_m_y+1);
                            rand_m_x+=2;
                            rand_m_y+=2;
                            _tileMap1.SetCell(rand_m_x, rand_m_y, indexe_montagne);
                            _tileMap4.SetCell(rand_m_x, rand_m_y, indexe_montagne);
                            Montagne_Lv2(rand_m_x+1, rand_m_y+1);
                            i++;
                        }

                        break;
                    }

                    case 2:
                    {
                        if (_tileMap1.GetCell(rand_m_x-2, rand_m_y+2) == indexe_terre)
                        {
                            //Montagne_Lv3(rand_m_x, rand_m_y);
                            rand_m_x-=2;
                            rand_m_y+=2;
                            _tileMap1.SetCell(rand_m_x, rand_m_y, indexe_montagne);
                            _tileMap4.SetCell(rand_m_x, rand_m_y, indexe_montagne);
                            Montagne_Lv2(rand_m_x+1, rand_m_y+1);
                            i++;
                        }

                        break;
                    }

                    case 3:
                    {
                        
                        if (_tileMap1.GetCell(rand_m_x+2, rand_m_y-2) == indexe_terre)
                        {
                            //Montagne_Lv3(rand_m_x, rand_m_y);
                            rand_m_x+=2;
                            rand_m_y-=2;
                            _tileMap1.SetCell(rand_m_x, rand_m_y, indexe_montagne);
                            _tileMap4.SetCell(rand_m_x, rand_m_y, indexe_montagne);
                            Montagne_Lv2(rand_m_x+1, rand_m_y+1);
                            i++;
                        }

                        break;
                    }
                }
            }
        }
        else
        {
            Montagne();
        }
    }
    
    private void Montagne_Lv2(int x, int y)
    {
        if (_tileMap1.GetCell(x-1, y-1) == 0 || _tileMap1.GetCell(x-1, y-1) == indexe_montagne)
        {
            _tileMap1.SetCell(x - 1, y - 1, indexe_montagne);
            _tileMap3.SetCell(x - 1, y - 1, indexe_montagne);
            Montagne_Lv3(x, y);
        }
        if (_tileMap1.GetCell(x+1, y+1) == 0 || _tileMap1.GetCell(x+1, y+1) == indexe_montagne)
        {
            _tileMap3.SetCell(x+1, y+1, indexe_montagne);
            _tileMap1.SetCell(x+1, y+1, indexe_montagne);
            Montagne_Lv3(x+2, y+2);
        }
        if (_tileMap1.GetCell(x, y-1) == 0 || _tileMap1.GetCell(x, y-1) == indexe_montagne)
        {
            _tileMap3.SetCell(x, y-1, indexe_montagne);
            _tileMap1.SetCell(x, y-1, indexe_montagne);
            Montagne_Lv3(x+1, y);
        }
        if (_tileMap1.GetCell(x-1, y) == 0 || _tileMap1.GetCell(x-1, y) == indexe_montagne)
        {
            _tileMap3.SetCell(x-1, y, indexe_montagne);
            _tileMap1.SetCell(x-1, y, indexe_montagne);
            Montagne_Lv3(x, y+1);
        }
        if (_tileMap1.GetCell(x-1, y+1) == 0 || _tileMap1.GetCell(x-1, y+1) == indexe_montagne)
        {
            _tileMap3.SetCell(x-1, y+1, indexe_montagne);
            _tileMap1.SetCell(x-1, y+1, indexe_montagne);
            Montagne_Lv3(x, y+2);
        }
        if (_tileMap1.GetCell(x+1, y-1) == 0 || _tileMap1.GetCell(x+1, y-1) == indexe_montagne)
        {
            _tileMap3.SetCell(x+1, y-1, indexe_montagne);
            _tileMap1.SetCell(x+1, y-1, indexe_montagne);
            Montagne_Lv3(x+2, y);
        }
        if (_tileMap1.GetCell(x+1, y) == 0 || _tileMap1.GetCell(x+1, y) == indexe_montagne)
        {
            _tileMap3.SetCell(x+1, y, indexe_montagne);
            _tileMap1.SetCell(x+1, y, indexe_montagne);
            Montagne_Lv3(x+2, y+1);
        }
        if (_tileMap1.GetCell(x, y+1) == 0 || _tileMap1.GetCell(x, y+1) == indexe_montagne)
        {
            _tileMap3.SetCell(x, y+1, indexe_montagne);
            _tileMap1.SetCell(x, y+1, indexe_montagne);
            Montagne_Lv3(x+1, y+2);
        }
    }

    private void Montagne_Lv3(int x, int y)
    {     
        if (_tileMap1.GetCell(x-1, y-1) == indexe_terre)
        {
            _tileMap1.SetCell(x - 1, y - 1, indexe_montagne);
            _tileMap2.SetCell(x - 1, y - 1, indexe_montagne);
        }
        if (_tileMap1.GetCell(x+1, y+1) == 0)
        {
            _tileMap2.SetCell(x+1, y+1, indexe_montagne);
            _tileMap1.SetCell(x+1, y+1, indexe_montagne);

        }
        if (_tileMap1.GetCell(x, y-1) == indexe_terre)
        {
            _tileMap2.SetCell(x, y-1, indexe_montagne);
            _tileMap1.SetCell(x, y-1, indexe_montagne);

        }
        if (_tileMap1.GetCell(x-1, y) == indexe_terre)
        {
            _tileMap2.SetCell(x-1, y, indexe_montagne);
            _tileMap1.SetCell(x-1, y, indexe_montagne);

        }
        if (_tileMap1.GetCell(x-1, y+1) == indexe_terre)
        {
            _tileMap2.SetCell(x-1, y+1, indexe_montagne);
            _tileMap1.SetCell(x-1, y+1, indexe_montagne);

        }
        if (_tileMap1.GetCell(x+1, y-1) == indexe_terre)
        {
            _tileMap2.SetCell(x+1, y-1, indexe_montagne);
            _tileMap1.SetCell(x+1, y-1, indexe_montagne);

        }
        if (_tileMap1.GetCell(x+1, y) == indexe_terre)
        {
            _tileMap2.SetCell(x+1, y, indexe_montagne);
            _tileMap1.SetCell(x+1, y, indexe_montagne);

        }

        if (_tileMap1.GetCell(x, y + 1) == indexe_terre)
        {
            _tileMap2.SetCell(x, y + 1, indexe_montagne);
            _tileMap1.SetCell(x, y + 1, indexe_montagne);
        }
    }

    public override void _Process(float delta)
    {
        if (Input.IsKeyPressed((int)KeyList.Space))
        {
            GetTree().ReloadCurrentScene();
        }
    }
}