using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Maison : IBuildingCharacteristics
    {
        public Maison()
        {
            Bloc = new[] {Ref_donnees.maison1, Ref_donnees.immeuble_vert, Ref_donnees.immeubleVert};
            Cost = new[] {1000, 3000, 10000};
            Earn = new[] {1,2,5};
            Titre = new[] {"Maison", "Immeuble", "Tour"};
            Lvl = 0;
            GainXp = new[] {10, 15, 30};
            energy = new[] {1,3,6};
            water = new[] {1,3,3};
            Image = new[] {"res://assets/ImageSized/maison1.png", "res://assets/ImageSized/immeuble.png", "res://assets/ImageSized/isometric hotel.png"};
            NbrAmeliorations = 2;
            NbCar = 2;
            Population = new[] {5, 15, 30};
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