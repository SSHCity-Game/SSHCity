using SshCity.Game.Buildings;
using SshCity.Game.Buildings.BatimentsCaracteristiques;
using SshCity.Game.Plan;

public class Hotel
{
    public static int[] _bloc = {Ref_donnees.hotel};
    public static int[] _cost = {2000};
    public static int[] _earn = {2, 6, 12};
    public static string[] _titre = {"Hotel"};
    public static int lvl = 0;
    public static readonly int[] gain_xp = {10, 100, 500};
    public static int[] _consomationelec = {2};
    public static int[] _consomationeau = {2};
    public static string[] _image = {"res://assets/ImageSized/hotel.png"};
    public static int nbrAmeliorations = 0;
    public static Batiments.Class _class = Batiments.Class.HOTEL;

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