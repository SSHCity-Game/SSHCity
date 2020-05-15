using Godot;
using SshCity.Scenes.Plan;

namespace SshCity.Scenes.Buildings.BatimentsCaracteristiques
{
    public class Eglise
    {
        public static int[] _bloc = {Ref_donnees.eglise};
        public static int[] _cost = {4000};
        public static int[] _earn = {1, 2, 3};
        public static string[] _titre = {"Eglise"};
        public static int lvl = 0;
        public static readonly int[] gain_xp = {10, 100, 500};
        public static int[] _consomationelec = {2};
        public static string[] _image = {"res://assets/isometric eglise1.png"};
        public static int nbrAmeliorations = 0;
        public static Batiments.Class _class = Batiments.Class.EGLISE;
        public static Caracteristiques.BatimentsCaracteristiques cara = new Caracteristiques.BatimentsCaracteristiques(nbrAmeliorations, _bloc, _cost, _earn, _titre, gain_xp, _image, _class,_consomationelec);
    }
}
