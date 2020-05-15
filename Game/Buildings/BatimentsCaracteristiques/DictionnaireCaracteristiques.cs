using Godot.Collections;
using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.BatimentsCaracteristiques
{
    public static class DictionnaireCaracteristiques
    {
        public static Dictionary<int, Batiments.Class> dictionnaireCaracteristiques =
            new Dictionary<int, Batiments.Class>()
            {
                {Ref_donnees.restaurant2, Batiments.Class.RESTAURANT2},
                {Ref_donnees.restaurant, Batiments.Class.RESTAURANT},
                {Ref_donnees.police, Batiments.Class.POLICE},
                {Ref_donnees.piscine, Batiments.Class.PISCINE},
                {Ref_donnees.parc_enfant, Batiments.Class.PARC},
                {Ref_donnees.McAffy, Batiments.Class.MCALLY},
                {Ref_donnees.maison5, Batiments.Class.MAISON5},
                {Ref_donnees.maison4, Batiments.Class.MAISON4},
                {Ref_donnees.maison3, Batiments.Class.MAISON3},
                {Ref_donnees.maison1, Batiments.Class.MAISON},
                {Ref_donnees.immeuble_vert, Batiments.Class.IMMEUBLEVERT},
                {Ref_donnees.immeuble_brique, Batiments.Class.IMMEUBLE},
                {Ref_donnees.hotel, Batiments.Class.HOTEL},
                {Ref_donnees.hopital, Batiments.Class.HOSPITAL},
                {Ref_donnees.ferme, Batiments.Class.FERME},
                {Ref_donnees.eglise, Batiments.Class.EGLISE},
                {Ref_donnees.centrale, Batiments.Class.CENTRALE},
                {Ref_donnees.caserne, Batiments.Class.CASERNE},
                {Ref_donnees.cafe, Batiments.Class.CAFE}
            };
    }
}