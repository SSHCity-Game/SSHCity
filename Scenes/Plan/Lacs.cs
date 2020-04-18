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
				
				if (Valid_Position(rand_x, rand_y, _planInitial))//Si tous les blocs au tour sont des blocs terre ou eau alors on commence a creer le lac
				{
					coordonnes_base_flaques.Add((rand_x, rand_y));

					int nbr_block_eau = rand.Next(Ref_donnees.min_block_flaque_eau, Ref_donnees.max_block_flaque_eau + 1);
					_planInitial.SetBlock(_planInitial.TileMap1,rand_x, rand_y, Ref_donnees.eau);
					int j = 1;
					while (j < nbr_block_eau)
					{
						int deplacement = rand.Next(0, 4);

						switch (deplacement)
						{
							case 0:
								{
									rand_x++;
									if (Valid_Position(rand_x, rand_y, _planInitial))
									{
										_planInitial.SetBlock(_planInitial.TileMap1 ,rand_x, rand_y, Ref_donnees.eau);
										j++;
										if (Valid_Position(rand_x+1, rand_y, _planInitial))
										{ 
											_planInitial.SetBlock(_planInitial.TileMap1,rand_x + 1, rand_y, Ref_donnees.eau);
											j++;
										}
										if (Valid_Position(rand_x, rand_y+1, _planInitial))
										{ 
											_planInitial.SetBlock(_planInitial.TileMap1,rand_x, rand_y + 1, Ref_donnees.eau);
											j++;
										}

										if (Valid_Position(rand_x, rand_y-1, _planInitial))
										{
											_planInitial.SetBlock(_planInitial.TileMap1,rand_x, rand_y - 1, Ref_donnees.eau);
											j++;
										}
									}
									else
									{
										rand_x--;
									}
									break;
								}

						case 1:
							{
								rand_x--;
								if (Valid_Position(rand_x, rand_y, _planInitial))
								{
									_planInitial.SetBlock(_planInitial.TileMap1, rand_x, rand_y, Ref_donnees.eau);
									j++;
									if (Valid_Position(rand_x-1, rand_y, _planInitial))
									{ 
										_planInitial.SetBlock(_planInitial.TileMap1,rand_x - 1, rand_y, Ref_donnees.eau);
										j++;
									}
									if (Valid_Position(rand_x, rand_y+1, _planInitial))
									{ _planInitial.SetBlock(_planInitial.TileMap1,rand_x, rand_y + 1, Ref_donnees.eau);
										j++;
									}

									if (Valid_Position(rand_x, rand_y-1, _planInitial))
									{
										_planInitial.SetBlock(_planInitial.TileMap1,rand_x, rand_y - 1, Ref_donnees.eau);
										j++;
									}
								}
								else
								{
									rand_x++;
								}
								break;
							}

						case 2:
							{
								rand_y++;
								if (Valid_Position(rand_x, rand_y, _planInitial))
								{
									_planInitial.SetBlock(_planInitial.TileMap1, rand_x, rand_y, Ref_donnees.eau);
									j++;
									if (Valid_Position(rand_x+1, rand_y, _planInitial))
									{ 
										_planInitial.SetBlock(_planInitial.TileMap1,rand_x + 1, rand_y, Ref_donnees.eau);
										j++;
									}
									if (Valid_Position(rand_x-1, rand_y, _planInitial))
									{ _planInitial.SetBlock(_planInitial.TileMap1,rand_x-1, rand_y, Ref_donnees.eau);
										j++;
									}

									if (Valid_Position(rand_x, rand_y+1, _planInitial))
									{
										_planInitial.SetBlock(_planInitial.TileMap1,rand_x, rand_y + 1, Ref_donnees.eau);
										j++;
									}
								}
								else
								{
									rand_y--;
								}
								break;
							}
						case 3:
							{
								rand_y--;
								if (Valid_Position(rand_x, rand_y, _planInitial))
								{
									_planInitial.SetBlock(_planInitial.TileMap1, rand_x, rand_y, Ref_donnees.eau);
									j++;
									if (Valid_Position(rand_x, rand_y-1, _planInitial))
									{ 
										_planInitial.SetBlock(_planInitial.TileMap1,rand_x , rand_y-1, Ref_donnees.eau);
										j++;
									}
									if (Valid_Position(rand_x+1, rand_y, _planInitial))
									{ _planInitial.SetBlock(_planInitial.TileMap1,rand_x+1, rand_y, Ref_donnees.eau);
										j++;
									}

									if (Valid_Position(rand_x-1, rand_y, _planInitial))
									{
										_planInitial.SetBlock(_planInitial.TileMap1,rand_x-1, rand_y, Ref_donnees.eau);
										j++;
									}
								}
								else
								{
									rand_y++;
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
        
        public static int[] BlocksNextTo(PlanInitial planInitial, int x, int y)
        {
			int[] res = new int[9];
			res[0] = planInitial.GetBlock(planInitial.TileMap1, x, y);
			res[1] = planInitial.GetBlock(planInitial.TileMap1, x+1, y);
			res[2] = planInitial.GetBlock(planInitial.TileMap1, x+1, y+1);
			res[3] = planInitial.GetBlock(planInitial.TileMap1, x, y+1);
			res[4] = planInitial.GetBlock(planInitial.TileMap1, x-1, y+1);
			res[5] = planInitial.GetBlock(planInitial.TileMap1, x-1, y);
			res[6] = planInitial.GetBlock(planInitial.TileMap1, x-1, y-1);
			res[7] = planInitial.GetBlock(planInitial.TileMap1, x, y-1);
			res[8] = planInitial.GetBlock(planInitial.TileMap1, x+1, y-1);

			return res;
        }

        public static bool Valid_Position(int x, int y, PlanInitial planInitial)
        {
	        bool creation = true;
	        int[] BlocNext = BlocksNextTo(planInitial, x, y);
	        foreach (int index in BlocNext)
	        {
		        creation =
			        creation &&
			        (index == Ref_donnees.terre || index == Ref_donnees.eau);
	        }

	        return creation;
        }
        
    }
}