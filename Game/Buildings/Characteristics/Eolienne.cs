using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Eolienne : IBuildingCharacteristics
    {
        public Eolienne()
        {
            Bloc = new[] {Ref_donnees.eolienne};
            Cost = new[] {3000};
            Earn = new[] {2};
            Titre = new[] {"Eolienne"};
            Lvl = 0;
            GainXp = new[] {10};
            energy = new[] {-20};
            water = new[] {0};
            Image = new[] {"res://assets/ImageSized/isometric par eoliennes.png"};
            NbrAmeliorations = 0;
            NbCar = 0;
            Population = new []{0};
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