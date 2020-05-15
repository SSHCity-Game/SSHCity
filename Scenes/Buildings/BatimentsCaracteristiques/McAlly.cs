using Godot;
using System;
using SshCity.Scenes.Buildings;
using SshCity.Scenes.Plan;
using SshCity.Scenes.Buildings.BatimentsCaracteristiques;

public class McAlly
{
    public static int[] _bloc = {Ref_donnees.McAffy};
    public static int[] _cost = {1000};
    public static int[] _earn = {1,2,5};
    public static string[] _titre = {"McAlly"};
    public static int lvl = 0;
    public static readonly int[] gain_xp = {10, 100, 500};
    public static int[] _consomationelec = {1};
    public static string[] _image = {"res://assets/isometric magasin1.png"};
    public static int nbrAmeliorations = 0;
    public static Batiments.Class _class = Batiments.Class.MCALLY;
    public static Caracteristiques.BatimentsCaracteristiques cara = new Caracteristiques.BatimentsCaracteristiques(nbrAmeliorations, _bloc, _cost, _earn, _titre, gain_xp, _image, _class,_consomationelec);
}
