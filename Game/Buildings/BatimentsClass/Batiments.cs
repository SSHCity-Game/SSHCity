using Godot;
using Godot.Collections;

namespace SshCity.Game.Buildings
{
    public partial class Batiments
    {
        public class Building
        {
            private int[] _bloc;
            private int[] _cost;
            private string[] _image;
            private int[] gain_xp;

            public Building(BuildingType type, Vector2 position, int theLvl = 0)
            {
                var caracteristique = BuildingCharacteristics.FromType(type);
                Position = position;
                Class = type;
                _bloc = caracteristique.Bloc;
                EarnTab = caracteristique.Earn;
                _cost = caracteristique.Cost;
                Titre = caracteristique.Titre;
                gain_xp = caracteristique.GainXp;
                _image = caracteristique.Image;
                NbrAmelioration = caracteristique.NbrAmeliorations;
                Lvl = theLvl;
                ListBuildings.Add(this);
            }

            public int Lvl { get; private set; }

            public Vector2 Position { get; }

            public string[] Titre { get; }

            public BuildingType Class { get; }

            public int Bloc => _bloc[Lvl];

            public int[] EarnTab { get; }

            public int AmeliorationCost => _cost[Lvl + 1];
            public int NbrAmelioration { get; }


            public string Image => _image[Lvl];
            public int Earn => EarnTab[Lvl];

            public int[] ConsomationElec { get; }

            public int[] ConsomationEau { get; }

            public void Upgrade()
            {
                if (NbrAmelioration <= Lvl || Lvl >= 2 || Interface.Money < _cost[Lvl]) return;
                Interface.Money -= _cost[Lvl];
                Interface.Xp += gain_xp[Lvl];
                Lvl += 1;
            }

            public Dictionary<string, object> Save()
            {
                return new Dictionary<string, object>
                {
                    {"PosX", Position.x},
                    {"PosY", Position.y},
                    {"Class", Class},
                    {"Level", Lvl}
                };
            }
        }
    }
}