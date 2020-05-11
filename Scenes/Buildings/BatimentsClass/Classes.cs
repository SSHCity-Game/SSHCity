using System.Configuration;
using Godot;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using SshCity.Scenes.Plan;

namespace SshCity.Scenes.Buildings
{
    public partial class Batiments
    {
        public enum Class
        {
            CAFE,
            MAISON,
            PARC,
            POLICE,
            CENTRALE,
            MAISON3,
            MAISON4,
            MAISON5,
            PISCINE,
            RESTAURANT,
            RESTAURANT2,
            MCALLY,
            FERME,
            HOSPITAL,
            EGLISE,
            IMMEUBLE,
            IMMEUBLEVERT,
            CASERNE,
            HOTEL
        };
        
        public static List<Building> ListBuildings = new List<Building>();
    }
}