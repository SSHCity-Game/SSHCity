using SshCity.Game.Plan;

namespace SshCity.Game.Buildings.BatimentsCaracteristiques
{
    public class Maison
    {
        public static int[] _bloc = {Ref_donnees.maison1};
        public static int[] _cost = {1000};
        public static int[] _earn = {1, 2, 5};
        public static string[] _titre = {"Maison"};
        public static int lvl = 0;
        public static readonly int[] gain_xp = {10, 100, 500};
        public static int[] _consomationelec = {1};
        public static int[] _consomationeau = {1};
        public static string[] _image = {"res://assets/ImageSized/maison1.png"};
        public static int nbrAmeliorations = 0;
        public static BuildingType _class = BuildingType.MAISON;

        public static Caracteristiques.BatimentsCaracteristiques cara =
            new Caracteristiques.BatimentsCaracteristiques(nbrAmeliorations,
                _bloc,
                _cost,
                _earn,
                _titre,
                gain_xp,
                _image,
                _class,
                _consomationelec,
                _consomationeau);
    }
}