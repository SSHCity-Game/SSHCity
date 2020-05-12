using Godot;
using System;
using SshCity.Scenes.Buildings;
using SshCity.Scenes.Buildings.BatimentsCaracteristiques;

public class Hospital
{
    public static int[] _bloc = {15};
    public static int[] _cost = {10000};
    public static int[] _earn = {15,30,50};
    public static string[] _titre = {"Hôpital"};
    public static int lvl = 0;
    public static readonly int[] gain_xp = {10, 100, 500};
    public static string[] _image = {"res://assets/ImageSized/hopital.png"};
    public static int nbrAmeliorations = 0;
    public static Batiments.Class _class = Batiments.Class.HOSPITAL;
    public static Caracteristiques.BatimentsCaracteristiques cara = new Caracteristiques.BatimentsCaracteristiques(nbrAmeliorations, _bloc, _cost, _earn, _titre, gain_xp, _image, _class);
}

