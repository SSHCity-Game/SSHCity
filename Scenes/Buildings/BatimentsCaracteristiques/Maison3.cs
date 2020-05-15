using Godot;
using System;
using SshCity.Scenes.Buildings;
using SshCity.Scenes.Plan;
using SshCity.Scenes.Buildings.BatimentsCaracteristiques;

public class Maison3
{
    public static int[] _bloc = {Ref_donnees.maison3, Ref_donnees.immeuble_brique};
    public static int[] _cost = {1000, 1500};
    public static int[] _earn = {1,2,5};
    public static string[] _titre = {"Maison3", "Immeuble"};
    public static readonly int[] gain_xp = {10, 100, 500};
    public static int[] _consomationelec = {1};
    public static int[] _consomationeau = {1};
    public static string[] _image = {"res://assets/maison3.png", "res://assets/maison2.png"};
    public static int nbrAmeliorations = 1;
    public static Batiments.Class _class = Batiments.Class.MAISON3;
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
