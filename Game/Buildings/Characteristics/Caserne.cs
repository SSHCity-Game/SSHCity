using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Caserne : IBuildingCharacteristics
    {
        public Caserne()
        {
            Bloc = new[] {Ref_donnees.caserne};
            Cost = new[] {5000};
            Earn = new[] {10, 20, 50};
            Titre = new[] {"Caserne"};
            Lvl = 0;
            GainXp = new[] {10, 100, 500};
            energy = new[] {2};
            water = new[] {2};
            Image = new[] {"res://assets/ImageSized/caserne.png"};
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