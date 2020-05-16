using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Cafe : IBuildingCharacteristics
    {
        public Cafe()
        {
            Bloc = new[] {Ref_donnees.cafe};
            Cost = new[] {1000, 1500};
            Earn = new[] {1, 2, 5};
            Titre = new[] {"Cafe"};
            Lvl = 0;
            GainXp = new[] {10, 100, 500};
            Consomationelec = new[] {1};
            Consomationeau = new[] {2};
            Image = new[] {"res://assets/ImageSized/isometric magasin6.png"};
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