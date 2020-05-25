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
        public static int energy = 20;
        public static int water = 20;
        public static int population = 20;
        public const int accident_voiture = 68;
        public const int voleur = 80;
        public const int rien = 81; // bloc vide
        public const int stationEpuration = 101;
        public const int sol_stationEpuration = 102;
        public const int hopitallv3 = 105;
        public const int hopitallv2 = 106;
        public const int centralelv2 = 107;
        public const int immeubleVert = 108;
        public const int immeubleVerre = 109;
        public const int feteForraine = 110;
        public const int aeroport = 111;
        public const int essence = 112;
        public const int basket = 113;
        public const int foot = 114;
        public const int footlv2 = 115;
        public const int footlv3 = 116;
        public const int eolienne = 117;
        public const int solaire = 118;
        public const int usine1 = 119;
        public const int usine2 = 120;
        public const int usine3 = 121;
        public const int usine4 = 122;
        public const int maisonEcolo = 123;
        public const int zoo = 124;
        public const int eglise3 = 125;
        public const int eglise2 = 126;
        public const int hotel2 = 127;
        public const int hotel1 = 128;
        public const int ferme3 = 129;
        public const int ferme4 = 130;
        public const int parc2 = 131;
        public const int parc3 = 132;
        public const int resto2 = 133;
        public const int burgeur = 134;
        public const int mosque = 135;
        public const int mosque2 = 136;
        public const int mosque3 = 137;
        
        /* Incendie Batiments */
        public const int restaurant_flamme = 3;
        public const int eglise_flamme = 4;
        public const int maison1_flamme = 6;
        public const int maison4_flamme = 7;
        public const int maison5_flamme = 8;
        public const int maison3_flamme = 57;
        public const int cafe_flamme = 60;
        public const int restaurant2_flamme = 62;
        public const int ferme2_flamme = 139;
        public const int ferme3_flamme = 140;
        public const int mosque2_flamme = 141;
        public const int station_service1_flamme = 142;
        public const int usine1_flamme = 143;
        
        
        /* Vol Batiments*/
        public const int maison1_vol = 96;
        public const int maison4_vol = 98;
        public const int maison5_vol = 99;
        public const int maison3_vol = 97;
        public const int mairie_vol = 95;
        
        /* Noyade lac */
        public const int lac1_noyade = 100;
        
        //Lac Bloc
        public const int water_terre = 78;
        public const int lac1 = 63;
        public const int lac2 = 64;
        
        //Blocs tuyaux
        public const int tuyaux_right = 81;
        public const int tuyaux_left = 83;
        public const int tuyaux_virage_bas = 82;
        public const int tuyaux_virage_haut = 84;
        public const int tuyaux_virage_droit = 87;
        public const int tuyaux_virage_gauche = 86;
        public const int tuyaux_T_haut_droit = 89;
        public const int tuyaux_T_bas_droit = 91;
        public const int tuyaux_T_haut_gauche = 92;
        public const int tuyaux_T_bas_gauche = 90;
        public const int tuyaux_croisement = 88;
        public const int sol_tuyaux = 80;
        public const int tuyaux_terre = 93;
        public const int sol_maisonEau = 103;

        //bulles Bloc
        public const int bulleRoute = 79;
        public const int bulleEau = 104; 

        /* Liste batiment, batiment en feu */
        public static (int, int)[] BatimentFeu = {
            (maison1, maison1_flamme), (maison3, maison3_flamme), (maison4, maison4_flamme), 
            (maison5, maison5_flamme), (restaurant, restaurant_flamme), (restaurant2, restaurant2_flamme), 
            (eglise, eglise_flamme), (cafe, cafe_flamme), (ferme, ferme2_flamme),
            (ferme3, ferme3_flamme), (mosque2, mosque2_flamme), (essence, station_service1_flamme), 
            (usine1, usine1_flamme)
        };
        
        /* Liste lac, lac avec noye */
        public static (int, int)[] LacNoyade = {
            (lac1, lac1_noyade)
        };
        
        /* Liste batiment, batiment braque */
        public static (int, int)[] BatimentVol = {
            (maison1, maison1_vol), (maison3, maison3_vol),
            (maison4, maison4_vol), (maison5, maison5_vol), (mairie, mairie_vol)
        };
        
        
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
            {centralelv2, (3,4)},
            {stationEpuration, (3,3)},
            {hopital, (2,2)},
            {hopitallv3, (2,2)},
            {feteForraine, (3, 4)},
            {aeroport, (3, 4)},
            {foot, (2, 2)},
            {footlv2, (2, 2)},
            {footlv3, (2, 2)},
            {eolienne, (2, 2)},
            {solaire, (2, 2)},
            {usine1, (2, 2)},
            {usine2, (2, 2)},
            {usine3, (2, 2)}, 
            {usine4, (2, 2)},
            {zoo, (2, 2)},
            {ferme3, (2, 2)},
            {ferme4, (2, 2)},
        };

        private Random rand;
    }
}