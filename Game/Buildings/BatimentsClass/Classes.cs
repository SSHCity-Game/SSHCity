using System.Collections.Generic;
using Godot;

namespace SshCity.Game.Buildings
{
    public partial class Batiments
    {

        public static List<Building> ListBuildings = new List<Building>();

        public static Building GetBuildingWithPosition(Vector2 tile)
        {
            bool found = false;
            Building batimentLookingFor = null;
            int i = 0;
            int length = ListBuildings.Count;
            while (!found && i < length)
            {
                Building batiment = ListBuildings[i];
                if (batiment.Position == tile)
                {
                    batimentLookingFor = batiment;
                    ListBuildings.RemoveAt(i);
                    found = true;
                }

                i++;
            }

            return batimentLookingFor;
        }
    }
}