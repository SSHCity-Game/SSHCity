using Godot;
using System;
using SshCity.Scenes.Plan;

public class Maison5Node : Node2D
{
    private Timer _maison5Timer;
    private static int[] _bloc = {Ref_donnees.maison5};
    private static int[] _cost = {1000};
    private static int[] _earn = {1,2,5};
    private static string[] _titre = {"Maison5"};
    private static readonly int[] upgrade_cost = {15000, 20000};
    private static int lvl = 0;
    private static readonly int[] gain_xp = {10, 100, 500};
    private static string[] _image = {"res://assets/maison5.png"};

    public static int[] Bloc
    {
        get => _bloc;
        set => _bloc = value;
    }

    public static string[] Image => _image;
    public static string[] Titre => _titre;
    public static int[] UpgradeCost => upgrade_cost;

    public static int[] GainXp => gain_xp;
    public static int[] Cost => _cost;
    public static int[] EarnTableau => _earn;

    public static int Earn => _earn[lvl];

    private const string _str_maison5_timer = "Timer";
    public override void _Ready()
    {
        _maison5Timer = (Timer) GetNode(_str_maison5_timer);
        _maison5Timer.Start();
        _maison5Timer.Connect("timeout", this, nameof(TimeOut));
        Interface.Xp += gain_xp[lvl];
    }

    public void TimeOut()
    {
        Interface.Money += _earn[lvl];
    }
  
}
