using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Usine : IBuildingCharacteristics
    {
        public Usine()
        {
            Bloc = new[] {Ref_donnees.usine1, Ref_donnees.usine2, Ref_donnees.usine3, Ref_donnees.usine4};
            Cost = new[] {5000, 10000, 20000, 30000};
            Earn = new[] {10, 30, 80, 150};
            Titre = new[] {"Usine", "Usine", "Usine", "Usine"};
            Lvl = 0;
            GainXp = new[] {10, 15, 30, 60};
            energy = new[] {5,10, 20, 30};
            water = new[] {2,4, 9, 15};
            Image = new[] {"res://assets/ImageSized/isometric usine1.png", "res://assets/ImageSized/isometric usine2.png", "res://assets/ImageSized/isometric usine3.png", "res://assets/ImageSized/isometric usine4.png"};
            NbrAmeliorations = 3;
            NbCar = 2;
            Population = new[] {0, 0, 0, 0};
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