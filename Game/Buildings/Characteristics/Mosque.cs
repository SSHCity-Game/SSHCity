using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Mosque : IBuildingCharacteristics
    {
        public Mosque()
        {
            Bloc = new[] {Ref_donnees.mosque, Ref_donnees.mosque2, Ref_donnees.mosque3};
            Cost = new[] {2000, 5000, 10000};
            Earn = new[] {1, 2, 5};
            Titre = new[] {"Mosque", "Mosque", "Mosque"};
            Lvl = 0;
            GainXp = new[] {10, 15, 30};
            energy = new[] {1, 3, 6};
            water = new[] {2, 3, 5};
            Image = new[] {"res://assets/ImageSized/isometric mosquee2.png", "res://assets/ImageSized/isometric mosquee1.png", "res://assets/ImageSized/isometric mosquee3.png"};
            NbrAmeliorations = 2;
            NbCar = 0;
            Population =new[] {0, 0, 0};
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