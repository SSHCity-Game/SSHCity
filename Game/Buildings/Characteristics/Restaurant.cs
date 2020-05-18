using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Restaurant : IBuildingCharacteristics
    {
        public Restaurant()
        {
            Bloc = new[] {Ref_donnees.restaurant};
            Cost = new[] {5000};
            Earn = new[] {10, 15, 20};
            Titre = new[] {"Restaurant"};
            Lvl = 0;
            GainXp = new[] {10, 100, 500};
            energy = new[] {1};
            water = new[] {2};
            Image = new[] {"res://assets/ImageSized/isometric boutique5.png"};
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