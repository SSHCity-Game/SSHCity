using Godot;
using System;

public class ImmeubleNode : Node2D
{
    private Timer _immeubleTimer;
    private static int _bloc = 11;
    private static int _cost = 4000;
    private static int[] _earn = {40,50,60};
    private static string _titre = "Immeuble";
    private static readonly int[] upgrade_cost = {4500, 5000};
    private static int lvl = 0;

    public static int Bloc
    {
        get => _bloc;
        set => _bloc = value;
    }

    public static string Titre => _titre;

    public static int Cost => _cost;

    public static int Earn => _earn[lvl];

    private const string _str_immeuble_timer = "Timer";
    public override void _Ready()
    {
        _immeubleTimer = (Timer) GetNode(_str_immeuble_timer);
        _immeubleTimer.Start();
        _immeubleTimer.Connect("timeout", this, nameof(TimeOut));
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
        }
    }    
}

