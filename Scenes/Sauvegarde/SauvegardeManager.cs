using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Godot;
using SshCity.Scenes.Buildings;
using SshCity.Scenes.Plan;

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
            // TODO: Fix cast
            var buildData =
                (Godot.Collections.Dictionary<string, object>) JSON
                    .Parse(saveGame.GetLine()).Result;
            buildData.TryGetValue("Buildings", out var datas);
            if (datas == null)
                datas = new List<Godot.Collections.Dictionary<string, object>>();
            foreach (var dicValues in (IEnumerable<Dictionary<string, object>>) datas)
            {
                dicValues.TryGetValue("PosX", out var x);
                dicValues.TryGetValue("PosY", out var y);
                dicValues.TryGetValue("Class", out var clazz);
                dicValues.TryGetValue("Level", out var lvl);
                if (x == null)
                    x = 0;
                if (y == null)
                    y = 0;
                if (clazz == null)
                    clazz = 3;
                if (lvl == null)
                    lvl = 0;
                new Batiments.Building((Batiments.Class) clazz, new Vector2((float) x, (float) y), (int) lvl);
            }

            return true;
        }

        public static void SaveGame(bool readable = false)
        {
            // TODO : Faire une version lisible 
            var bat = Batiments.ListBuildings;
            var saveGame = new File();
            saveGame.Open(Ref_donnees.GameSavePath, File.ModeFlags.Write);
            GD.Print(saveGame.GetPathAbsolute());
            var buildingsData = JSON.Print(
                new Godot.Collections.Dictionary<string, IEnumerable<Godot.Collections.Dictionary<string, object>>>
                {
                    {"Buildings", bat.Select(b => b.Save())}
                });
            //GD.Print(buildingsData);
            saveGame.StoreLine(buildingsData);
            saveGame.Close();
        }
    }
}