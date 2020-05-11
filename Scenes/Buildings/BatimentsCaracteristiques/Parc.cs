using Godot;
using System;
using SshCity.Scenes.Buildings;
using SshCity.Scenes.Plan;
using SshCity.Scenes.Buildings.BatimentsCaracteristiques;

public class Parc
{
    public static int[] _bloc = {Ref_donnees.parc_enfant};
    public static int[] _cost = {100};
    public static int[] _earn = {1,1,1};
    public static string[] _titre = {"Parc"};
    public static int lvl = 0;
    public static readonly int[] gain_xp = {10, 100, 500};
    public static string[] _image = {"res://assets/iso parc enfant4.png"};
    public static int nbrAmeliorations = 0;
    public static Batiments.Class _class = Batiments.Class.PARC;
    public static Caracteristiques.BatimentsCaracteristiques cara = new Caracteristiques.BatimentsCaracteristiques(nbrAmeliorations, _bloc, _cost, _earn, _titre, gain_xp, _image, _class);
}
