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
            GetBuildingWithPosition(tile);
        }
    }
}