using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Maison5 : IBuildingCharacteristics
    {
        public Maison5()
        {
            Bloc = new[] {Ref_donnees.maison5};
            Cost = new[] {1000};
            Earn = new[] {1, 2, 5};
            Titre = new[] {"Maison5"};
            Lvl = 0;
            GainXp = new[] {10, 100, 500};
            Consomationelec = new[] {1};
            Consomationeau = new[] {1};
            Image = new[] {"res://assets/ImageSized/maison5.png"};
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