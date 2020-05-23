using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Mairie : IBuildingCharacteristics
    {
        public Mairie()
        {
            Bloc = new[] {Ref_donnees.mairie};
            Cost = new[] {0};
            Earn = new[] {0};
            Titre = new[] {"Mairie"};
            Lvl = 0;
            GainXp = new[] {0};
            energy = new[] {0};
            water = new[] {0};
            Image = new[] {"res://assets/ImageSized/mairie.png"};
            NbrAmeliorations = 0;
            NbCar = 0;
            Population = new[] {0};
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