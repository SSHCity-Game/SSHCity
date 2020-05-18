using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class ImmeubleVert : IBuildingCharacteristics
    {
        public ImmeubleVert()
        {
            Bloc = new[] {Ref_donnees.immeuble_vert};
            Cost = new[] {4000};
            Earn = new[] {4, 6, 8};
            Titre = new[] {"Immeuble Vert"};
            Lvl = 0;
            GainXp = new[] {10, 100, 500};
            energy = new[] {2};
            water = new[] {2};
            Image = new[] {"res://assets/ImageSized/immeuble.png"};
            NbrAmeliorations = 0;
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
    }
}