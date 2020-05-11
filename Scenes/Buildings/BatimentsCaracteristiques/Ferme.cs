using Godot;
using SshCity.Scenes.Plan;

namespace SshCity.Scenes.Buildings.BatimentsCaracteristiques
{
    public class Ferme
    {
        public static int[] _bloc = {Ref_donnees.ferme};
        public static int[] _cost = {3000};
        public static int[] _earn = {2,5,8};
        public static string[] _titre = {"ferme"};
        public static int lvl = 0;
        public static readonly int[] gain_xp = {10, 100, 500};
        public static string[] _image = {"res://assets/isometric ferme2.png"};
        public static int nbrAmeliorations = 0;
        public static Batiments.Class _class = Batiments.Class.FERME;
        public static Caracteristiques.BatimentsCaracteristiques cara = new Caracteristiques.BatimentsCaracteristiques(nbrAmeliorations, _bloc, _cost, _earn, _titre, gain_xp, _image, _class);
    }
}