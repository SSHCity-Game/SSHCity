using SshCity.Game.Buildings;
using SshCity.Game.Buildings.BatimentsCaracteristiques;
using SshCity.Game.Plan;

public class Caserne : Carte
{
    public static int nbrAmeliorations = 0;
    public static Batiments.Class _class = Batiments.Class.CASERNE;
    public static int[] _bloc = {Ref_donnees.caserne};
    public static int[] _cost = {5000};
    public static int[] _earn = {10, 25, 50};
    public static string[] _titre = {"Caserne"};
    public static int[] _consomationelec = {2};
    public static int[] _consomationeau = {2};
    public static int lvl = 0;
    public static readonly int[] gain_xp = {10, 100, 500};

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

    public static string[] _image = {"res://assets/ImageSized/caserne.png"};
}