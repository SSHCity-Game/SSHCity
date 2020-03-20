using System;

namespace SshCity.Scenes.Plan
{
    public class Ref_donnees
    {
        private Random rand;

 

        //Variables pour definir la taille de la Map 

        public static int size = 25; //Nombre de bloques sur un coté de la Map  // PAS UTILISE CAR CREATMAP() NE FONCTIONNE PAS
        public static int m_max = 5; //Nombre bocks montagnes à trois etages max
        public static int m_min = 3; //Nombre bocks montagnes à trois etages min
        public static int max_x = 51; //Coordonées max d'un bloque sur l'axe x
        public static int min_x = -16; //Coordonnées min d'un bloque sur l'axe x
        public static int max_y = 19; //Coordonées max d'un bloque sur l'axe y
        public static int min_y = -29; //Cooronnées min d'un bloque en y

        // Variables modifiables pour définir le nombres d'éléments sur la Map

        public static int max_flaque_eau = 4; //Nombre maximum de flaques d'eau
        public static int min_flaque_eau = 2; //Nombre minimum de flaque d'eau
        public static int max_block_flaque_eau = 15; //Nombre max de bloques eau pour une flaque
        public static int min_block_flaque_eau = 10; //Nombre Minimum de bloques eau pour une flaque

        //Vairable permettant d'indiquer l'indexe des bloques

        public static int index_terre = 0;
        public static int index_boite = 3;
        public static int index_eau = 2;
        public static int indexe_montagne = 8;
        public static int index_sable = 5;
        public static int index_maison     = 1;
        public static int index_accident   = 3;
        public static int index_route      = 9;
    }
}