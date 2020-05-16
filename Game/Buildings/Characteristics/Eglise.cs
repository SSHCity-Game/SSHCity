using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Eglise : IBuildingCharacteristics
    {
        public Eglise()
        {
            Bloc = new[] {Ref_donnees.eglise};
            Cost = new[] {4000};
            Earn = new[] {1, 2, 3};
            Titre = new[] {"Eglise"};
            Lvl = 0;
            GainXp = new[] {10, 100, 500};
            Consomationelec = new[] {2};
            Consomationeau = new[] {1};
            Image = new[] {"res://assets/ImageSized/isometric eglise1.png"};
            NbrAmeliorations = 0;
        }

        public int[] Bloc { get; }
        public int[] Cost { get; }
        public int[] Earn { get; }
        public string[] Titre { get; }
        public int Lvl { get; set; }
        public int[] GainXp { get; }
        public int[] Consomationelec { get; }
        public int[] Consomationeau { get; }
        public string[] Image { get; }
        public int NbrAmeliorations { get; }
    }
}