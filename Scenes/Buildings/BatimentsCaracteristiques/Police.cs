using Godot;
using System;
using SshCity.Scenes.Buildings;
using SshCity.Scenes.Plan;
using SshCity.Scenes.Buildings.BatimentsCaracteristiques;

public class Police
{
    public static int[] _bloc = {Ref_donnees.police};
    public static int[] _cost = {1000};
    public static int[] _earn = {1,2,5};
    public static string[] _titre = {"Police"};
    public static int lvl = 0;
    public static readonly int[] gain_xp = {10, 100, 500};
    public static int[] _consomationelec = {2};
    public static string[] _image = {"res://assets/police.png"};
    public static int nbrAmeliorations = 0;
    public static Batiments.Class _class = Batiments.Class.POLICE;
    Caracteristiques.BatimentsCaracteristiques cara = new Caracteristiques.BatimentsCaracteristiques(nbrAmeliorations, _bloc, _cost, _earn, _titre, gain_xp, _image, _class,_consomationelec);
}
