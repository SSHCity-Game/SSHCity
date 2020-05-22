using Godot;

namespace SshCity.Game.Plan
{
    public class Tuyaux
    {
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
                   bloc == Ref_donnees.route ||
                   bloc == Ref_donnees.sol_stationEpuration;
        }

        public static int ChoixTuyaux(Vector2 tile, PlanInitial planInitial)
        {
            int x = (int) tile.x;
            int y = (int) tile.y;
            bool HD = IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, x, y - 1)) &&
                                planInitial.GetBlock(planInitial.TileMapNeg, x, y - 1) == Ref_donnees.tuyaux_terre;
            bool BD = IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, x + 1, y))&&
                      planInitial.GetBlock(planInitial.TileMapNeg, x + 1, y) == Ref_donnees.tuyaux_terre;
            bool BG = IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, x, y + 1))&&
                      planInitial.GetBlock(planInitial.TileMapNeg, x, y + 1) == Ref_donnees.tuyaux_terre;
            bool HG = IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, x - 1, y))&&
                      planInitial.GetBlock(planInitial.TileMapNeg, x - 1, y) == Ref_donnees.tuyaux_terre;

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
            bool BD = IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, x + 1, y))&&
                      planInitial.GetBlock(planInitial.TileMapNeg, x + 1, y) == Ref_donnees.tuyaux_terre;
            bool BG = IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, x, y + 1))&&
                      planInitial.GetBlock(planInitial.TileMapNeg, x, y + 1) == Ref_donnees.tuyaux_terre;
            bool HG = IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, x - 1, y))&&
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

        public static Vector2 WhereIsRoute(Vector2 tile, PlanInitial planInitial)
        {
            if (IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, (int) tile.x - 1, (int) tile.y)))
            {
                return tile - new Vector2(1, 0);
            }

            if (IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, (int) tile.x + 1, (int) tile.y)))
            {
                return tile + new Vector2(1, 0);
            }

            if (IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, (int) tile.x, (int) tile.y - 1)))
            {
                return tile - new Vector2(0, 1);
            }

            if (IsTuyaux(planInitial.GetBlock(planInitial.TileMap0, (int) tile.x, (int) tile.y + 1)))
            {
                return tile + new Vector2(0, 1);
            }

            return new Vector2();
        }
    }
}