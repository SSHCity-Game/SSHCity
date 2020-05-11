using System;
using System.Diagnostics.Tracing;
using Godot;
using SshCity.Scenes.Buildings;

namespace SshCity.Scenes.Plan
{
    public class Buildings
    {
        static Random rand = new Random();

        public static void GenerateBatiments(PlanInitial planInitial, int x, int y)
        {
            int[] batiments = new[]
            {
                Ref_donnees.parc_enfant, Ref_donnees.maison3, Ref_donnees.ferme,
                Ref_donnees.maison4, Ref_donnees.mairie, Ref_donnees.maison5,
                Ref_donnees.eglise, Ref_donnees.restaurant, Ref_donnees.restaurant2
            };

            int k = 0;
            for (int i = x; i < x + 5; i += 2) //CONSTRUCTION DES BATIMENTS
            {
                for (int j = y; j < y + 5; j += 2)
                {
                    int bloc_set = batiments[k];
                    planInitial.SetBlock(planInitial.TileMap2, i - 1, j - 1, bloc_set);

                    switch (k)
                    {
                        case 0:
                        {
                            new Batiments.Building(Batiments.Class.PARC, new Vector2(i-1, j-1));
                            break;
                        }
                        case 1:
                        {
                            new Batiments.Building(Batiments.Class.MAISON3, new Vector2(i-1, j-1));
                            break;
                        }
                        case 2:
                        {
                            //new Batiments.Building(Batiments.Class.FERME, new Vector2(i-1, j-1));
                            break;
                        }
                        case 3:
                        {
                            new Batiments.Building(Batiments.Class.MAISON4, new Vector2(i-1, j-1));
                            break;
                        }
                        case 5:
                        {
                            new Batiments.Building(Batiments.Class.MAISON5, new Vector2(i-1, j-1));
                            break;
                        }
                        case 6:
                        {
                            //new Batiments.Building(Batiments.Class.EGLISE, new Vector2(i-1, j-1));
                            break;
                        }
                        case 7:
                        {
                            new Batiments.Building(Batiments.Class.RESTAURANT, new Vector2(i-1, j-1));
                            break;
                        }
                        case 8:
                        {
                            new Batiments.Building(Batiments.Class.RESTAURANT2, new Vector2(i-1, j-1));
                            break;
                        }
                    }
                    MainPlan.ListeBatiment.Add((new Vector2(i-1, j-1), bloc_set));
                    k++;
                }
            }
        }

        public static void GenerateRouteVillage(PlanInitial planInitial, int x, int y)
        {
            for (int i = x; i < x + 5; i++) //placement des routes
            {
                for (int j = y ; j < y+5 ; j++)
                {
                    if (planInitial.GetBlock(planInitial.TileMap1, i, j) == Ref_donnees.terre || planInitial.GetBlock(planInitial.TileMap1, i, j) == Ref_donnees.maison1)
                    {
                        planInitial.SetBlock(planInitial.TileMap1, i, j, Ref_donnees.route);
                    }
                }
            }
            //Route au tour de la mairie
            planInitial.SetBlock(planInitial.TileMap2, x, y, Ref_donnees.route_croisement);
            planInitial.SetBlock(planInitial.TileMap2, x+2, y, Ref_donnees.route_croisement);
            planInitial.SetBlock(planInitial.TileMap2, x, y+2, Ref_donnees.route_croisement);
            planInitial.SetBlock(planInitial.TileMap2, x+2, y+2, Ref_donnees.route_croisement);
            planInitial.SetBlock(planInitial.TileMap2, x+1, y, Ref_donnees.route_left);
            planInitial.SetBlock(planInitial.TileMap2, x+1, y+2, Ref_donnees.route_left);
            planInitial.SetBlock(planInitial.TileMap2, x, y+1, Ref_donnees.route_right);
            planInitial.SetBlock(planInitial.TileMap2, x+2, y+1, Ref_donnees.route_right);

            //Routes exterieurs du village
            if (planInitial.GetBlock(planInitial.TileMap2, x, y-2) == Ref_donnees.route_left)
            {
                planInitial.SetBlock(planInitial.TileMap2, x, y-2, Ref_donnees.route_T_bas_gauche);
                planInitial.SetBlock(planInitial.TileMap2, x, y-1, Ref_donnees.route_right);
            }
            else
            {
                planInitial.SetBlock(planInitial.TileMap2, x, y-1, Ref_donnees.route_bord_haut_droit);
            }

            if (planInitial.GetBlock(planInitial.TileMap2, x+2, y-2) == Ref_donnees.route_left)
            {
                planInitial.SetBlock(planInitial.TileMap2, x+2, y-2, Ref_donnees.route_T_bas_gauche);
                planInitial.SetBlock(planInitial.TileMap2, x+2, y-1, Ref_donnees.route_right);
            }
            else
            {
                planInitial.SetBlock(planInitial.TileMap2, x+2, y-1, Ref_donnees.route_bord_haut_droit);
            }

            if (planInitial.GetBlock(planInitial.TileMap2, x+4, y) == Ref_donnees.route_right)
            {
                planInitial.SetBlock(planInitial.TileMap2, x+4, y, Ref_donnees.route_T_haut_gauche);
                planInitial.SetBlock(planInitial.TileMap2, x+3, y, Ref_donnees.route_left);
            }
            else
            {
                planInitial.SetBlock(planInitial.TileMap2, x+3, y, Ref_donnees.route_bord_bas_droit);
            }

            if (planInitial.GetBlock(planInitial.TileMap2, x+4, y+2) == Ref_donnees.route_right)
            {
                planInitial.SetBlock(planInitial.TileMap2, x+4, y+2, Ref_donnees.route_T_haut_gauche);
                planInitial.SetBlock(planInitial.TileMap2, x+3, y+2, Ref_donnees.route_left);
            }
            else
            {
                planInitial.SetBlock(planInitial.TileMap2, x+3, y+2, Ref_donnees.route_bord_bas_droit);
            }

            if (planInitial.GetBlock(planInitial.TileMap2, x+2, y+4) == Ref_donnees.route_left)
            {
                planInitial.SetBlock(planInitial.TileMap2, x+2, y+4, Ref_donnees.route_T_haut_droit);
                planInitial.SetBlock(planInitial.TileMap2, x+2, y+3, Ref_donnees.route_right);
            }
            else
            {
                planInitial.SetBlock(planInitial.TileMap2, x+2, y+3, Ref_donnees.route_bord_bas_gauche);
            }

            if (planInitial.GetBlock(planInitial.TileMap2, x, y+4) == Ref_donnees.route_left)
            {
                planInitial.SetBlock(planInitial.TileMap2, x, y+4, Ref_donnees.route_T_haut_droit);
                planInitial.SetBlock(planInitial.TileMap2, x, y+3, Ref_donnees.route_right);
            }
            else
            {
                GD.Print("YP");
                planInitial.SetBlock(planInitial.TileMap2, x, y+3, Ref_donnees.route_bord_bas_gauche);
            }

            if (planInitial.GetBlock(planInitial.TileMap2, x-2, y+2) == Ref_donnees.route_right)
            {
                planInitial.SetBlock(planInitial.TileMap2, x-2, y+2, Ref_donnees.route_T_bas_droite);
                planInitial.SetBlock(planInitial.TileMap2, x-1, y+2, Ref_donnees.route_left);
            }
            else
            {
                planInitial.SetBlock(planInitial.TileMap2, x-1, y, Ref_donnees.route_bord_haut_gauche);
            }

            if (planInitial.GetBlock(planInitial.TileMap2, x-2, y) == Ref_donnees.route_right)
            {
                planInitial.SetBlock(planInitial.TileMap2, x-2, y, Ref_donnees.route_T_bas_droite);
                planInitial.SetBlock(planInitial.TileMap2, x-1, y, Ref_donnees.route_left);
            }
            else
            {
                planInitial.SetBlock(planInitial.TileMap2, x-1 , y+2, Ref_donnees.route_bord_haut_gauche);
            }

        }

        public enum Direction
        {
            LEFT,
            RIGHT,
            TOP,
            DOWN
        }
        //OK
        public static bool RoadVerif(PlanInitial planInitial, int x, int y, Direction dir)
        {
            bool valid = true;
            while (planInitial.GetBlock(planInitial.TileMap1, x, y) != -1 && valid)
            {
                if (planInitial.GetBlock(planInitial.TileMap1, x, y) != Ref_donnees.terre)
                {
                    valid = false;
                }

                switch (dir)
                {
                    case Direction.TOP:
                    {
                        y--;
                        break;
                    }
                    case Direction.DOWN:
                    {
                        y++;
                        break;
                    }
                    case Direction.LEFT:
                    {
                        x--;
                        break;
                    }
                    case Direction.RIGHT:
                    {
                        x++;
                        break;
                    }
                }
            }

            return valid;
        }
        //OK
        public static (int, int) StartRoad(PlanInitial planInitial)
        {
            int x = rand.Next(Ref_donnees.min_village_x, Ref_donnees.max_village_x + 1);
            int y = rand.Next(Ref_donnees.min_village_y, Ref_donnees.max_village_y + 1);
            if (planInitial.GetBlock(planInitial.TileMap1, x, y) != Ref_donnees.terre)
            {
                return StartRoad(planInitial);
            }
            bool found = RoadVerif(planInitial, x, y, Direction.TOP) && 
                         RoadVerif(planInitial, x, y, Direction.DOWN) &&
                         RoadVerif(planInitial, x, y, Direction.LEFT) &&
                         RoadVerif(planInitial, x, y, Direction.RIGHT);
            if (!found)
            {
                return StartRoad(planInitial);
            }
            return (x, y);
        }
        public static void BuildRoadDirection(PlanInitial planInitial, int x, int y, Direction dir)
        {
            (int xd, int yd) = (x, y);
            int bloc;
            switch (dir)
            {
                case Direction.TOP:
                {
                    bloc = Ref_donnees.route_right;
                    break;
                }
                case Direction.DOWN:
                {
                    bloc = Ref_donnees.route_right;
                    break;
                }
                case Direction.LEFT:
                {
                    bloc = Ref_donnees.route_left;
                    break;
                }
                default:
                {
                    bloc = Ref_donnees.route_left;
                    break;
                }
                    
            }
            while (planInitial.GetBlock(planInitial.TileMap1, x, y) != -1 )
            {
                planInitial.SetBlock(planInitial.TileMap1, x, y, Ref_donnees.route);
                planInitial.SetBlock(planInitial.TileMap2, x-1, y-1, bloc);
                switch (dir)
                {
                    case Direction.TOP:
                    {
                        y--;
                        break;
                    }
                    case Direction.DOWN:
                    {
                        y++;
                        break;
                    }
                    case Direction.LEFT:
                    {
                        x--;
                        break;
                    }
                    case Direction.RIGHT:
                    {
                        x++;
                        break;
                    }
                }
            }
            planInitial.SetBlock(planInitial.TileMap2, xd-1, yd-1, Ref_donnees.route_croisement);
        }
        
        
        public static (int x, int y) GenerateRoutePlan(PlanInitial planInitial)
        {
            (int x, int y) = StartRoad(planInitial);
            BuildRoadDirection(planInitial, x, y, Direction.TOP);
            BuildRoadDirection(planInitial, x, y, Direction.DOWN);
            BuildRoadDirection(planInitial, x, y, Direction.LEFT);
            BuildRoadDirection(planInitial, x, y, Direction.RIGHT);
            return (x, y);
        }

        public static bool VerifCases(PlanInitial planInitial, int x, int y)
        {
            bool res;
            res = Lacs.Valid_Position(x + 1, y, planInitial) &&
                  Lacs.Valid_Position(x + 1, y + 1, planInitial) &&
                  Lacs.Valid_Position(x, y + 1, planInitial) &&
                  Lacs.Valid_Position(x - 1, y + 1, planInitial) &&
                  Lacs.Valid_Position(x - 1, y, planInitial) &&
                  Lacs.Valid_Position(x - 1, y - 1, planInitial) &&
                  Lacs.Valid_Position(x, y - 1, planInitial) &&
                  Lacs.Valid_Position(x + 1, y - 1, planInitial);
            return res;
        }


        public static (int x, int y) VillageStart(PlanInitial planInitial, int x, int y, bool cas_0, bool cas_1, bool cas_2, bool cas_3)
        {
            if (cas_0 && cas_1 && cas_2 && cas_3)
            {
                throw new Exception();
            }
            int depart = rand.Next(0, 4);
            switch (depart)
            {
                case 0:
                {
                    x = x - 3;
                    y = y - 3;
                    if (!VerifCases(planInitial, x, y))
                    {
                        return VillageStart(planInitial, x + 3, y + 3, true, cas_1, cas_2, cas_3);
                    }
                    break;
                }
                    
                case 1:
                {
                    x = x + 3;
                    y = y + 3;
                    if (!VerifCases(planInitial, x, y))
                    {
                        return VillageStart(planInitial, x - 3, y - 3, cas_0, true, cas_2, cas_3);
                    }
                    break;
                }

                case 2:
                {
                    x = x + 3;
                    y = y - 3;
                    if (!VerifCases(planInitial, x, y))
                    {
                        return VillageStart(planInitial, x - 3, y + 3, cas_0, cas_1, true, cas_3);
                    }
                    break;
                }
                    
                case 3:
                {
                    x = x - 3;
                    y = y + 3;
                    if (!VerifCases(planInitial, x, y))
                    {
                        return VillageStart(planInitial, x + 3, y - 3, cas_0, cas_1, cas_2, true);
                    }
                    break;
                }
            }

            return (x, y);
        }

        public static bool GenerateBuildings(PlanInitial planInitial)
        {
            try
            {
                (int x, int y) = GenerateRoutePlan(planInitial);
                (x, y) = VillageStart(planInitial, x, y, false, false, false, false);
                GenerateBatiments(planInitial, x-2, y-2);
                GenerateRouteVillage(planInitial, x-2, y-2);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}