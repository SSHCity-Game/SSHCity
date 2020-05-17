using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Restaurant2 : IBuildingCharacteristics
    {
        public Restaurant2()
        {
            Bloc = new[] {Ref_donnees.restaurant2};
            Cost = new[] {5000};
            Earn = new[] {10, 15, 20};
            Titre = new[] {"Restaurant2"};
            Lvl = 0;
            GainXp = new[] {10, 100, 500};
            Consomationelec = new[] {1};
            Consomationeau = new[] {2};
            Image = new[] {"res://assets/ImageSized/restaurant2.png"};
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