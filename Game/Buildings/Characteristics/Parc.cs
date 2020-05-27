using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Parc : IBuildingCharacteristics
    {
        public Parc()
        {
            Bloc = new[] {Ref_donnees.parc_enfant, Ref_donnees.parc2, Ref_donnees.parc3};
            Cost = new[] {100, 1000, 5000};
            Earn = new[] {1, 3, 6};
            Titre = new[] {"Parc", "Parc", "Parc"};
            Lvl = 0;
            GainXp = new[] {10, 15, 30};
            energy = new[] {0, 0, 0};
            water = new[] {0, 0, 0};
            Image = new[]
            {
                "res://assets/ImageSized/iso parc enfant4.png", "res://assets/ImageSized/I parc enfant.png",
                "res://assets/ImageSized/I parc enfant2.png"
            };
            NbrAmeliorations = 2;
            NbCar = 0;
            Population = new[] {0, 0, 0};
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