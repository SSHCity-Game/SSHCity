using System;
using System.Collections.Generic;
using Godot;

namespace SshCity.Scenes.Plan
{
    public class Montagnes
    {
	    private static Random rand = new Random();

        public static void SetBlocMontagne(Vector2 tile, PlanInitial planInitial)
        {
            int x = (int) tile.x;
            int y = (int) tile.y;
            planInitial.SetBlock(planInitial.TileMap2, x-1, y-1, Ref_donnees.montagne);
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    planInitial.SetBlock(planInitial.TileMap1, x-i, y-j, Ref_donnees.montagne_sol);
                    GD.Print("OK");
                }
            }
        }
    }
}