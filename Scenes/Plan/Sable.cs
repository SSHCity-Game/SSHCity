using System.Collections.Generic;

namespace SshCity.Scenes.Plan
{
    public class Sable
    {
        public static void GenerateSable(PlanInitial planInitial, List<(int, int)> list_coord)
        {
            foreach (var coord in list_coord)
            {
                (int x, int y) = coord;
                SableGauche(planInitial, x, y);
                SableHaut(planInitial, x, y);
                SableBas(planInitial, x, y);
                SableDroite(planInitial, x, y);
            }
        }


        public static void SableDroite(PlanInitial planInitial, int x, int y)
        {
            if (planInitial.GetBlock(planInitial.TileMap1, x, y) == Ref_donnees.terre ||
                planInitial.GetBlock(planInitial.TileMap1, x, y) == Ref_donnees.sable)
            {
                planInitial.SetBlock(planInitial.TileMap1, x, y, Ref_donnees.sable);
            }
            else
            {
                if (planInitial.GetBlock(planInitial.TileMap1, x, y) == Ref_donnees.eau)
                {
                    SableDroite(planInitial, x + 1, y + 1);
                    SableDroite(planInitial, x + 1, y);
                    SableDroite(planInitial, x + 1, y - 1);
                }
            }
        }

        private static void SableGauche(PlanInitial planInitial, int x, int y)
        {
            if (planInitial.GetBlock(planInitial.TileMap1, x, y) == Ref_donnees.terre ||
                planInitial.GetBlock(planInitial.TileMap1, x, y) == Ref_donnees.sable)
            {
                planInitial.SetBlock(planInitial.TileMap1, x, y, Ref_donnees.sable);
            }
            else
            {
                if (planInitial.GetBlock(planInitial.TileMap1, x, y) == Ref_donnees.eau)
                {
                    SableGauche(planInitial, x - 1, y + 1);
                    SableGauche(planInitial, x - 1, y);
                    SableGauche(planInitial, x - 1, y - 1);
                }
            }
        }

        private static void SableHaut(PlanInitial planInitial, int x, int y)
        {
            if (planInitial.GetBlock(planInitial.TileMap1, x, y) == Ref_donnees.terre ||
                planInitial.GetBlock(planInitial.TileMap1, x, y) == Ref_donnees.sable)
            {
                planInitial.SetBlock(planInitial.TileMap1, x, y, Ref_donnees.sable);
            }

            if (planInitial.GetBlock(planInitial.TileMap1, x, y) == Ref_donnees.eau)
            {
                SableHaut(planInitial, x + 1, y + 1);
                SableHaut(planInitial, x, y + 1);
                SableHaut(planInitial, x - 1, y + 1);
            }
        }

        private static void SableBas(PlanInitial planInitial, int x, int y)
        {
            if (planInitial.GetBlock(planInitial.TileMap1, x, y) == Ref_donnees.terre ||
                planInitial.GetBlock(planInitial.TileMap1, x, y) == Ref_donnees.sable)
            {
                planInitial.SetBlock(planInitial.TileMap1, x, y, Ref_donnees.sable);
            }
            else
            {
                if (planInitial.GetBlock(planInitial.TileMap1, x, y) == Ref_donnees.eau)
                {
                    SableBas(planInitial, x + 1, y - 1);
                    SableBas(planInitial, x, y - 1);
                    SableBas(planInitial, x - 1, y - 1);
                }
            }
        }
    }
}