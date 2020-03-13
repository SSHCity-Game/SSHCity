using System;
using System.Collections.Generic;

namespace SshCity.Scenes.Plan
{
    public class Montagnes
    {

	    private static Random rand;
        public static void Montagne(PlanInitial planInitial)
		{
			int nbr_m = rand.Next(Ref_donnees.m_min, Ref_donnees.m_max);
			int rand_m_x = rand.Next(Ref_donnees.min_x, Ref_donnees.max_x + 1);
			int rand_m_y = rand.Next(Ref_donnees.min_y, Ref_donnees.max_y + 1);
			int indexe_m = planInitial.GetBlock(planInitial.TileMap1, rand_m_x, rand_m_y); 
			if (indexe_m == Ref_donnees.index_terre)
			{
				planInitial.SetBlock(planInitial.TileMap4, rand_m_x, rand_m_y, Ref_donnees.indexe_montagne);
				planInitial.SetBlock(planInitial.TileMap1, rand_m_x, rand_m_y, Ref_donnees.indexe_montagne);
				Montagne_Lv2(planInitial, rand_m_x + 1, rand_m_y + 1);
				int i = 1;
				while (i < nbr_m)
				{
					int alea = rand.Next(0, 4);
					switch (alea)
					{
						case 0:
							{
								if (planInitial.GetBlock(planInitial.TileMap1, rand_m_x - 2, rand_m_y - 2) == Ref_donnees.index_terre)
								{
									rand_m_x -= 2;
									rand_m_y -= 2;
									planInitial.SetBlock(planInitial.TileMap1, rand_m_x, rand_m_y, Ref_donnees.indexe_montagne);
									planInitial.SetBlock(planInitial.TileMap4, rand_m_x, rand_m_y, Ref_donnees.indexe_montagne);
									Montagne_Lv2(planInitial, rand_m_x + 1, rand_m_y + 1);
									i++;
								}

								break;
							}
	
						case 1:
							{
								if (planInitial.GetBlock(planInitial.TileMap1, rand_m_x + 2, rand_m_y + 2) == Ref_donnees.index_terre)
								{
									rand_m_x += 2;
									rand_m_y += 2;
									planInitial.SetBlock(planInitial.TileMap1, rand_m_x, rand_m_y, Ref_donnees.indexe_montagne); 
									planInitial.SetBlock(planInitial.TileMap4, rand_m_x, rand_m_y, Ref_donnees.indexe_montagne);
									Montagne_Lv2(planInitial, rand_m_x + 1, rand_m_y + 1);
									i++;
								}

								break;
							}

						case 2:
							{
								if (planInitial.GetBlock(planInitial.TileMap1, rand_m_x - 2, rand_m_y + 2) == Ref_donnees.index_terre)
								{
									rand_m_x -= 2;
									rand_m_y += 2;
									planInitial.SetBlock(planInitial.TileMap1, rand_m_x, rand_m_y, Ref_donnees.indexe_montagne);
									planInitial.SetBlock(planInitial.TileMap4, rand_m_x, rand_m_y, Ref_donnees.indexe_montagne);
									Montagne_Lv2(planInitial, rand_m_x + 1, rand_m_y + 1);
									i++;
								}

								break;
							}

						case 3:
							{

								if (planInitial.GetBlock(planInitial.TileMap1, rand_m_x + 2, rand_m_y - 2) == Ref_donnees.index_terre)
								{
									rand_m_x += 2;
									rand_m_y -= 2;
									planInitial.SetBlock(planInitial.TileMap1, rand_m_x, rand_m_y, Ref_donnees.indexe_montagne);
									planInitial.SetBlock(planInitial.TileMap4, rand_m_x, rand_m_y, Ref_donnees.indexe_montagne);
									Montagne_Lv2(planInitial, rand_m_x + 1, rand_m_y + 1);
									i++;
								}

								break;
							}
					}
				}
			}
			else
			{
				Montagne(planInitial);
			}
		}
	
	//FONCTION CREANT LA MONTAGNE AU NIVEAU2 (TileMap3)
	private static void Montagne_Lv2(PlanInitial planInitial, int x, int y)
	{
		if (planInitial.GetBlock(planInitial.TileMap1, x - 1, y - 1) == Ref_donnees.index_terre || planInitial.GetBlock(planInitial.TileMap1, x - 1, y - 1) == Ref_donnees.indexe_montagne)
		{
			planInitial.SetBlock(planInitial.TileMap1, x - 1, y - 1, Ref_donnees.indexe_montagne);
			planInitial.SetBlock(planInitial.TileMap3, x - 1, y - 1, Ref_donnees.indexe_montagne);
			Montagne_Lv3(x, y);
		}
		if (planInitial.GetBlock(planInitial.TileMap1, x + 1, y + 1) == Ref_donnees.index_terre || planInitial.GetBlock(planInitial.TileMap1, x + 1, y + 1) == Ref_donnees.indexe_montagne)
		{
			planInitial.SetBlock(planInitial.TileMap2, x + 1, y + 1, Ref_donnees.indexe_montagne);
			planInitial.SetBlock(planInitial.TileMap1, x + 1, y + 1, Ref_donnees.indexe_montagne);
			Montagne_Lv3(x + 2, y + 2);
		}
		if (planInitial.GetBlock(planInitial.TileMap1, x, y - 1) == Ref_donnees.index_terre || planInitial.GetBlock(planInitial.TileMap1, x, y - 1) == Ref_donnees.indexe_montagne)
		{
			planInitial.SetBlock(planInitial.TileMap3, x, y - 1, Ref_donnees.indexe_montagne);
			planInitial.SetBlock(planInitial.TileMap1, x, y - 1, Ref_donnees.indexe_montagne);
			Montagne_Lv3(x + 1, y);
		}
		if (_tileMap1.GetCell(x - 1, y) == Ref_donnees.index_terre || _tileMap1.GetCell(x - 1, y) == Ref_donnees.indexe_montagne)
		{
			_tileMap3.SetCell(x - 1, y, Ref_donnees.indexe_montagne);
			_tileMap1.SetCell(x - 1, y, Ref_donnees.indexe_montagne);
			Montagne_Lv3(x, y + 1);
		}
		if (_tileMap1.GetCell(x - 1, y + 1) == Ref_donnees.index_terre || _tileMap1.GetCell(x - 1, y + 1) == Ref_donnees.indexe_montagne)
		{
			_tileMap3.SetCell(x - 1, y + 1, Ref_donnees.indexe_montagne);
			_tileMap1.SetCell(x - 1, y + 1, Ref_donnees.indexe_montagne);
			Montagne_Lv3(x, y + 2);
		}
		if (_tileMap1.GetCell(x + 1, y - 1) == Ref_donnees.index_terre || _tileMap1.GetCell(x + 1, y - 1) == Ref_donnees.indexe_montagne)
		{
			_tileMap3.SetCell(x + 1, y - 1, Ref_donnees.indexe_montagne);
			_tileMap1.SetCell(x + 1, y - 1, Ref_donnees.indexe_montagne);
			Montagne_Lv3(x + 2, y);
		}
		if (_tileMap1.GetCell(x + 1, y) == Ref_donnees.index_terre || _tileMap1.GetCell(x + 1, y) == Ref_donnees.indexe_montagne)
		{
			_tileMap3.SetCell(x + 1, y, Ref_donnees.indexe_montagne);
			_tileMap1.SetCell(x + 1, y, Ref_donnees.indexe_montagne);
			Montagne_Lv3(x + 2, y + 1);
		}
		if (_tileMap1.GetCell(x, y + 1) == Ref_donnees.index_terre || _tileMap1.GetCell(x, y + 1) == Ref_donnees.indexe_montagne)
		{
			_tileMap3.SetCell(x, y + 1, Ref_donnees.indexe_montagne);
			_tileMap1.SetCell(x, y + 1, Ref_donnees.indexe_montagne);
			Montagne_Lv3(x + 1, y + 2);
		}
	}

	// FONCTION CREANT LA MONTAGNE AU NIVEAU DU SOL (TileMap2)
	private static void Montagne_Lv3(int x, int y)
	{
		if (_tileMap1.GetCell(x - 1, y - 1) == Ref_donnees.index_terre)
		{
			_tileMap1.SetCell(x - 1, y - 1, Ref_donnees.indexe_montagne);
			_tileMap2.SetCell(x - 1, y - 1, Ref_donnees.indexe_montagne);
		}
		if (_tileMap1.GetCell(x + 1, y + 1) == Ref_donnees.index_terre)
		{
			_tileMap2.SetCell(x + 1, y + 1, Ref_donnees.indexe_montagne);
			_tileMap1.SetCell(x + 1, y + 1, Ref_donnees.indexe_montagne);

		}
		if (_tileMap1.GetCell(x, y - 1) == Ref_donnees.index_terre)
		{
			_tileMap2.SetCell(x, y - 1, Ref_donnees.indexe_montagne);
			_tileMap1.SetCell(x, y - 1, Ref_donnees.indexe_montagne);

		}
		if (_tileMap1.GetCell(x - 1, y) == Ref_donnees.index_terre)
		{
			_tileMap2.SetCell(x - 1, y, Ref_donnees.indexe_montagne);
			_tileMap1.SetCell(x - 1, y, Ref_donnees.indexe_montagne);

		}
		if (_tileMap1.GetCell(x - 1, y + 1) == Ref_donnees.index_terre)
		{
			_tileMap2.SetCell(x - 1, y + 1, Ref_donnees.indexe_montagne);
			_tileMap1.SetCell(x - 1, y + 1, Ref_donnees.indexe_montagne);

		}
		if (_tileMap1.GetCell(x + 1, y - 1) == Ref_donnees.index_terre)
		{
			_tileMap2.SetCell(x + 1, y - 1, Ref_donnees.indexe_montagne);
			_tileMap1.SetCell(x + 1, y - 1, Ref_donnees.indexe_montagne);

		}
		if (_tileMap1.GetCell(x + 1, y) == Ref_donnees.index_terre)
		{
			_tileMap2.SetCell(x + 1, y, Ref_donnees.indexe_montagne);
			_tileMap1.SetCell(x + 1, y, Ref_donnees.indexe_montagne);

		}

		if (_tileMap1.GetCell(x, y + 1) == Ref_donnees.index_terre)
		{
			_tileMap2.SetCell(x, y + 1, Ref_donnees.indexe_montagne);
			_tileMap1.SetCell(x, y + 1, Ref_donnees.indexe_montagne);
		}
	}
    }
}