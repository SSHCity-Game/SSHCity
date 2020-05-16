using SshCity.Game.Buildings;
using SshCity.Game.Buildings.BatimentsCaracteristiques;
using SshCity.Game.Plan;

public class Piscine : Caracteristiques
{
    public static int[] _bloc = {Ref_donnees.piscine};
    public static int[] _cost = {10000};
    public static int[] _earn = {20, 30, 50};
    public static string[] _titre = {"Piscine"};
    public static int lvl = 0;
    public static readonly int[] gain_xp = {10, 100, 500};
    public static int[] _consomationelec = {1};
    public static int[] _consomationeau = {3};
    public static string[] _image = {"res://assets/ImageSized/isometric piscine1.png"};
    public static int nbrAmeliorations = 0;
    public static BuildingType _class = BuildingType.PISCINE;

    BatimentsCaracteristiques cara =
        new BatimentsCaracteristiques(nbrAmeliorations,
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