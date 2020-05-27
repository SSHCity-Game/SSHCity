using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class FermeGrande : IBuildingCharacteristics
    {
        public FermeGrande()
        {
            Bloc = new[] {Ref_donnees.ferme3, Ref_donnees.ferme4};
            Cost = new[] {20000, 30000};
            Earn = new[] {40, 90};
            Titre = new[] {"Ferme", "Ferme"};
            Lvl = 0;
            GainXp = new[] {10, 15};
            energy = new[] {10, 20};
            water = new[] {11, 22};
            Image = new[]
                {"res://assets/ImageSized/isometric ferme3.png", "res://assets/ImageSized/isometric ferme4.png"};
            NbrAmeliorations = 1;
            NbCar = 2;
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