using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Solaire : IBuildingCharacteristics
    {
        public Solaire()
        {
            Bloc = new[] {Ref_donnees.solaire};
            Cost = new[] {2000};
            Earn = new[] {1};
            Titre = new[] {"Solaire"};
            Lvl = 0;
            GainXp = new[] {10};
            energy = new[] {-30};
            water = new[] {0};
            Image = new[] {"res://assets/ImageSized/isometric parc panneaux solaires.png"};
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