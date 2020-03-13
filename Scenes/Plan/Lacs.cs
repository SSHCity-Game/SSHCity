using System;
using System.Collections.Generic;
using Godot;

namespace SshCity.Scenes.Plan
{	
	/// <summary>
    /// test
	///Fonction créant les lacs
	/// </summary>
    public class Lacs
    {

	    public static Random rand;
	    
        public static List<(int, int)> GenerateLac(PlanInitial _planInitial)
        {
	        
	        rand = new Random();
	        int nbr_flaque_eau = rand.Next(Ref_donnees.min_flaque_eau, Ref_donnees.max_flaque_eau + 1);
	        List<(int, int)> coordonnes_base_flaques = new List<(int, int)>();
            for (int i = 0; i < nbr_flaque_eau; i++)
			{
				int rand_x = rand.Next(Ref_donnees.min_x, Ref_donnees.max_x + 1);
				int rand_y = rand.Next(Ref_donnees.min_y, Ref_donnees.max_y + 1);
				int indexe = _planInitial.GetBlock(_planInitial.TileMap1, rand_x, rand_y);
				if (indexe == 0)
				{
					coordonnes_base_flaques.Add((rand_x, rand_y));
					int nbr_block_eau = rand.Next(Ref_donnees.min_block_flaque_eau, Ref_donnees.max_block_flaque_eau + 1);
					_planInitial.SetBlock(_planInitial.TileMap1,rand_x, rand_y, Ref_donnees.index_eau);
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
									if (_planInitial.GetBlock(_planInitial.TileMap1, rand_x, rand_y) == Ref_donnees.index_terre)
									{
										_planInitial.SetBlock(_planInitial.TileMap1 ,rand_x, rand_y, Ref_donnees.index_eau);
									}
									if (_planInitial.GetBlock(_planInitial.TileMap1,rand_x + 1, rand_y) == Ref_donnees.index_terre)
									{

										_planInitial.SetBlock(_planInitial.TileMap1,rand_x, rand_y, Ref_donnees.index_eau);
										j++;
										if (_planInitial.GetBlock(_planInitial.TileMap1,rand_x + 1, rand_y) == Ref_donnees.index_terre)
										{
											_planInitial.SetBlock(_planInitial.TileMap1,rand_x + 1, rand_y, Ref_donnees.index_eau);
											j++;
										}
										if (_planInitial.GetBlock(_planInitial.TileMap1,rand_x, rand_y + 1) == Ref_donnees.index_terre)
										{ _planInitial.SetBlock(_planInitial.TileMap1,rand_x, rand_y + 1, Ref_donnees.index_eau);
											j++;
										}

										if (_planInitial.GetBlock(_planInitial.TileMap1,rand_x, rand_y - 1) == Ref_donnees.index_terre)
										{
											_planInitial.SetBlock(_planInitial.TileMap1,rand_x, rand_y - 1, Ref_donnees.index_eau);
											j++;
										}
									}
									break;
								}

						case 1:
							{
								rand_x--;
								if (_planInitial.GetBlock(_planInitial.TileMap1, rand_x, rand_y) == Ref_donnees.index_terre)
								{
									_planInitial.SetBlock(_planInitial.TileMap1, rand_x, rand_y, Ref_donnees.index_eau);
								}

								if (_planInitial.GetBlock(_planInitial.TileMap1, rand_x - 1, rand_y) == Ref_donnees.index_terre)
								{

									_planInitial.SetBlock(_planInitial.TileMap1,rand_x - 1, rand_y, Ref_donnees.index_eau);
									j++;
									if (_planInitial.GetBlock(_planInitial.TileMap1,rand_x - 1, rand_y) == Ref_donnees.index_terre)
									{
										_planInitial.SetBlock(_planInitial.TileMap1,rand_x - 1, rand_y, Ref_donnees.index_eau);
										j++;
									}
									if (_planInitial.GetBlock(_planInitial.TileMap1, rand_x, rand_y + 1) == Ref_donnees.index_terre)
									{
										_planInitial.SetBlock(_planInitial.TileMap1, rand_x, rand_y + 1, Ref_donnees.index_eau);
										j++;
									}
									if (_planInitial.GetBlock(_planInitial.TileMap1, rand_x, rand_y - 1) == Ref_donnees.index_terre)
									{
										_planInitial.SetBlock(_planInitial.TileMap1, rand_x, rand_y - 1, Ref_donnees.index_eau);
										j++;
									}
								}
								break;
							}

						case 2:
							{
								rand_y++;
								if (_planInitial.GetBlock(_planInitial.TileMap1, rand_x, rand_y) == Ref_donnees.index_terre)
								{
									_planInitial.SetBlock(_planInitial.TileMap1, rand_x, rand_y, Ref_donnees.index_eau);
								}

								if (_planInitial.GetBlock(_planInitial.TileMap1, rand_x, rand_y + 1) == Ref_donnees.index_terre)
								{
									_planInitial.SetBlock(_planInitial.TileMap1, rand_x, rand_y, Ref_donnees.index_eau);
									j++;
									if (_planInitial.GetBlock(_planInitial.TileMap1, rand_x + 1, rand_y) == Ref_donnees.index_terre)
									{
										_planInitial.SetBlock(_planInitial.TileMap1, rand_x + 1, rand_y, Ref_donnees.index_eau);
										j++;
									}
									if (_planInitial.GetBlock(_planInitial.TileMap1, rand_x - 1, rand_y) == Ref_donnees.index_terre)
									{
										_planInitial.SetBlock(_planInitial.TileMap1, rand_x - 1, rand_y, Ref_donnees.index_eau);
										j++;
									}
									if (_planInitial.GetBlock(_planInitial.TileMap1, rand_x, rand_y + 1) == Ref_donnees.index_terre)
									{
										_planInitial.SetBlock(_planInitial.TileMap1, rand_x, rand_y + 1, Ref_donnees.index_eau);
										j++;
									}
								}
								break;
							}
						case 3:
							{
								rand_y--;
								if (_planInitial.GetBlock(_planInitial.TileMap1, rand_x, rand_y) == Ref_donnees.index_terre)
								{
									_planInitial.SetBlock(_planInitial.TileMap1, rand_x, rand_y, Ref_donnees.index_eau);
								}

								if (_planInitial.GetBlock(_planInitial.TileMap1, rand_x, rand_y - 1) == Ref_donnees.index_terre)
								{
									_planInitial.SetBlock(_planInitial.TileMap1, rand_x, rand_y, Ref_donnees.index_eau);
									j++;
									if (_planInitial.GetBlock(_planInitial.TileMap1, rand_x + 1, rand_y) == Ref_donnees.index_terre)
									{
										_planInitial.SetBlock(_planInitial.TileMap1, rand_x + 1, rand_y, Ref_donnees.index_eau);
										j++;
									}
									if (_planInitial.GetBlock(_planInitial.TileMap1, rand_x - 1, rand_y) == Ref_donnees.index_terre)
									{
										_planInitial.SetBlock(_planInitial.TileMap1, rand_x - 1, rand_y, Ref_donnees.index_eau);
										j++;
									}
									if (_planInitial.GetBlock(_planInitial.TileMap1, rand_x, rand_y - 1) == Ref_donnees.index_terre)
									{
										_planInitial.SetBlock(_planInitial.TileMap1, rand_x, rand_y - 1, Ref_donnees.index_eau);
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

            return coordonnes_base_flaques;
        }
    }
}