using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Hotel : IBuildingCharacteristics
    {
        public Hotel()
        {
            Bloc = new[] {Ref_donnees.hotel1, Ref_donnees.hotel, Ref_donnees.hotel2};
            Cost = new[] {2000, 10000, 15000};
            Earn = new[] {2, 15, 50};
            Titre = new[] {"Môtel", "Hotel", "Palace"};
            Lvl = 0;
            GainXp = new[] {10, 15, 30};
            energy = new[] {2, 10, 25};
            water = new[] {2, 10, 25};
            Image = new[]
            {
                "res://assets/ImageSized/I hotel.png", "res://assets/ImageSized/hotel.png",
                "res://assets/ImageSized/isometric hotel1.png"
            };
            NbrAmeliorations = 2;
            NbCar = 3;
            Population = new[] {5, 20, 30};
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