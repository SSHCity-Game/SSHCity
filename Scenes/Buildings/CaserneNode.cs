using Godot;
using System;

public class CaserneNode : Node2D
{
    private Timer _caserneTimer;
    private static int _bloc = 11;
    private static int _cost = 1000;
    private static int[] _earn = {10,15,20};
    private static string _titre = "Caserne";
    private static readonly int[] upgrade_cost = {1500, 2000};
    private static int lvl = 0;

    public static int Bloc
    {
        get => _bloc;
        set => _bloc = value;
    }

    public static string Titre => _titre;

    public static int Cost => _cost;

    public static int Earn => _earn[lvl];

    private const string _str_caserne_timer = "Timer";
    public override void _Ready()
    {
        _caserneTimer = (Timer) GetNode(_str_caserne_timer);
        _caserneTimer.Start();
        _caserneTimer.Connect("timeout", this, nameof(TimeOut));
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
