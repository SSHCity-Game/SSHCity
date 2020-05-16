using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Piscine : IBuildingCharacteristics
    {
        public Piscine()
        {
            Bloc = new[] {Ref_donnees.piscine};
            Cost = new[] {10000};
            Earn = new[] {20,30,50};
            Titre = new[] {"Piscine"};
            Lvl = 0;
            GainXp = new[] {10, 100, 500};
            Consomationelec = new[] {1};
            Consomationeau = new[] {3};
            Image = new[] {"res://assets/ImageSized/isometric piscine1.png"};
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