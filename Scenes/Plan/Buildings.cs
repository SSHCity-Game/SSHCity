using System;
using Godot;

namespace SshCity.Scenes.Plan
{
    public class Buildings
    {
        static Random rand = new Random();
        private static int x2;
        private static int y2;
        private static int acc;
        
        public static void GenerateBatiments(PlanInitial planInitial)
        {
            x2 = rand.Next(Ref_donnees.min_x + 8, Ref_donnees.max_x - 8);
            y2 = rand.Next(Ref_donnees.min_y + 8, Ref_donnees.max_y - 8);
            acc = 0;
            
            for (int i = x2; i < x2 + 5; i += 2) //CONSTRUCTION DES BATIMENTS
            {
                for (int j = y2; j < y2 + 5; j += 2)
                {
                    if (planInitial.GetBlock(planInitial.TileMap1, i, j) == Ref_donnees.index_terre)
                    {
                        planInitial.SetBlock(planInitial.TileMap2, i, j, Ref_donnees.index_maison);
                    }
                }
            }
        }

        public static void GenerateRouteVillage(PlanInitial planInitial)
        {
            for (int i = x2 + 1; i < x2 + 6; i++) //placement des routes
            {
                for (int j = y2 + 1; j < y2 + 6; j++)
                {
                    if (planInitial.GetBlock(planInitial.TileMap1, i, j) == Ref_donnees.index_terre)
                    {
                        planInitial.SetBlock(planInitial.TileMap1, i, j, Ref_donnees.index_route);
                    }
                }
            }
        }

        public static void GenerateRoutePlan(PlanInitial planInitial)
        {
            
        }

    }
}