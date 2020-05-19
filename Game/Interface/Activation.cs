using System;
using Godot;
using SshCity.Game.Plan;

public class Activation
{
    public static bool isNextToRoad(PlanInitial planInitial, Vector2 tile, int bloc)
    {
        Func<Vector2, bool> NextToRoad = delegate(Vector2 vector2)
        {
            bool nextTo = false;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    nextTo = nextTo || Routes.IsRoute(planInitial.GetBlock(planInitial.TileMap2, (int)tile.x, (int)tile.y));
                }
            }

            return nextTo;
        };
        
        bool res = false;
        (int largeur, int longueur) dimensions = (1, 1);
        try
        {
            dimensions = Ref_donnees.dimensions[bloc];
        }
        catch (Exception)
        {
        }

        for (int i = 0; i < dimensions.longueur; i++)
        {
            for (int j = 0; j < dimensions.largeur; j++)
            {
                res = res || NextToRoad(tile);
            }
        }

        return res;
    }
}
