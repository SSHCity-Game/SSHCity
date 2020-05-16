using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class CentraleElectrique : IBuildingCharacteristics
    {
        public CentraleElectrique()
        {
            Bloc = new[] {Ref_donnees.centrale};
            Cost = new[] {3000};
            Earn = new[] {2, 5, 8};
            Titre = new[] {"Centrale Electrique"};
            Lvl = 0;
            GainXp = new[] {10, 100, 500};
            Consomationelec = new[] {0};
            Consomationeau = new[] {3};
            Image = new[] {"res://assets/ImageSized/isometric centrale1.png"};
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