using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Hospital : IBuildingCharacteristics
    {
        public Hospital()
        {
            Bloc = new[] {Ref_donnees.hopital, Ref_donnees.hopitallv2, Ref_donnees.hopitallv3};
            Cost = new[] {10000, 20000, 30000};
            Earn = new[] {15, 30, 50};
            Titre = new[] {"Hôpital", "Hôpital", "Hôpital"};
            Lvl = 0;
            GainXp = new[] {10, 15, 30};
            energy = new[] {2, 5, 10};
            water = new[] {2, 5, 10};
            Image = new[] {"res://assets/ImageSized/hopital.png", "res://assets/ImageSized/hopital3.png", "res://assets/ImageSized/hopital4.png"};
            NbrAmeliorations = 2;
            NbCar = 5;
            Population = new []{0, 0, 0};
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