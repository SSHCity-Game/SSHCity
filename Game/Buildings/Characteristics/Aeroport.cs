using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Aeroport : IBuildingCharacteristics
    {
        public Aeroport()
        {
            Bloc = new[] {Ref_donnees.aeroport};
            Cost = new[] {15000};
            Earn = new[] {100};
            Titre = new[] {"Aéroport"};
            Lvl = 0;
            GainXp = new[] {10};
            energy = new[] {20};
            water = new[] {20};
            Image = new[] {"res://assets/ImageSized/isometric aeroport.png"};
            NbrAmeliorations = 0;
            NbCar = 0;
            Population = new[] {10};
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