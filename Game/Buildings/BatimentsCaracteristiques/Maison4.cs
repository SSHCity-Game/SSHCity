using SshCity.Game.Buildings;
using SshCity.Game.Buildings.BatimentsCaracteristiques;
using SshCity.Game.Plan;

public class Maison4
{
    public static int[] _bloc = {Ref_donnees.maison4};
    public static int[] _cost = {1000};
    public static int[] _earn = {1, 2, 5};
    public static string[] _titre = {"Maison4"};
    public static readonly int[] gain_xp = {10, 100, 500};
    public static int[] _consomationelec = {1};
    public static int[] _consomationeau = {1};
    public static string[] _image = {"res://assets/ImageSized/maison4.png"};
    public static int nbrAmeliorations = 0;
    public static BuildingType _class = BuildingType.MAISON4;

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