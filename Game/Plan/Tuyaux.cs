using System.Collections.Generic;
using Godot;
using SshCity.Game.Buildings;

namespace SshCity.Game.Plan
{
    public class Tuyaux
    {
        public static List<Vector2> ListEpuration = new List<Vector2>();
        public static List<Vector2> ListTuyauxEauLac = new List<Vector2>();
        public static List<Vector2> ListTuyauxEauEpuration = new List<Vector2>();

        /// <summary>
        /// Considere tous les blocs a coté d'un bloc station epuration qui vient de se faire raccordé a l'eau comme racordé
        /// </summary>
        /// <param name="tile">Position du bloc venant de se faire raccordé</param>
        /// <param name="planInitial">PlanInitial</param>
        public static void raccordage(Vector2 tile, PlanInitial planInitial, int bloc)
        {
            if (planInitial.GetBlock(planInitial.TileMap0, (int) tile.x, (int) tile.y) != bloc)
            {
                planInitial.SetBlock(planInitial.TileMap0, (int) tile.x, (int) tile.y, bloc);
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (planInitial.GetBlock(planInitial.TileMap0, (int) tile.x + i, (int) tile.y + j) ==
                            Ref_donnees.sol_stationEpuration)
                        {
                            raccordage(new Vector2(tile.x + i, tile.y + j), planInitial, bloc);
                        }
                    }
                }
            }
        }

        public static void EpuratioRaccordage(PlanInitial planInitial)
        {
            foreach (Vector2 vector2 in ListEpuration)
            {
                List<Vector2> ListTuyauxAlreadyDone = new List<Vector2>();
                if (VerifRaccorde(vector2, planInitial, ListTuyauxAlreadyDone, Ref_donnees.eau))
                {
                    raccordage(vector2, planInitial, Ref_donnees.sol_stationEpuration);
                }
                else
                {
                    raccordage(vector2, planInitial, Ref_donnees.route);
                }
            }
        }

        public static void MaisonRaccordage(PlanInitial planInitial)
        {
            foreach (Building building in Building.ListBuildings)
            {
                if (building.Type != BuildingType.EPURATION)
                {
                    Vector2 tile = building.Position + new Vector2(1, 1);
                    List<Vector2> ListTuyauxAlreadyDone = new List<Vector2>();
                    if (VerifRaccorde(tile, planInitial, ListTuyauxAlreadyDone, Ref_donnees.sol_stationEpuration))
                    {
                        raccordage(tile, planInitial, Ref_donnees.sol_maisonEau);
                    }
                    else
                    {
                        raccordage(tile, planInitial, Ref_donnees.route);
                    }
                }
            }
        }

        public static bool VerifRaccorde(Vector2 tile, PlanInitial planInitial, List<Vector2> list, int bloc)
        {
            foreach (Vector2 vector2 in list)
            {
                if (vector2 == tile)
                {
                    return false;
                }
            }

            list.Add(tile);
            bool gauche = false;
            bool droit = false;
            bool bas = false;
            bool haut = false;
            if (IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, (int) tile.x - 1, (int) tile.y)))
            {
                if (bloc == Ref_donnees.sol_stationEpuration &&
                    planInitial.GetBlock(planInitial.TileMap0, (int) tile.x - 1, (int) tile.y) == Ref_donnees.eau)
                {
                    return false;
                }

                if (planInitial.GetBlock(planInitial.TileMap0, (int) tile.x - 1, (int) tile.y) == bloc)
                {
                    return true;
                }

                gauche = true;
            }

            if (IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, (int) tile.x + 1, (int) tile.y)))
            {
                if (bloc == Ref_donnees.sol_stationEpuration &&
                    planInitial.GetBlock(planInitial.TileMap0, (int) tile.x + 1, (int) tile.y) == Ref_donnees.eau)
                {
                    return false;
                }

                if (planInitial.GetBlock(planInitial.TileMap0, (int) tile.x + 1, (int) tile.y) == bloc)
                {
                    return true;
                }

                droit = true;
            }

            if (IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, (int) tile.x, (int) tile.y - 1)))
            {
                if (bloc == Ref_donnees.sol_stationEpuration &&
                    planInitial.GetBlock(planInitial.TileMap0, (int) tile.x, (int) tile.y - 1) == Ref_donnees.eau)
                {
                    return false;
                }

                if (planInitial.GetBlock(planInitial.TileMap0, (int) tile.x, (int) tile.y - 1) == bloc)
                {
                    return true;
                }

                haut = true;
            }

            if (IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, (int) tile.x, (int) tile.y + 1)))
            {
                if (bloc == Ref_donnees.sol_stationEpuration &&
                    planInitial.GetBlock(planInitial.TileMap0, (int) tile.x, (int) tile.y + 1) == Ref_donnees.eau)
                {
                    return false;
                }

                if (planInitial.GetBlock(planInitial.TileMap0, (int) tile.x, (int) tile.y + 1) == bloc)
                {
                    return true;
                }

                bas = true;
            }

            if (gauche && bas && droit && haut)
            {
                return VerifRaccorde(tile + new Vector2(1, 0), planInitial, list, bloc) ||
                       VerifRaccorde(tile + new Vector2(-1, 0), planInitial, list, bloc) ||
                       VerifRaccorde(tile + new Vector2(0, 1), planInitial, list, bloc) ||
                       VerifRaccorde(tile + new Vector2(0, -1), planInitial, list, bloc);
            }

            if (bas && droit && haut)
            {
                return VerifRaccorde(tile + new Vector2(1, 0), planInitial, list, bloc) ||
                       VerifRaccorde(tile + new Vector2(0, 1), planInitial, list, bloc) ||
                       VerifRaccorde(tile + new Vector2(0, -1), planInitial, list, bloc);
            }

            if (gauche && droit && haut)
            {
                return VerifRaccorde(tile + new Vector2(1, 0), planInitial, list, bloc) ||
                       VerifRaccorde(tile + new Vector2(-1, 0), planInitial, list, bloc) ||
                       VerifRaccorde(tile + new Vector2(0, -1), planInitial, list, bloc);
            }

            if (gauche && bas && haut)
            {
                return VerifRaccorde(tile + new Vector2(-1, 0), planInitial, list, bloc) ||
                       VerifRaccorde(tile + new Vector2(0, 1), planInitial, list, bloc) ||
                       VerifRaccorde(tile + new Vector2(0, -1), planInitial, list, bloc);
            }

            if (gauche && bas && droit)
            {
                return VerifRaccorde(tile + new Vector2(1, 0), planInitial, list, bloc) ||
                       VerifRaccorde(tile + new Vector2(-1, 0), planInitial, list, bloc) ||
                       VerifRaccorde(tile + new Vector2(0, 1), planInitial, list, bloc);
            }

            if (droit && haut)
            {
                return VerifRaccorde(tile + new Vector2(1, 0), planInitial, list, bloc) ||
                       VerifRaccorde(tile + new Vector2(0, -1), planInitial, list, bloc);
            }

            if (gauche && bas)
            {
                return VerifRaccorde(tile + new Vector2(-1, 0), planInitial, list, bloc) ||
                       VerifRaccorde(tile + new Vector2(0, 1), planInitial, list, bloc);
            }

            if (bas && haut)
            {
                return VerifRaccorde(tile + new Vector2(0, 1), planInitial, list, bloc) ||
                       VerifRaccorde(tile + new Vector2(0, -1), planInitial, list, bloc);
            }

            if (gauche && droit)
            {
                return VerifRaccorde(tile + new Vector2(1, 0), planInitial, list, bloc) ||
                       VerifRaccorde(tile + new Vector2(-1, 0), planInitial, list, bloc);
            }

            if (bas && droit)
            {
                return VerifRaccorde(tile + new Vector2(1, 0), planInitial, list, bloc) ||
                       VerifRaccorde(tile + new Vector2(0, 1), planInitial, list, bloc);
            }

            if (gauche && haut)
            {
                return VerifRaccorde(tile + new Vector2(-1, 0), planInitial, list, bloc) ||
                       VerifRaccorde(tile + new Vector2(0, -1), planInitial, list, bloc);
            }

            if (gauche)
            {
                return VerifRaccorde(tile + new Vector2(-1, 0), planInitial, list, bloc);
            }

            if (bas)
            {
                return VerifRaccorde(tile + new Vector2(0, 1), planInitial, list, bloc);
            }

            if (droit)
            {
                return VerifRaccorde(tile + new Vector2(1, 0), planInitial, list, bloc);
            }

            if (haut)
            {
                return VerifRaccorde(tile + new Vector2(0, -1), planInitial, list, bloc);
            }

            return false;
        }

        public static bool IsTuyaux(int bloc)
        {
            return bloc == Ref_donnees.tuyaux_left ||
                   bloc == Ref_donnees.tuyaux_right ||
                   bloc == Ref_donnees.tuyaux_croisement ||
                   bloc == Ref_donnees.tuyaux_T_bas_droit ||
                   bloc == Ref_donnees.tuyaux_T_bas_gauche ||
                   bloc == Ref_donnees.tuyaux_T_haut_droit ||
                   bloc == Ref_donnees.tuyaux_T_haut_gauche ||
                   bloc == Ref_donnees.tuyaux_virage_bas ||
                   bloc == Ref_donnees.tuyaux_virage_droit ||
                   bloc == Ref_donnees.tuyaux_virage_gauche ||
                   bloc == Ref_donnees.tuyaux_virage_haut ||
                   bloc == Ref_donnees.eau ||
                   bloc == Ref_donnees.sol_maisonEau ||
                   bloc == Ref_donnees.route ||
                   bloc == Ref_donnees.sol_stationEpuration;
        }

        public static int ChoixTuyaux(Vector2 tile, PlanInitial planInitial)
        {
            int x = (int) tile.x;
            int y = (int) tile.y;
            bool HD = (IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, x, y - 1)) &&
                       planInitial.GetBlock(planInitial.TileMapNeg, x, y - 1) == Ref_donnees.tuyaux_terre)
                      || (planInitial.GetBlock(planInitial.TileMap0, x, y - 1) == Ref_donnees.route
                          || planInitial.GetBlock(planInitial.TileMap0, x, y - 1) == Ref_donnees.eau
                          || planInitial.GetBlock(planInitial.TileMap0, x, y - 1) == Ref_donnees.sol_maisonEau
                          || planInitial.GetBlock(planInitial.TileMap0, x, y - 1) == Ref_donnees.sol_stationEpuration);
            bool BD = (IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, x + 1, y)) &&
                       planInitial.GetBlock(planInitial.TileMapNeg, x + 1, y) == Ref_donnees.tuyaux_terre)
                      || (planInitial.GetBlock(planInitial.TileMap0, x + 1, y) == Ref_donnees.route
                          || planInitial.GetBlock(planInitial.TileMap0, x + 1, y) == Ref_donnees.eau
                          || planInitial.GetBlock(planInitial.TileMap0, x + 1, y) == Ref_donnees.sol_maisonEau
                          || planInitial.GetBlock(planInitial.TileMap0, x + 1, y) == Ref_donnees.sol_stationEpuration);
            bool BG = (IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, x, y + 1)) &&
                       planInitial.GetBlock(planInitial.TileMapNeg, x, y + 1) == Ref_donnees.tuyaux_terre)
                      || (planInitial.GetBlock(planInitial.TileMap0, x, y + 1) == Ref_donnees.route
                          || planInitial.GetBlock(planInitial.TileMap0, x, y + 1) == Ref_donnees.eau
                          || planInitial.GetBlock(planInitial.TileMap0, x, y + 1) == Ref_donnees.sol_maisonEau
                          || planInitial.GetBlock(planInitial.TileMap0, x, y + 1) == Ref_donnees.sol_stationEpuration);
            bool HG = (IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, x - 1, y)) &&
                       planInitial.GetBlock(planInitial.TileMapNeg, x - 1, y) == Ref_donnees.tuyaux_terre)
                      || (planInitial.GetBlock(planInitial.TileMap0, x - 1, y) == Ref_donnees.route
                          || planInitial.GetBlock(planInitial.TileMap0, x - 1, y) == Ref_donnees.eau
                          || planInitial.GetBlock(planInitial.TileMap0, x - 1, y) == Ref_donnees.sol_maisonEau
                          || planInitial.GetBlock(planInitial.TileMap0, x - 1, y) == Ref_donnees.sol_stationEpuration);

            if (HD && BD && BG && HG)
            {
                return Ref_donnees.tuyaux_croisement;
            }

            if (HD && BD && HG)
            {
                return Ref_donnees.tuyaux_T_haut_droit;
            }

            if (HD && BD && BG)
            {
                return Ref_donnees.tuyaux_T_bas_droit;
            }

            if (HG && BG && BD)
            {
                return Ref_donnees.tuyaux_T_bas_gauche;
            }

            if (BG && HD && HG)
            {
                return Ref_donnees.tuyaux_T_haut_gauche;
            }

            if (HD && BG)
            {
                return Ref_donnees.tuyaux_right;
            }

            if (BD && HG)
            {
                return Ref_donnees.tuyaux_left;
            }

            if (HD && BD)
            {
                return Ref_donnees.tuyaux_virage_gauche;
            }

            if (BD && BG)
            {
                return Ref_donnees.tuyaux_virage_bas;
            }

            if (HG && BG)
            {
                return Ref_donnees.tuyaux_virage_droit;
            }

            if (HG && HD)
            {
                return Ref_donnees.tuyaux_virage_haut;
            }

            if (HD)
            {
                return Ref_donnees.tuyaux_right;
            }

            if (BD)
            {
                return Ref_donnees.tuyaux_left;
            }

            if (BG)
            {
                return Ref_donnees.tuyaux_right;
            }

            if (HG)
            {
                return Ref_donnees.tuyaux_left;
            }

            return Ref_donnees.tuyaux_right;
        }

        public static void ChangeTuyaux(Vector2 tile, PlanInitial planInitial)
        {
            int x = (int) tile.x;
            int y = (int) tile.y;
            bool HD = IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, x, y - 1)) &&
                      planInitial.GetBlock(planInitial.TileMapNeg, x, y - 1) == Ref_donnees.tuyaux_terre;
            bool BD = IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, x + 1, y)) &&
                      planInitial.GetBlock(planInitial.TileMapNeg, x + 1, y) == Ref_donnees.tuyaux_terre;
            bool BG = IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, x, y + 1)) &&
                      planInitial.GetBlock(planInitial.TileMapNeg, x, y + 1) == Ref_donnees.tuyaux_terre;
            bool HG = IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, x - 1, y)) &&
                      planInitial.GetBlock(planInitial.TileMapNeg, x - 1, y) == Ref_donnees.tuyaux_terre;

            if (HD)
            {
                planInitial.SetBlock(planInitial.TileMap0, x, y - 1, ChoixTuyaux(new Vector2(x, y - 1), planInitial));
            }

            if (BD)
            {
                planInitial.SetBlock(planInitial.TileMap0, x + 1, y, ChoixTuyaux(new Vector2(x + 1, y), planInitial));
            }

            if (BG)
            {
                planInitial.SetBlock(planInitial.TileMap0, x, y + 1, ChoixTuyaux(new Vector2(x, y + 1), planInitial));
            }

            if (HG)
            {
                planInitial.SetBlock(planInitial.TileMap0, x - 1, y, ChoixTuyaux(new Vector2(x - 1, y), planInitial));
            }
        }
    }
}