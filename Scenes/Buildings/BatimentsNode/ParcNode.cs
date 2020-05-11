using Godot;
using System;
using SshCity.Scenes.Plan;

public class ParcNode : Node2D
{
    private Timer _parcTimer;
    private static int[] _bloc = {Ref_donnees.parc_enfant};
    private static int[] _cost = {100};
    private static int[] _earn = {1,1,1};
    private static string[] _titre = {"Parc"};
    private static readonly int[] upgrade_cost = {15000, 20000};
    private static int lvl = 0;
    private static readonly int[] gain_xp = {10, 100, 500};
    private static string[] _image = {"res://assets/iso parc enfant4.png"};

    public static int[] Bloc
    {
        get => _bloc;
        set => _bloc = value;
    }

    public static string[] Image => _image;
    public static int[] UpgradeCost => upgrade_cost;

    public static int[] GainXp => gain_xp;
    public static string[] Titre => _titre;
    public static int[] EarnTableau => _earn;

    public static int[] Cost => _cost;

    public static int Earn => _earn[lvl];

    private const string _str_parc_timer = "Timer";
    public override void _Ready()
    {
        _parcTimer = (Timer) GetNode(_str_parc_timer);
        _parcTimer.Start();
        _parcTimer.Connect("timeout", this, nameof(TimeOut));
        Interface.Xp += gain_xp[lvl];
    }

    public void TimeOut()
    {
        Interface.Money += _earn[lvl];
    }
}
