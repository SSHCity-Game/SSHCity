using Godot;
using System;
using SshCity.Scenes.Plan;

public class McAllyNode : Node2D
{
    private Timer _mcAllyTimer;
    private static int[] _bloc = {Ref_donnees.McAffy};
    private static int[] _cost = {1000};
    private static int[] _earn = {1,2,5};
    private static string[] _titre = {"McAlly"};
    private static readonly int[] upgrade_cost = {15000, 20000};
    private static int lvl = 0;
    private static readonly int[] gain_xp = {10, 100, 500};
    private static string[] _image = {"res://assets/isometric magasin1.png"};

    public static int[] Bloc
    {
        get => _bloc;
        set => _bloc = value;
    }

    public static string[] Image => _image;
    public static int[] UpgradeCost => upgrade_cost;

    public static int[] GainXp => gain_xp;
    public static string[] Titre => _titre;

    public static int[] Cost => _cost;
    public static int[] EarnTableau => _earn;

    public static int Earn => _earn[lvl];

    private const string _str_mcAlly_timer = "Timer";
    public override void _Ready()
    {
        _mcAllyTimer = (Timer) GetNode(_str_mcAlly_timer);
        _mcAllyTimer.Start();
        _mcAllyTimer.Connect("timeout", this, nameof(TimeOut));
        Interface.Xp += gain_xp[lvl];
    }

    public void TimeOut()
    {
        Interface.Money += _earn[lvl];
    }
    
}
