using Godot;
using System;
using SshCity.Scenes.Plan;

public class CafeNode : Node2D
{
    private Timer _cafeTimer;
    private static int[] _bloc = {
        Ref_donnees.cafe
    };
    private static int[] _cost = {1000};
    private static int[] _earn = {1,2,5};
    private static string[] _titre = {"Cafe"};
    private static readonly int[] upgrade_cost = {15000, 20000};
    private static int lvl = 0;
    private static readonly int[] gain_xp = {10, 100, 500};
    private static string[] _image = {"res://assets/isometric magasin6.png"};

    public static int[] UpgradeCost => upgrade_cost;

    public static int[] GainXp => gain_xp;

    public static int[] Bloc
    {
        get => _bloc;
        set => _bloc = value;
    }

    public static string[] Titre => _titre;

    public static int[] Cost => _cost;

    public static string[] Image => _image;
    public static int Earn => _earn[lvl];
    public static int[] EarnTableau => _earn;

    private const string _str_cafe_timer = "Timer";
    public override void _Ready()
    {
        _cafeTimer = (Timer) GetNode(_str_cafe_timer);
        _cafeTimer.Start();
        _cafeTimer.Connect("timeout", this, nameof(TimeOut));
        Interface.Xp += gain_xp[lvl];
    }

    public void TimeOut()
    {
        Interface.Money += _earn[lvl];
    }
}
