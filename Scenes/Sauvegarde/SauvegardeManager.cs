using System.Collections.Generic;
using System.Linq;
using Godot;
using SshCity.Scenes.Buildings;
using SshCity.Scenes.Plan;

namespace SshCity.Scenes.Sauvegarde
{
    public class SauvegardeManager
    {
        public static SauvegardeManager Instance { get; } = new SauvegardeManager();

        public void Initialize()
        {
            // TODO: Initialiser Sauvegarde : Vérifier les paths, les fichiers existants etc...
        }

        public ISauvegarde LoadGame()
        {
            var saveGame = new File();
            // Il n'y a pas de sauvegarde
            if (!saveGame.FileExists(Ref_donnees.GameSavePath))
                return null;

            //saveGame.Open(Ref_donnees.GameSavePath, File.ModeFlags.Read);
            return null;
        }

        public void SaveGame(bool readable = false)
        {
            var bat = Batiments.ListBuildings;
            var saveGame = new File();
            saveGame.Open("user://savegame.save", File.ModeFlags.Write);
            GD.Print(saveGame.GetPathAbsolute());
            var buildingsData = JSON.Print(
                new Godot.Collections.Dictionary<string, object>
                {
                    {"Buildings", bat.Select(b => b.Save())}
                });
            GD.Print(buildingsData);
            saveGame.StoreLine(buildingsData);
            saveGame.Close();
        }
    }
}