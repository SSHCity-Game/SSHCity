using Godot;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using SshCity.Scenes.Plan;

namespace SshCity.Scenes.Buildings
{
    public partial class Batiments
    {
        public static void Suppression(Vector2 tile)
        {
            bool found = false;
            int i = 0;
            int length = ListBuildings.Count;
            while (!found && i < length)
            {
                Building batiment = ListBuildings[i];
                if (batiment.Position == tile)
                {
                    ListBuildings.RemoveAt(i);
                }
            }
        }
    }
}