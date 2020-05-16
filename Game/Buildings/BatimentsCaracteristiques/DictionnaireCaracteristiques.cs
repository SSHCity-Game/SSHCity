using Godot.Collections;
using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.BatimentsCaracteristiques
{
    public static class DictionnaireCaracteristiques
    {
        public static Dictionary<int, BuildingType> dictionnaireCaracteristiques =
            new Dictionary<int, BuildingType>()
            {
                {Ref_donnees.restaurant2, BuildingType.RESTAURANT2},
                {Ref_donnees.restaurant, BuildingType.RESTAURANT},
                {Ref_donnees.police, BuildingType.POLICE},
                {Ref_donnees.piscine, BuildingType.PISCINE},
                {Ref_donnees.parc_enfant, BuildingType.PARC},
                {Ref_donnees.McAffy, BuildingType.MCALLY},
                {Ref_donnees.maison5, BuildingType.MAISON5},
                {Ref_donnees.maison4, BuildingType.MAISON4},
                {Ref_donnees.maison3, BuildingType.MAISON3},
                {Ref_donnees.maison1, BuildingType.MAISON},
                {Ref_donnees.immeuble_vert, BuildingType.IMMEUBLE_VERT},
                {Ref_donnees.immeuble_brique, BuildingType.IMMEUBLE},
                {Ref_donnees.hotel, BuildingType.HOTEL},
                {Ref_donnees.hopital, BuildingType.HOSPITAL},
                {Ref_donnees.ferme, BuildingType.FERME},
                {Ref_donnees.eglise, BuildingType.EGLISE},
                {Ref_donnees.centrale, BuildingType.CENTRALE},
                {Ref_donnees.caserne, BuildingType.CASERNE},
                {Ref_donnees.cafe, BuildingType.CAFE}
            };
    }
}