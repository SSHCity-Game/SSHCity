using System;

namespace SshCity.Scenes.Plan
{
    public class Ref_donnees
    {
        private Random rand;

 

        //Variables pour definir la taille de la Map 

        public static int size = 25; //Nombre de bloques sur un coté de la Map  // PAS UTILISE CAR CREATMAP() NE FONCTIONNE PAS

        public static int max_x = 127; //Coordonées max d'un bloque sur l'axe x
        public static int min_x = -16; //Coordonnées min d'un bloque sur l'axe x
        public static int max_y = 67; //Coordonées max d'un bloque sur l'axe y
        public static int min_y = -62; //Cooronnées min d'un bloque en y
        public static int min_village_x = 42;
        public static int max_village_x = 83;
        public static int min_village_y = -22;
        public static int max_village_y = 32;




        // Variables modifiables pour définir le nombres d'éléments sur la Map

        public static int max_flaque_eau = 8; //Nombre maximum de flaques d'eau
        public static int min_flaque_eau = 5; //Nombre minimum de flaque d'eau
        public static int max_block_flaque_eau = 25; //Nombre max de bloques eau pour une flaque
        public static int min_block_flaque_eau = 20; //Nombre Minimum de bloques eau pour une flaque
        public static int m_max = 8; //Nombre bocks montagnes à trois etages max
        public static int m_min = 5; //Nombre bocks montagnes à trois etages min

        //Vairable permettant d'indiquer l'indexe des bloques

        public static int index_terre = 0;
        public static int index_boite = 3;
        public static int index_eau = 2;
        public static int indexe_montagne = 8;
        public static int index_sable = 5;
        public static int index_maison     = 1;
        public static int index_accident   = 3;
        public static int index_route      = 9;
        public static int index_route_left = 18;
        public const int index_route_right = 17;
        public const int index_hopital = 15;
        public const int index_caserne = 14;
        public const int index_immeuble_verte = 16;
        public const int index_immeuble_brique = 13;
        public const int index_police = 12;
        
        //Variable bloquer camera

        public static float[] x_left = {252, 382, 502, 639, 765, 896, 1019, 1146, 1279};
        public static float[] x_right = {2324, 2197, 2070, 1940, 1817, 1680, 1557, 1430, 1300};
        public static float[] y_top = {150, 224, 300, 375, 450, 526, 598, 676, 752};
        public static float[] y_bot = {1502, 1427, 1348, 1280, 1197, 1122, 1046, 974, 900};
        public static float zoom_in_max = (float)0.5;
        public static float zoom_out_max = (float) 2.5;
        public static float zoom_coef = (float) 0.25;
    }
}