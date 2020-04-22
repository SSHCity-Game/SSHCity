using Godot;
using System;
using System.ComponentModel.Design;

public class MaisonNode : Node2D
{
    private Timer _maisonTimer;
    private static int _bloc = 11;
    private static int _cost = 1000;
    private static int[] _earn = {1,2,5};
    private static string _titre = "Maison";
    private static readonly int[] upgrade_cost = {1500, 2000};
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

    private const string _str_maison_timer = "Timer";
    public override void _Ready()
    {
        _maisonTimer = (Timer) GetNode(_str_maison_timer);
        _maisonTimer.Start();
        _maisonTimer.Connect("timeout", this, nameof(TimeOut));
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
