using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Foot : IBuildingCharacteristics
    {
        public Foot()
        {
            Bloc = new[] {Ref_donnees.foot, Ref_donnees.footlv2, Ref_donnees.footlv3};
            Cost = new[] {3000, 10000, 20000};
            Earn = new[] {2,50, 100};
            Titre = new[] {"Terrain Foot", "Stadium", "Stade"};
            Lvl = 0;
            GainXp = new[] {10, 15, 30};
            energy = new[] {1, 5, 10};
            water = new[] {1, 5, 10};
            Image = new[] {"res://assets/ImageSized/isometric terrain foot1.png", "res://assets/ImageSized/isometric terrain foot2.png", "res://assets/ImageSized/isometric terrain foot3.png"};
            NbrAmeliorations = 2;
            NbCar = 1;
            Population = new []{0, 0, 0};
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