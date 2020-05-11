using Godot;
using System;
using SshCity.Scenes.Buildings;

public class Immeuble
{
    public static int[] _bloc = {11};
    public static int[] _cost = {4000};
    public static int[] _earn = {4,6,8};
    public static string[] _titre = {"Immeuble"};
    public static int lvl = 0;
    public static readonly int[] gain_xp = {10, 100, 500};
    public static string[] _image = {"res://assets/maison2.png"};
    public static int nbrAmeliorations = 0;
    public static Batiments.Class _class = Batiments.Class.IMMEUBLE;
    Caracteristiques.BatimentsCaracteristiques cara = new Caracteristiques.BatimentsCaracteristiques(nbrAmeliorations, _bloc, _cost, _earn, _titre, gain_xp, _image, _class);
}

