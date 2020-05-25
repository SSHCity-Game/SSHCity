using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Eglise : IBuildingCharacteristics
    {
        public Eglise()
        {
            Bloc = new[] {Ref_donnees.eglise, Ref_donnees.eglise3, Ref_donnees.eglise2};
            Cost = new[] {4000, 6000, 10000};
            Earn = new[] {1, 2, 3};
            Titre = new[] {"Eglise", "Eglise", "Cathédrale"};
            Lvl = 0;
            GainXp = new[] {10, 15, 30};
            energy = new[] {2, 4, 6};
            water = new[] {1, 3, 9};
            Image = new[] {"res://assets/ImageSized/isometric eglise1.png", "res://assets/ImageSized/isometric eglise5.png", "res://assets/ImageSized/isometric eglise4.png"};
            NbrAmeliorations = 2;
            NbCar = 0;
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