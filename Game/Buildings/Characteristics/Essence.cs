using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Essence : IBuildingCharacteristics
    {
        public Essence()
        {
            Bloc = new[] {Ref_donnees.essence};
            Cost = new[] {5000};
            Earn = new[] {10};
            Titre = new[] {"Essence"};
            Lvl = 0;
            GainXp = new[] {10};
            energy = new[] {3};
            water = new[] {3};
            Image = new[] {"res://assets/ImageSized/isometric station service1.png"};
            NbrAmeliorations = 0;
            NbCar = 2;
            Population = new[] {0};
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
        public int NbCar { get; }
        public int[] Population { get; }
    }
}