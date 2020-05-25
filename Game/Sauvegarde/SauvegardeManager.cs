using System.Linq;
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
        public static bool LoadGame(PlanInitial planInitial, string game)
        {
            var saveGame = new File();
            // Il n'y a pas de sauvegarde
            if (!saveGame.FileExists(Ref_donnees.GameSavePath) && game == null)
                return false;
            if (game != null)
                SaveFile(game);

            saveGame.Open(Ref_donnees.GameSavePath, File.ModeFlags.Read);
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
                MainPlan.ListeBatiment.Add((new Vector2(x, y), bat.Characteristics.Bloc[bat.Characteristics.Lvl]));
                Interface.Xp += bat.Characteristics.GainXp[bat.Characteristics.Lvl];
                planInitial.SetBlock(planInitial.TileMap2, (int) x, (int) y, bat.Characteristics.Bloc[0]);
                planInitial.SetBlock(planInitial.TileMapWithoutRoute, (int) x, (int) y, bat.Characteristics.Bloc[0]);
                planInitial.SetAchatBlocs(bat.Position, false);
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
            SaveFile(buildingsData);
        }

        private static void SaveFile(string game)
        {
            var saveGame = new File();
            saveGame.Open(Ref_donnees.GameSavePath, File.ModeFlags.Write);
            saveGame.StoreLine(game);
            saveGame.Close();
            UploadSave(game);
        }

        private static void UploadSave(string game)
        {
            if (Player.ThePlayer.Token == null || Player.ThePlayer.Token.Empty())
                return;
            // Upload
            var client = new HTTPClient();

            var error = client.ConnectToHost("sshcity.vinetos.fr", 5001, true, false);
            if (error != Error.Ok)
                return;

            while (client.GetStatus() == HTTPClient.Status.Connecting ||
                   client.GetStatus() == HTTPClient.Status.Resolving)
            {
                client.Poll();
                OS.DelayMsec(500);
            }

            if (client.GetStatus() != HTTPClient.Status.Connected)
                return;

            var body =
                "{" +
                $"\"gameid\": \"{Player.ThePlayer.GameId}\"," +
                $"\"game\": \"{game.ReplaceN("\"", "\\\"")}\"" +
                "}";

            var headers = new[]
            {
                $"Authorization: Bearer {Player.ThePlayer.Token}",
                "Content-Type: application/json",
                "User-Agent: TheGame/1.0",
            };

            client.Request(HTTPClient.Method.Post, "/games", headers, body);
            while (client.GetStatus() == HTTPClient.Status.Requesting)
            {
                client.Poll();
                OS.DelayMsec(500);
            }
        }
    }
}