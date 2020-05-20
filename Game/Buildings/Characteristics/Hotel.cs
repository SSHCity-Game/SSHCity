using System;
using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.Characteristics
{
    public class Hotel : IBuildingCharacteristics
    {
        public Hotel()
        {
            Bloc = new[] {Ref_donnees.hotel};
            Cost = new[] {2000};
            Earn = new[] {2,6,12};
            Titre = new[] {"Hôtel"};
            Lvl = 0;
            GainXp = new[] {10, 100, 500};
            energy = new[] {2};
            water = new[] {2};
            Image = new[] {"res://assets/ImageSized/hotel.png"};
            NbrAmeliorations = 0;
            NbCar = 10;
            Random pop= new Random();
            Population = new[] {pop.Next(5, 21),pop.Next(10,31),pop.Next(20,51)};
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