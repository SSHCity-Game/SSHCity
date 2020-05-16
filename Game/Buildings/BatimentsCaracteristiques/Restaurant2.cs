using SshCity.Game.Buildings;
using SshCity.Game.Buildings.BatimentsCaracteristiques;
using SshCity.Game.Plan;

public class Restaurant2
{
    public static int[] _bloc = {Ref_donnees.restaurant2};
    public static int[] _cost = {5000};
    public static int[] _earn = {10, 15, 20};
    public static string[] _titre = {"Restaurant2"};
    public static int lvl = 0;
    public static readonly int[] gain_xp = {10, 100, 500};
    public static int[] _consomationelec = {1};
    public static int[] _consomationeau = {2};
    public static string[] _image = {"res://assets/ImageSized/iso resto.png"};
    public static int nbrAmeliorations = 0;
    public static BuildingType _class = BuildingType.RESTAURANT2;

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