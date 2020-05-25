using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Maison4 : IBuildingCharacteristics
    {
        public Maison4()
        {
            Bloc = new[] {Ref_donnees.maison4, Ref_donnees.immeubleVerre};
            Cost = new[] {1000, 5000};
            Earn = new[] {1, 5};
            Titre = new[] {"Maison", "Tour"};
            Lvl = 0;
            GainXp = new[] {10, 15};
            energy = new[] {1,3};
            water = new[] {1,3};
            Image = new[] {"res://assets/ImageSized/maison4.png", "res://assets/ImageSized/isometric immeuble.png"};
            NbrAmeliorations = 1;
            NbCar = 2;
            Population = new[] {5, 15};
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