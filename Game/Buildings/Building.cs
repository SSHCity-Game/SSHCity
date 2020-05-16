using System.Collections.Generic;
using Godot;
using SshCity.Game.Sauvegarde;

namespace SshCity.Game.Buildings
{
    public class Building : ISerializable
    {
        public static List<Building> ListBuildings = new List<Building>();

        private Building(BuildingType type, Vector2 position, int theLvl)
        {
            Type = type;
            Characteristics = BuildingCharacteristics.FromType(type);
            Position = position;
            Characteristics.Lvl = theLvl;
            ListBuildings.Add(this);
        }

        public Vector2 Position { get; }
        public BuildingType Type { get; }

        public IBuildingCharacteristics Characteristics { get; }

        public Godot.Collections.Dictionary<string, object> Save()
        {
            return new Godot.Collections.Dictionary<string, object>
            {
                {"PosX", Position.x},
                {"PosY", Position.y},
                {"Type", Type},
                {"Level", Characteristics.Lvl}
            };
        }

        public static Building Create(BuildingType type, Vector2 position, int theLvl = 0)
        {
            return new Building(type, position, theLvl);
        }

        public static Building GetBuildingWithPosition(Vector2 tile)
        {
            var found = false;
            Building batimentLookingFor = null;
            var i = 0;
            var length = ListBuildings.Count;
            while (!found && i < length)
            {
                var batiment = ListBuildings[i];
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

        public static void Suppression(Vector2 tile)
        {
            GetBuildingWithPosition(tile);
        }

        public static (bool, int) Amelioration(Vector2 tile)
        {
            var batimentToUpgrade = GetBuildingWithPosition(tile);
            if (batimentToUpgrade == null) return (false, -1);
            batimentToUpgrade.Upgrade();
            ListBuildings.Add(batimentToUpgrade);
            return (true, batimentToUpgrade.Characteristics.Bloc[0]);
        }

        public void Upgrade()
        {
            if (Characteristics.NbrAmeliorations <= Characteristics.Lvl || Characteristics.Lvl >= 2 ||
                Interface.Money < Characteristics.Cost[Characteristics.Lvl]) return;
            Interface.Money -= Characteristics.Cost[Characteristics.Lvl];
            Interface.Xp += Characteristics.GainXp[Characteristics.Lvl];
            Characteristics.Lvl += 1;
        }
    }
}