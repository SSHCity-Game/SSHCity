using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Ferme : IBuildingCharacteristics
    {
        public Ferme()
        {
            Bloc = new[] {Ref_donnees.ferme};
            Cost = new[] {3000};
            Earn = new[] {2,5,8};
            Titre = new[] {"Ferme"};
            Lvl = 0;
            GainXp = new[] {10, 100, 500};
            energy = new[] {1};
            water = new[] {3};
            Image = new[] {"res://assets/ImageSized/isometric ferme2.png"};
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