using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Ferme : IBuildingCharacteristics
    {
        public Ferme()
        {
            Bloc = new[] {Ref_donnees.ferme, Ref_donnees.ferme_ecolo};
            Cost = new[] {3000, 4000};
            Earn = new[] {2, 5};
            Titre = new[] {"Ferme", "Ferme Ecolo"};
            Lvl = 0;
            GainXp = new[] {10, 15};
            energy = new[] {1, 0};
            water = new[] {3, 0};
            Image = new[]
                {"res://assets/ImageSized/isometric ferme2.png", "res://assets/ImageSized/I ferme ecolobis.png"};
            NbrAmeliorations = 1;
            NbCar = 3;
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