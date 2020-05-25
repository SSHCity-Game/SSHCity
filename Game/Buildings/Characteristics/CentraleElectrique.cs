using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class CentraleElectrique : IBuildingCharacteristics
    {
        public CentraleElectrique()
        {
            Bloc = new[] {Ref_donnees.centrale, Ref_donnees.centralelv2};
            Cost = new[] {3000, 6000};
            Earn = new[] {2, 5};
            Titre = new[] {"Centrale Electrique", "Centrale Electrique"};
            Lvl = 0;
            GainXp = new[] {10, 15};
            energy = new[] {-30, -70};
            water = new[] {3, 6};
            Image = new[] {"res://assets/ImageSized/isometric centrale1.png", "res://assets/ImageSized/isometric centrale2.png"};
            NbrAmeliorations = 1;
            NbCar = 0;
            Population = new [] {0, 0};
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