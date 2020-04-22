using Godot;
using System;

public class HospitalNode : Node2D
{
    private Timer _hospitalTimer;
    private static int _bloc = 15;
    private static int _cost = 10000;
    private static int[] _earn = {120,170,250};
    private static string _titre = "Hôpital";
    private static readonly int[] upgrade_cost = {15000, 20000};
    private static int lvl = 0;
    private static readonly int[] gain_xp = {10, 100, 500};

    public static int Bloc
    {
        get => _bloc;
        set => _bloc = value;
    }

    public static string Titre => _titre;

    public static int Cost => _cost;

    public static int Earn => _earn[lvl];

    private const string _str_hospital_timer = "Timer";
    public override void _Ready()
    {
        _hospitalTimer = (Timer) GetNode(_str_hospital_timer);
        _hospitalTimer.Start();
        _hospitalTimer.Connect("timeout", this, nameof(TimeOut));
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

