using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Hospital : IBuildingCharacteristics
    {
        public Hospital()
        {
            Bloc = new[] {Ref_donnees.hopital};
            Cost = new[] {10000};
            Earn = new[] {15, 30, 50};
            Titre = new[] {"Hôpital"};
            Lvl = 0;
            GainXp = new[] {10, 100, 500};
            Consomationelec = new[] {2};
            Consomationeau = new[] {2};
            Image = new[] {"res://assets/ImageSized/hopital.png"};
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