using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class FeteForraine : IBuildingCharacteristics
    {
        public FeteForraine()
        {
            Bloc = new[] {Ref_donnees.feteForraine};
            Cost = new[] {20000};
            Earn = new[] {60};
            Titre = new[] {"Fete Forraine"};
            Lvl = 0;
            GainXp = new[] {10};
            energy = new[] {15};
            water = new[] {10};
            Image = new[] {"res://assets/ImageSized/isometric fete foraine1.png"};
            NbrAmeliorations = 0;
            NbCar = 2;
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