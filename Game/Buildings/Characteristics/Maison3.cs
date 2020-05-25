using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Maison3 : IBuildingCharacteristics
    {
        public Maison3()
        {
            Bloc = new[] {Ref_donnees.maison3, Ref_donnees.immeuble_brique};
            Cost = new[] {1000, 1500};
            Earn = new[] {1, 3};
            Titre = new[] {"Maison"};
            Lvl = 0;
            GainXp = new[] {10, 15};
            energy = new[] {1,3};
            water = new[] {1,3};
            Image = new[] {"res://assets/ImageSized/maison3.png", "res://assets/ImageSized/maison2.png"};
            NbrAmeliorations = 1;
            NbCar = 2;
            Population = new[] {5, 15};
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