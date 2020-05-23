using System;
using System.Collections.Generic;
using Godot;

namespace SshCity.Game.Plan
{
    /// <summary>
    /// test
    ///Fonction créant les lacs
    /// </summary>
    public class Lacs
    {
        public static Random rand;

        enum TypeLac
        {
            LAC1,
            LAC2
        }
        
        private static List<TypeLac> listTypeLacs = new List<TypeLac>()
        {
            TypeLac.LAC1,
            TypeLac.LAC2
        };

        private static List<Vector2> ListBlocLac1 = new List<Vector2>()
        {
            new Vector2(0, 0),
            new Vector2(0, -1),
            new Vector2(0, -2),
            new Vector2(0, -3),
            new Vector2(0, -4),
            new Vector2(0, 1),
            new Vector2(0, 2),
            new Vector2(0, 3),
            new Vector2(0, 4),
            new Vector2(1, 0),
            new Vector2(2, 0),
            new Vector2(3, 0),
            new Vector2(3, 1),
            new Vector2(2, 1),
            new Vector2(1, 1),
            new Vector2(1, 2),
            new Vector2(1, 3),
            new Vector2(1, 4),
            new Vector2(2, 4),
            new Vector2(2, 3),
            new Vector2(2,2),
            new Vector2(3, 2),
            new Vector2(2, 4),
            new Vector2(1, -1),
            new Vector2(2, -1),
            new Vector2(3, -1),
            new Vector2(1, -2),
            new Vector2(2, -2),
            new Vector2(1, -3),
            new Vector2(2, -3),
            new Vector2(1, -4),
            new Vector2(-1, 0),
            new Vector2(-2, 0),
            new Vector2(-1, 1),
            new Vector2(-2, 1),
            new Vector2(-1, 2),
            new Vector2(-2, 2),
            new Vector2(-1, 3),
            new Vector2(-2, 3),
            new Vector2(-1, 4),
            new Vector2(-1, -1),
            new Vector2(-2, -1),
            new Vector2(-1, -2),
            new Vector2(-2, -2),
            new Vector2(-1, -3),
            new Vector2(-2, -3),
            new Vector2(-1, -4)
        };
        
        private static List<Vector2> ListBlocLac2 = new List<Vector2>()
        {
            new Vector2(0, 0),
            new Vector2(0,1),
            new Vector2(0,2),
            new Vector2(0,3),
            new Vector2(0,4),
            new Vector2(0, -1),
            new Vector2(0, -2),
            new Vector2(0, 3),
            new Vector2(0, -4),
            new Vector2(0, -5),
            new Vector2(1, 0),
            new Vector2(2, 0),
            new Vector2(3, 0),
            new Vector2(4, 0),
            new Vector2(5, 0),
            new Vector2(-1, 0),
            new Vector2(-2, 0),
            new Vector2(-3, 0),
            new Vector2(-4, 0),
            new Vector2(-5, 0),
            new Vector2(1, 1),
            new Vector2(2, 1),
            new Vector2(3, 1),
            new Vector2(4, 1),
            new Vector2(1, 2),
            new Vector2(2, 2),
            new Vector2(3, 2),
            new Vector2(4, 2),
            new Vector2(1, 3),
            new Vector2(2, 3),
            new Vector2(3, 3),
            new Vector2(4, 3),
            new Vector2(1, 4),
            new Vector2(2, 4),
            new Vector2(3, 4),
            new Vector2(1, 5),
            new Vector2(1, -1),
            new Vector2(2, -1),
            new Vector2(3, -1),
            new Vector2(4, -1),
            new Vector2(1, -2),
            new Vector2(2, -2),
            new Vector2(3, -2),
            new Vector2(4, -2),
            new Vector2(1, -3),
            new Vector2(2, -3),
            new Vector2(3, -3),
            new Vector2(1, -4),
            new Vector2(2, -4),
            new Vector2(-1, 1),
            new Vector2(-1, 2),
            new Vector2(-1, 3),
            new Vector2(-1, 4),
            new Vector2(-2, 1),
            new Vector2(-2, 2),
            new Vector2(-2, 3),
            new Vector2(-3, 1),
            new Vector2(-3, 2),
            new Vector2(-4, 1),
            new Vector2(-1, -1),
            new Vector2(-1, -2),
            new Vector2(-1, -3),
            new Vector2(-1, -4),
            new Vector2(-1, -5),
            new Vector2(-2, -1),
            new Vector2(-2, -2),
            new Vector2(-2, -3),
            new Vector2(-2, -4),
            new Vector2(-2, -5),
            new Vector2(-3, -1),
            new Vector2(-3, -2),
            new Vector2(-3, -3),
            new Vector2(-3, -4),
            new Vector2(-3, -5),
            new Vector2(-4, -1),
            new Vector2(-4, -2),
            new Vector2(-4, -3),
            new Vector2(-4, -4),
            new Vector2(-5, -1),
            new Vector2(-5, -2),
            new Vector2(-5, -3),
            new Vector2(-5, -4),
        };
        

        public static void GenerateLac(PlanInitial planInitial)
        {
            Random random = new Random();
            int nbLac = random.Next(Ref_donnees.min_flaque_eau, Ref_donnees.max_flaque_eau);
            int i = 0;
            while (i < nbLac)
            {
                int x = random.Next(Ref_donnees.min_x, Ref_donnees.max_x);
                int y = random.Next(Ref_donnees.min_y, Ref_donnees.max_y);
                if (planInitial.GetBlock(planInitial.TileMap1, x, y) == Ref_donnees.terre
                    && planInitial.GetBlock(planInitial.TileMap2, x-1, y-1) == -1)
                {
                    int WhichLac = random.Next(0, listTypeLacs.Count);
                    TypeLac lac = listTypeLacs[WhichLac];
                    List<Vector2> lacBlocToSet;
                    int blocLac;
                    if (lac == TypeLac.LAC1)
                    {
                        blocLac = Ref_donnees.lac1;
                        lacBlocToSet = ListBlocLac1;
                    }
                    else
                    {
                        blocLac = Ref_donnees.lac2;
                        lacBlocToSet = ListBlocLac2;
                    }
                    if (VerifLac(new Vector2(x, y), planInitial, lacBlocToSet))
                    {
                        planInitial.SetBlock(planInitial.TileMap2, x, y, blocLac);
                        planInitial.SetBlock(planInitial.TileMapWithoutRoute, x, y, blocLac);
                        Bateau bateau = (Bateau) planInitial._bateauxScene.Instance();
                        bateau.Init(planInitial, planInitial.TileMap1.MapToWorld(new Vector2(x+1, y+1)));
                        planInitial.AddChild(bateau);
                        foreach (Vector2 vector2 in lacBlocToSet)
                        { 
                            planInitial.SetBlock(planInitial.TileMap1, (int) x + (int) vector2.x,
                                (int) y + (int) vector2.y, Ref_donnees.water_terre);
                            planInitial.SetBlock(planInitial.TileMap0, (int) x + (int) vector2.x,
                                (int) y + (int) vector2.y, Ref_donnees.eau);
                        }

                        i += 1;
                    }
                }
            }
        }

        public static bool VerifLac(Vector2 tile, PlanInitial planInitial, List<Vector2> list)
        {
            bool valid = true;
            foreach (Vector2 vector2 in list)
            {
                if (!valid)
                {
                    break;
                }
                valid = planInitial.GetBlock(planInitial.TileMap1, (int) tile.x + (int) vector2.x,
                            (int) tile.y + (int) vector2.y) == Ref_donnees.terre
                        && planInitial.GetBlock(planInitial.TileMap2, (int) tile.x + (int) vector2.x-1,
                            (int) tile.y + (int) vector2.y -1) == -1;
            }
            return valid;
        }
    }
}