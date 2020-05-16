using SshCity.Game.Buildings;
using SshCity.Game.Buildings.BatimentsCaracteristiques;

public class Immeuble
{
    public static int[] _bloc = {11};
    public static int[] _cost = {4000};
    public static int[] _earn = {4, 6, 8};
    public static string[] _titre = {"Immeuble"};
    public static int lvl = 0;
    public static readonly int[] gain_xp = {10, 100, 500};
    public static int[] _consomationelec = {2};
    public static int[] _consomationeau = {2};
    public static string[] _image = {"res://assets/ImageSized/maison2.png"};
    public static int nbrAmeliorations = 0;
    public static BuildingType _class = BuildingType.IMMEUBLE;

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