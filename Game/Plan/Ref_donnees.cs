using System;
using System.Collections.Generic;

namespace SshCity.Game.Plan
{
    public class Ref_donnees
    {
        //Variables pour definir la taille de la Map 

        public const int size = 25; //Nombre de bloques sur un coté de la Map  // PAS UTILISE CAR CREATMAP() NE FONCTIONNE PAS

        public const int max_x = 127; //Coordonées max d'un bloque sur l'axe x
        public const int min_x = -16; //Coordonnées min d'un bloque sur l'axe x
        public const int max_y = 67; //Coordonées max d'un bloque sur l'axe y
        public const int min_y = -62; //Cooronnées min d'un bloque en y
        public const int min_village_x = 42;
        public const int max_village_x = 83;
        public const int min_village_y = -22;
        public const int max_village_y = 32;


        // Variables modifiables pour définir le nombres d'éléments sur la Map

        public const int max_flaque_eau = 8; //Nombre maximum de flaques d'eau
        public const int min_flaque_eau = 5; //Nombre minimum de flaque d'eau
        public const int max_block_flaque_eau = 25; //Nombre max de bloques eau pour une flaque
        public const int min_block_flaque_eau = 20; //Nombre Minimum de bloques eau pour une flaque
        public const int m_max = 20; //Nombre bocks montagnes à trois etages max
        public const int m_min = 15; //Nombre bocks montagnes à trois etages min

        // Variable permettant d'indiquer l'indexe des blocs
        // todo : convertir en une enum
        public const int terre = 0;
        public const int montagne_sol = 1;
        public const int eau = 2;
        public const int sable = 5;
        public const int route = 9;
        public const int maison1 = 11;
        public const int police = 12;
        public const int immeuble_brique = 13;
        public const int caserne = 14;
        public const int hopital = 15;
        public const int immeuble_vert = 16;
        public const int hotel = 20;
        public const int maison3 = 21;
        public const int maison4 = 22;
        public const int maison5 = 23;
        public const int cafe = 24;
        public const int McAffy = 25;
        public const int Molly = 26;
        public const int piscine = 27;
        public const int shop = 28;
        public const int ferme = 30;
        public const int eglise = 31;
        public const int mairie = 32;
        public const int tea_shop = 33;
        public const int restaurant = 34;
        public const int restaurant2 = 35;
        public const int parc_enfant = 36;
        public const int route_T_bas_gauche = 41;
        public const int route_croisement = 42;
        public const int route_right = 43;
        public const int route_left = 44;
        public const int route_T_bas_droite = 45;
        public const int route_virage_gauche = 46;
        public const int route_virage_bas = 47;
        public const int route_virage_droit = 48;
        public const int route_virage_haut = 49;
        public const int route_T_haut_droit = 50;
        public const int route_T_haut_gauche = 51;
        public const int route_bord_bas_droit = 52;
        public const int route_bord_bas_gauche = 53;
        public const int route_bord_haut_droit = 54;
        public const int route_bord_haut_gauche = 55;
        public const int montagne = 56;
        public const int centrale = 58;
        public const int ferme_ecolo = 59;
        /* Incendie Batiments */
        public const int boutique5_flamme = 3;
        public const int eglise1_flamme = 4;
        public const int maison1_flamme = 6;
        public const int maison4_flamme = 7;
        public const int maison5_flamme = 8;
        public const int maison3_flamme = 57;
        public const int cafe_flamme = 60;
        public const int resto_flamme= 62;

        
        
        // Sauvegarde
        public const string GameSavePath = "user://sshcity.save";
        
        //Variable bloquer camera
        public static float[] x_left = {252, 382, 502, 639, 765, 896, 1019, 1146, 1279};
        public static float[] x_right = {2324, 2197, 2070, 1940, 1817, 1680, 1557, 1430, 1300};
        public static float[] y_top = {150, 224, 300, 375, 450, 526, 598, 676, 752};
        public static float[] y_bot = {1502, 1427, 1348, 1280, 1197, 1122, 1046, 974, 900};
        public static float zoom_in_max = (float) 0.5;
        public static float zoom_out_max = (float) 2.5;
        public static float zoom_coef = (float) 0.25;

        //argent
        public static int argent = 100000;

        //Dimensions blocs
        public static Dictionary<int, (int, int)> dimensions = new Dictionary<int, (int, int)>()
        {
            {centrale, (3, 4)},
            {ferme, (2, 2)}
        };

        private Random rand;
    }
}