using System;
using System.Linq;
using Godot;
using Godot.Collections;
using SshCity.Scenes.Buildings;
using SshCity.Scenes.Plan;
using Array = Godot.Collections.Array;

namespace SshCity.Scenes.Sauvegarde
{
    public class SauvegardeManager
    {
        public static void Initialize()
        {
            // TODO: Initialiser Sauvegarde : Vérifier les paths, les fichiers existants etc...
        }

        /// <summary>
        /// Charge une sauvegarde depuis un fichier s'il existe
        /// </summary>
        /// <returns>Renvoie false s'il n'y a pas de sauvegarde ou quelle n'a pu être chargée. true sinon</returns>
        public static bool LoadGame()
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

                new Batiments.Building(clazz, new Vector2(x, y), lvl);
                // todo : ajouter les batiments sur le map
            }

            saveGame.Close();
            return true;
        }

        public static void SaveGame()
        {
            // TODO : Faire une version lisible 
            var bat = Batiments.ListBuildings;
            var saveGame = new File();
            saveGame.Open(Ref_donnees.GameSavePath, File.ModeFlags.Write);
            var buildingsData = JSON.Print(
                new Dictionary<string, System.Collections.Generic.IEnumerable<Dictionary<string, object>>>
                {
                    {"Buildings", bat.Select(b => b.Save())}
                });
            //GD.Print(buildingsData);
            saveGame.StoreLine(buildingsData);
            saveGame.Close();
        }
    }
}