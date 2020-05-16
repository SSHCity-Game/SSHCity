using SshCity.Game.Buildings;
using SshCity.Game.Buildings.BatimentsCaracteristiques;
using SshCity.Game.Plan;

public class CentraleElectrique
{
    public static int[] _bloc = {Ref_donnees.centrale};
    public static int[] _cost = {3000};
    public static int[] _earn = {2, 5, 8};
    public static string[] _titre = {"centrale electrique"};
    public static int lvl = 0;
    public static readonly int[] gain_xp = {10, 100, 500};
    public static int[] _consomationelec = {0};
    public static int[] _consomationeau = {3};
    public static string[] _image = {"res://assets/ImageSized/isometric centrale1.png"};
    public static int nbrAmeliorations = 0;
    public static BuildingType _class = BuildingType.CENTRALE;

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