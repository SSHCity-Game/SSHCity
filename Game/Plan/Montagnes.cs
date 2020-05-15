using System;
using Godot;

namespace SshCity.Game.Plan
{
    public class Montagnes
    {
        private static Random rand = new Random();

        public static void SetBlocMontagne(Vector2 tile, PlanInitial planInitial)
        {
            int x = (int) tile.x;
            int y = (int) tile.y;
            planInitial.SetBlock(planInitial.TileMap2, x - 1, y - 1, Ref_donnees.montagne);
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    planInitial.SetBlock(planInitial.TileMap1, x - i, y - j, Ref_donnees.montagne_sol);
                }
            }
        }

        public static bool VerifMontagne(int x, int y, PlanInitial planInitial)
        {
            bool res = true;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    res = res && (planInitial.GetBlock(planInitial.TileMap1, x - i, y - j) == Ref_donnees.terre ||
                                  planInitial.GetBlock(planInitial.TileMap1, x - i, y - j) == Ref_donnees.montagne_sol);
                }
            }

            return res;
        }

        public static void GenerateMontagne(PlanInitial planInitial)
        {
            int nbr_m = rand.Next(Ref_donnees.m_min, Ref_donnees.m_max);
            int rand_m_x = rand.Next(Ref_donnees.min_x, Ref_donnees.max_x + 1);
            int rand_m_y = rand.Next(Ref_donnees.min_y, Ref_donnees.max_y + 1);
            int indexe_m = planInitial.GetBlock(planInitial.TileMap1, rand_m_x, rand_m_y);

            if (VerifMontagne(rand_m_x, rand_m_y, planInitial))
            {
                SetBlocMontagne(new Vector2(rand_m_x, rand_m_y), planInitial);
                int i = 1;
                while (i < nbr_m)
                {
                    int alea = rand.Next(0, 4);
                    switch (alea)
                    {
                        case 0:
                        {
                            if (VerifMontagne(rand_m_x - 2, rand_m_y, planInitial))
                            {
                                rand_m_x -= 2;
                                SetBlocMontagne(new Vector2(rand_m_x, rand_m_y), planInitial);
                                i++;
                            }

                            break;
                        }

                        case 1:
                        {
                            if (VerifMontagne(rand_m_x + 2, rand_m_y, planInitial))
                            {
                                rand_m_x += 2;
                                SetBlocMontagne(new Vector2(rand_m_x, rand_m_y), planInitial);
                                i++;
                            }

                            break;
                        }

                        case 2:
                        {
                            if (VerifMontagne(rand_m_x, rand_m_y + 2, planInitial))
                            {
                                rand_m_y += 2;
                                SetBlocMontagne(new Vector2(rand_m_x, rand_m_y), planInitial);
                                i++;
                            }

                            break;
                        }

                        case 3:
                        {
                            if (VerifMontagne(rand_m_x, rand_m_y - 2, planInitial))
                            {
                                rand_m_y -= 2;
                                SetBlocMontagne(new Vector2(rand_m_x, rand_m_y), planInitial);
                                i++;
                            }

                            break;
                        }
                    }
                }
            }
            else
            {
                GenerateMontagne(planInitial);
            }
        }
    }
}