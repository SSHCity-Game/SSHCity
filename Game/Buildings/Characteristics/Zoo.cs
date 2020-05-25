using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Zoo : IBuildingCharacteristics
    {
        public Zoo()
        {
            Bloc = new[] {Ref_donnees.zoo};
            Cost = new[] {10000};
            Earn = new[] {25};
            Titre = new[] {"Zoo"};
            Lvl = 0;
            GainXp = new[] {10};
            energy = new[] {3};
            water = new[] {5};
            Image = new[] {"res://assets/ImageSized/isometric zoo.png"};
            NbrAmeliorations = 0;
            NbCar = 0;
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