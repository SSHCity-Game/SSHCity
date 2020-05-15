using Godot;
using System;
using SshCity.Scenes.Buildings;
using SshCity.Scenes.Plan;
using SshCity.Scenes.Buildings.BatimentsCaracteristiques;

public class Maison5
{
    public static int[] _bloc = {Ref_donnees.maison5};
    public static int[] _cost = {1000};
    public static int[] _earn = {1,2,5};
    public static string[] _titre = {"Maison5"}; 
    public static int lvl = 0;
    public static readonly int[] gain_xp = {10, 100, 500};
    public static int[] _consomationelec = {1};
    public static string[] _image = {"res://assets/maison5.png"};
    public static int nbrAmeliorations = 0;
    public static Batiments.Class _class = Batiments.Class.MAISON5;
    public static Caracteristiques.BatimentsCaracteristiques cara = new Caracteristiques.BatimentsCaracteristiques(nbrAmeliorations, _bloc, _cost, _earn, _titre, gain_xp, _image, _class,_consomationelec);
}
