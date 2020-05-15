using System.Linq;
using Godot;
using Godot.Collections;
using SshCity.Game.Buildings;
using SshCity.Game.Plan;

namespace SshCity.Game.Sauvegarde
{
    public static class SauvegardeManager
    {
        /// <summary>
        /// Charge une sauvegarde depuis un fichier s'il existe
        /// </summary>
        /// <returns>Renvoie false s'il n'y a pas de sauvegarde ou quelle n'a pu être chargée. true sinon</returns>
        public static bool LoadGame(PlanInitial planInitial)
        {
            var saveGame = new File();
            // Il n'y a pas de sauvegarde
            if (!saveGame.FileExists(Ref_donnees.GameSavePath))
                return false;

            saveGame.Open(Ref_donnees.GameSavePath, File.ModeFlags.Read);
            var buildData = (Dictionary) JSON.Parse(saveGame.GetAsText()).Result;
            // Load Buildings
            var datas = (Array) buildData["Buildings"];
            foreach (var dicValues in datas.Cast<Dictionary>())
            {
                var x = (float) dicValues["PosX"];
                var y = (float) dicValues["PosY"];
                var clazz = (Batiments.Class) int.Parse(dicValues["Class"].ToString());
                var lvl = int.Parse(dicValues["Level"].ToString());

                var bat = new Batiments.Building(clazz, new Vector2(x, y), lvl);
                planInitial.SetBlock(planInitial.TileMap2, (int) x, (int) y, bat.Bloc);
                planInitial.SetAchatBlocs(bat.Position);
            }

            saveGame.Close();
            return true;
        }

        public static void SaveGame()
        {
            var bat = Batiments.ListBuildings;
            var saveGame = new File();
            saveGame.Open(Ref_donnees.GameSavePath, File.ModeFlags.Write);
            var buildingsData = JSON.Print(
                new Dictionary<string, System.Collections.Generic.IEnumerable<Dictionary<string, object>>>
                {
                    {"Buildings", bat.Select(b => b.Save())}
                });
            saveGame.StoreLine(buildingsData);
            saveGame.Close();
        }
    }
}