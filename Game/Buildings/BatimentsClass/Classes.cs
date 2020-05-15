using System.Collections.Generic;
using Godot;

namespace SshCity.Game.Buildings
{
    public partial class Batiments
    {
        public enum Class
        {
            CAFE,
            MAISON,
            PARC,
            POLICE,
            CENTRALE,
            MAISON3,
            MAISON4,
            MAISON5,
            PISCINE,
            RESTAURANT,
            RESTAURANT2,
            MCALLY,
            FERME,
            HOSPITAL,
            EGLISE,
            IMMEUBLE,
            IMMEUBLEVERT,
            CASERNE,
            HOTEL
        };

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