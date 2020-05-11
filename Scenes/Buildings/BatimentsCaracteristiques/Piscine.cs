using Godot;
using System;
using SshCity.Scenes.Buildings;
using SshCity.Scenes.Plan;

public class Piscine
{
    public static int[] _bloc = {Ref_donnees.piscine};
    public static int[] _cost = {10000};
    public static int[] _earn = {20,30,50};
    public static string[] _titre = {"Piscine"};
    public static int lvl = 0;
    public static readonly int[] gain_xp = {10, 100, 500};
    public static string[] _image = {"res://assets/isometric piscine1.png"};
    public static int nbrAmeliorations = 0;
    public static Batiments.Class _class = Batiments.Class.PISCINE;
    Caracteristiques.BatimentsCaracteristiques cara = new Caracteristiques.BatimentsCaracteristiques(nbrAmeliorations, _bloc, _cost, _earn, _titre, gain_xp, _image, _class);
}
