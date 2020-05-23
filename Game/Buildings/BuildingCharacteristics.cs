using System;
using System.Collections.Generic;
using SshCity.Game.Buildings.Characteristics;

namespace SshCity.Game.Buildings
{
    /// <summary>
    /// Représente les caractéristiques que les bâtiments doivent posséder.
    /// </summary>
    public interface IBuildingCharacteristics
    {
        int[] Bloc { get; }
        int[] Cost { get; }
        int[] Earn { get; }
        string[] Titre { get; }
        int Lvl { get; set; }
        int[] GainXp { get; }
        int[] energy { get; }
        int[] water { get; } 
        string[] Image { get; }
        int NbrAmeliorations { get; }
        int NbCar { get; }
        int[] Population { get; }
    }

    /// <summary>
    /// Classe qui lie les types de bâtiments à leurs caractéristique par défaut
    /// </summary>
    public static class BuildingCharacteristics
    {
        private static readonly Dictionary<BuildingType, Type> _dictionary =
            new Dictionary<BuildingType, Type>
            {
                {BuildingType.CAFE, typeof(Cafe)},
                {BuildingType.CASERNE, typeof(Caserne)},
                {BuildingType.CENTRALE, typeof(CentraleElectrique)},
                {BuildingType.EGLISE, typeof(Eglise)},
                {BuildingType.FERME, typeof(Ferme)},
                {BuildingType.HOSPITAL, typeof(Hospital)},
                {BuildingType.HOTEL, typeof(Hotel)},
                {BuildingType.IMMEUBLE, typeof(Immeuble)},
                {BuildingType.IMMEUBLE_VERT, typeof(ImmeubleVert)},
                {BuildingType.MAISON, typeof(Maison)},
                {BuildingType.MAISON3, typeof(Maison3)},
                {BuildingType.MAISON4, typeof(Maison4)},
                {BuildingType.MAISON5, typeof(Maison5)},
                {BuildingType.MCALLY, typeof(McAlly)},
                {BuildingType.PARC, typeof(Parc)},
                {BuildingType.PISCINE, typeof(Piscine)},
                {BuildingType.RESTAURANT, typeof(Restaurant)},
                {BuildingType.POLICE, typeof(Police)},
                {BuildingType.RESTAURANT2, typeof(Restaurant2)},
                {BuildingType.EPURATION, typeof(Epuration)},
            };


        /// <summary>
        /// Créer une caractéristique par rapport type de bâtiment 
        /// </summary>
        /// <param name="type">Le type de bâtiment</param>
        /// <returns>La caractéristique par défaut de ce bâtiment</returns>
        public static IBuildingCharacteristics FromType(BuildingType type)
        {
            return (_dictionary.TryGetValue(type, out var build) ? Activator.CreateInstance(build) : null) as
                IBuildingCharacteristics;
        }
    }
}