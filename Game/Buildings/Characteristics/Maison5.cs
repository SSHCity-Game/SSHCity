using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Maison5 : IBuildingCharacteristics
    {
        public Maison5()
        {
            Bloc = new[] {Ref_donnees.maison5, Ref_donnees.maisonEcolo};
            Cost = new[] {1000, 5000};
            Earn = new[] {1, 3};
            Titre = new[] {"Maison", "Maison Ecolo"};
            Lvl = 0;
            GainXp = new[] {10, 15};
            energy = new[] {2, 0};
            water = new[] {2, 0};
            Image = new[] {"res://assets/ImageSized/maison5.png", "res://assets/ImageSized/isometric maison ecolo.png"};
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