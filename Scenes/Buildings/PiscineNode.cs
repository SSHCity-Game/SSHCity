using Godot;
using System;
using SshCity.Scenes.Plan;

public class PiscineNode : Node2D
{
    private Timer _piscineTimer;
    private static int _bloc = Ref_donnees.piscine;
    private static int _cost = 10000;
    private static int[] _earn = {20,30,50};
    private static string _titre = "Piscine";
    private static readonly int[] upgrade_cost = {15000, 20000};
    private static int lvl = 0;
    private static readonly int[] gain_xp = {10, 100, 500};
    private static string _image = "res://assets/isometric piscine1.png";

    public static int Bloc
    {
        get => _bloc;
        set => _bloc = value;
    }

    public static string Image => _image;

    public static string Titre => _titre;

    public static int Cost => _cost;

    public static int Earn => _earn[lvl];

    private const string _str_piscine_timer = "Timer";
    public override void _Ready()
    {
        _piscineTimer = (Timer) GetNode(_str_piscine_timer);
        _piscineTimer.Start();
        _piscineTimer.Connect("timeout", this, nameof(TimeOut));
        Interface.Xp += gain_xp[lvl];
    }

    public void TimeOut()
    {
        Interface.Money += _earn[lvl];
    }

    public void Upgrade()
    {
        if (lvl <2 && Interface.Money> upgrade_cost[lvl])
        {
            lvl += 1;
            Interface.Money -= upgrade_cost[lvl - 1];
            Bloc += 1;
            Interface.Xp += gain_xp[lvl - 1];
        }
    }    
}
