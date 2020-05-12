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
        public static (bool, int) Amelioration(Vector2 tile)
        {
            Building batimentToUpgrade = GetBuildingWithPosition(tile);
            if (batimentToUpgrade != null)
            {
                batimentToUpgrade.Upgrade();
                ListBuildings.Add(batimentToUpgrade);
                return (true, batimentToUpgrade.Bloc);
            }
            else
            {
                return (false, -1);
            }
        }
    }
}