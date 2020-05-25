using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Restaurant : IBuildingCharacteristics
    {
        public Restaurant()
        {
            Bloc = new[] {Ref_donnees.restaurant, Ref_donnees.resto2};
            Cost = new[] {5000, 6000};
            Earn = new[] {10, 15};
            Titre = new[] {"Restaurant", "Restaurant"};
            Lvl = 0;
            GainXp = new[] {10, 15};
            energy = new[] {1, 3};
            water = new[] {2, 3};
            Image = new[] {"res://assets/ImageSized/isometric boutique5.png", "res://assets/ImageSized/isometric boutique9.png"};
            NbrAmeliorations = 1;
            NbCar = 0;
            Population = new[] {0, 0};
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