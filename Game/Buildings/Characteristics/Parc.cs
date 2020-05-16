using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Parc : IBuildingCharacteristics
    {
        public Parc()
        {
            Bloc = new[] {Ref_donnees.parc_enfant};
            Cost = new[] {100};
            Earn = new[] {1, 1,1};
            Titre = new[] {"Parc"};
            Lvl = 0;
            GainXp = new[] {10, 100, 500};
            Consomationelec = new[] {0};
            Consomationeau = new[] {0};
            Image = new[] {"res://assets/ImageSized/iso parc enfant4.png"};
            NbrAmeliorations = 0;
        }

        public int[] Bloc { get; }
        public int[] Cost { get; }
        public int[] Earn { get; }
        public string[] Titre { get; }
        public int Lvl { get; }
        public int[] GainXp { get; }
        public int[] Consomationelec { get; }
        public int[] Consomationeau { get; }
        public string[] Image { get; }
        public int NbrAmeliorations { get; }
    }
}