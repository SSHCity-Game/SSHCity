using System.Collections.Generic;
using SshCity.Game.Buildings.Characteristics;

namespace SshCity.Game.Buildings
{
    public interface IBuildingCharacteristics
    {
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

    public static class BuildingCharacteristics
    {
        private static readonly Dictionary<BuildingType, IBuildingCharacteristics> _dictionary =
            new Dictionary<BuildingType, IBuildingCharacteristics>
            {
                {BuildingType.CAFE, new Cafe()},
                {BuildingType.CASERNE, new Caserne()},
                {BuildingType.CENTRALE, new CentraleElectrique()},
                {BuildingType.EGLISE, new Eglise()},
                {BuildingType.FERME, new Ferme()},
                {BuildingType.HOSPITAL, new Hospital()},
                {BuildingType.HOTEL, new Hotel()},
                {BuildingType.IMMEUBLE, new Immeuble()},
                {BuildingType.IMMEUBLE_VERT, new ImmeubleVert()},
                {BuildingType.MAISON, new Maison()},
                {BuildingType.MAISON3, new Maison3()},
                {BuildingType.MAISON4, new Maison4()},
                {BuildingType.MAISON5, new Maison5()},
                {BuildingType.MCALLY, new McAlly()},
                {BuildingType.PARC, new Parc()},
                {BuildingType.PISCINE, new Piscine()},
                {BuildingType.RESTAURANT, new Restaurant()},
                {BuildingType.POLICE, new Police()},
                {BuildingType.RESTAURANT2, new Restaurant2()},
            };


        public static IBuildingCharacteristics FromType(BuildingType type)
        {
            return _dictionary.TryGetValue(type, out var build) ? build : null;
        }
    }
}