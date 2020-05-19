using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Police : IBuildingCharacteristics
    {
        public Police()
        {
            Bloc = new[] {Ref_donnees.police};
            Cost = new[] {5000};
            Earn = new[] {1, 2, 5};
            Titre = new[] {"Police"};
            Lvl = 0;
            GainXp = new[] {10, 100, 500};
            energy = new[] {2};
            water = new[] {1};
            Image = new[] {"res://assets/ImageSized/police.png"};
            NbrAmeliorations = 0;
        }

        public int[] Bloc { get; }
        public int[] Cost { get; }
        public int[] Earn { get; }
        public string[] Titre { get; }
        public int Lvl { get; set; }
        public int[] GainXp { get; }
        public int[] energy { get; }
        public int[] water { get; }
        public string[] Image { get; }
        public int NbrAmeliorations { get; }
    }
}