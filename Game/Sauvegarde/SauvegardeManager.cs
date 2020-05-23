﻿using System.Linq;
using System.Net;
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
        public static bool LoadGame(PlanInitial planInitial, string game = null)
        {
            var saveGame = new File();
            // Il n'y a pas de sauvegarde
            if (!saveGame.FileExists(Ref_donnees.GameSavePath) && game == null)
                return false;
            if (game != null)
                SaveFile(game);
            
            saveGame.Open(Ref_donnees.GameSavePath, File.ModeFlags.Read);
            if (saveGame.GetLen() == 0)
                return false;
            var buildData = (Dictionary) JSON.Parse(saveGame.GetAsText()).Result;
            // Load Buildings
            var datas = (Array) buildData["Buildings"];
            foreach (var dicValues in datas.Cast<Dictionary>())
            {
                var x = (float) dicValues["PosX"];
                var y = (float) dicValues["PosY"];
                var clazz = (BuildingType) int.Parse(dicValues["Type"].ToString());
                var lvl = int.Parse(dicValues["Level"].ToString());

                var bat = Building.Create(clazz, new Vector2(x, y), lvl);
                planInitial.SetBlock(planInitial.TileMap2, (int) x, (int) y, bat.Characteristics.Bloc[0]);
                planInitial.SetAchatBlocs(bat.Position);
            }

            saveGame.Close();
            return true;
        }

        public static void SaveGame()
        {
            var bat = Building.ListBuildings;
            var buildingsData = JSON.Print(
                new Dictionary<string, System.Collections.Generic.IEnumerable<Dictionary<string, object>>>
                {
                    {"Buildings", bat.Select(b => b.Save())}
                });
            GD.Print(buildingsData);
            SaveFile(buildingsData);
        }

        private static void SaveFile(string game)
        {
            var saveGame = new File();
            saveGame.Open(Ref_donnees.GameSavePath, File.ModeFlags.Write);
            saveGame.StoreLine(game);
            saveGame.Close();
            //UploadSave(game);
        }

        private static void UploadSave(string game)
        {
            if (Player.ThePlayer.Token == null || Player.ThePlayer.Token.Empty())
                return;
            GD.Print("Uploading");
            GD.Print(Player.ThePlayer.Token);
            // Upload
            var client = new HTTPClient();
            var error = client.ConnectToHost("sshcity.vinetos.fr", 5001);
            if (error != Error.Ok)
                return;
            while (client.GetStatus() == HTTPClient.Status.Connecting ||
                   client.GetStatus() == HTTPClient.Status.Resolving)
            {
                client.Poll();
                GD.Print("Connecting...");
                OS.DelayMsec(500);
            }

            var headers = new[]
            {
                $"Authorization: Bearer {Player.ThePlayer.Token}",
                "Content-Type: application/json",
                "User-Agent: TheGame/1.0 (Godot)",
                "Accept: */*"
            };
            if (client.GetStatus() != HTTPClient.Status.Connected)
                return;
            client.Request(HTTPClient.Method.Post, "/games", headers, game);
            while (client.GetStatus() == HTTPClient.Status.Requesting)
                OS.DelayMsec(500);
            GD.Print("Uploaded !!!!");
        }
    }
}