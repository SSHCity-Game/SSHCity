using Godot;

namespace SshCity.Game.Plan
{
    public class Routes
    {
        public static bool IsRoute(int bloc)
        {
            return bloc == Ref_donnees.route_left ||
                   bloc == Ref_donnees.route_right ||
                   bloc == Ref_donnees.route_bord_bas_droit ||
                   bloc == Ref_donnees.route_bord_bas_gauche ||
                   bloc == Ref_donnees.route_bord_haut_droit ||
                   bloc == Ref_donnees.route_bord_haut_gauche ||
                   bloc == Ref_donnees.route_croisement ||
                   bloc == Ref_donnees.route_virage_bas ||
                   bloc == Ref_donnees.route_virage_droit ||
                   bloc == Ref_donnees.route_virage_gauche ||
                   bloc == Ref_donnees.route_virage_haut ||
                   bloc == Ref_donnees.route_T_bas_droite ||
                   bloc == Ref_donnees.route_T_bas_gauche ||
                   bloc == Ref_donnees.route_T_haut_droit ||
                   bloc == Ref_donnees.route_T_haut_gauche;
        }

        public static bool IsCroisement(int bloc)
        {
            return bloc == Ref_donnees.route_croisement ||
                   bloc == Ref_donnees.route_T_bas_droite ||
                   bloc == Ref_donnees.route_T_bas_gauche ||
                   bloc == Ref_donnees.route_T_haut_droit ||
                   bloc == Ref_donnees.route_T_haut_gauche;
        }

        public static bool IsVirage(int bloc)
        {
            return bloc == Ref_donnees.route_virage_bas ||
                   bloc == Ref_donnees.route_virage_droit ||
                   bloc == Ref_donnees.route_virage_gauche ||
                   bloc == Ref_donnees.route_virage_haut;
        }

        public static int ChoixRoute(Vector2 tile, PlanInitial planInitial)
        {
            int x = (int) tile.x;
            int y = (int) tile.y;
            bool HD = IsRoute(planInitial.GetBlock(planInitial.TileMap2, x, y - 1)) &&
                      planInitial.GetBlock(planInitial.TileMap1, x + 1, y) == Ref_donnees.route;
            bool BD = IsRoute(planInitial.GetBlock(planInitial.TileMap2, x + 1, y)) &&
                      planInitial.GetBlock(planInitial.TileMap1, x + 2, y + 1) == Ref_donnees.route;
            bool BG = IsRoute(planInitial.GetBlock(planInitial.TileMap2, x, y + 1)) &&
                      planInitial.GetBlock(planInitial.TileMap1, x + 1, y + 2) == Ref_donnees.route;
            bool HG = IsRoute(planInitial.GetBlock(planInitial.TileMap2, x - 1, y)) &&
                      planInitial.GetBlock(planInitial.TileMap1, x, y + 1) == Ref_donnees.route;

            if (HD && BD && BG && HG)
            {
                return Ref_donnees.route_croisement;
            }

            if (HD && BD && HG)
            {
                return Ref_donnees.route_T_haut_droit;
            }

            if (HD && BD && BG)
            {
                return Ref_donnees.route_T_bas_droite;
            }

            if (HG && BG && BD)
            {
                return Ref_donnees.route_T_bas_gauche;
            }

            if (BG && HD && HG)
            {
                return Ref_donnees.route_T_haut_gauche;
            }

            if (HD && BG)
            {
                return Ref_donnees.route_right;
            }

            if (BD && HG)
            {
                return Ref_donnees.route_left;
            }

            if (HD && BD)
            {
                return Ref_donnees.route_virage_gauche;
            }

            if (BD && BG)
            {
                return Ref_donnees.route_virage_haut;
            }

            if (HG && BG)
            {
                return Ref_donnees.route_virage_droit;
            }

            if (HG && HD)
            {
                return Ref_donnees.route_virage_bas;
            }

            if (HD)
            {
                return Ref_donnees.route_bord_bas_gauche;
            }

            if (BD)
            {
                return Ref_donnees.route_bord_haut_gauche;
            }

            if (BG)
            {
                return Ref_donnees.route_bord_haut_droit;
            }

            if (HG)
            {
                return Ref_donnees.route_bord_bas_droit;
            }

            return Ref_donnees.route_left;
        }

        public static void ChangeRoute(Vector2 tile, PlanInitial planInitial)
        {
            int x = (int) tile.x;
            int y = (int) tile.y;
            bool HD = IsRoute(planInitial.GetBlock(planInitial.TileMap2, x, y - 1)) &&
                      planInitial.GetBlock(planInitial.TileMap1, x + 1, y) == Ref_donnees.route;
            bool BD = IsRoute(planInitial.GetBlock(planInitial.TileMap2, x + 1, y)) &&
                      planInitial.GetBlock(planInitial.TileMap1, x + 2, y + 1) == Ref_donnees.route;
            bool BG = IsRoute(planInitial.GetBlock(planInitial.TileMap2, x, y + 1)) &&
                      planInitial.GetBlock(planInitial.TileMap1, x + 1, y + 2) == Ref_donnees.route;
            bool HG = IsRoute(planInitial.GetBlock(planInitial.TileMap2, x - 1, y)) &&
                      planInitial.GetBlock(planInitial.TileMap1, x, y + 1) == Ref_donnees.route;

            if (HD)
            {
                planInitial.SetBlock(planInitial.TileMap2, x, y - 1, ChoixRoute(new Vector2(x, y - 1), planInitial));
            }

            if (BD)
            {
                planInitial.SetBlock(planInitial.TileMap2, x + 1, y, ChoixRoute(new Vector2(x + 1, y), planInitial));
            }

            if (BG)
            {
                planInitial.SetBlock(planInitial.TileMap2, x, y + 1, ChoixRoute(new Vector2(x, y + 1), planInitial));
            }

            if (HG)
            {
                planInitial.SetBlock(planInitial.TileMap2, x - 1, y, ChoixRoute(new Vector2(x - 1, y), planInitial));
            }
        }

        public static Vector2 WhereIsRoute(Vector2 tile, PlanInitial planInitial)
        {
            if (IsRoute(planInitial.GetBlock(planInitial.TileMap2, (int) tile.x - 1, (int) tile.y)))
            {
                return tile - new Vector2(1, 0);
            }

            if (IsRoute(planInitial.GetBlock(planInitial.TileMap2, (int) tile.x + 1, (int) tile.y)))
            {
                return tile + new Vector2(1, 0);
            }

            if (IsRoute(planInitial.GetBlock(planInitial.TileMap2, (int) tile.x, (int) tile.y - 1)))
            {
                return tile - new Vector2(0, 1);
            }

            if (IsRoute(planInitial.GetBlock(planInitial.TileMap2, (int) tile.x, (int) tile.y + 1)))
            {
                return tile + new Vector2(0, 1);
            }

            return new Vector2();
        }
    }
}