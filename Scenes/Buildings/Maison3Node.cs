using Godot;
using System;
using SshCity.Scenes.Plan;

public class Maison3Node : Node2D
{
    private Timer _maison3Timer;
    private static int _bloc = Ref_donnees.maison3;
    private static int _cost = 1000;
    private static int[] _earn = {1,2,5};
    private static string _titre = "Maison3";
    private static readonly int[] upgrade_cost = {15000, 20000};
    private static int lvl = 0;

    public static int Bloc
    {
        get => _bloc;
        set => _bloc = value;
    }

    public static string Titre => _titre;

    public static int Cost => _cost;

    public static int Earn => _earn[lvl];

    private const string _str_maison3_timer = "Timer";
    public override void _Ready()
    {
        _maison3Timer = (Timer) GetNode(_str_maison3_timer);
        _maison3Timer.Start();
        _maison3Timer.Connect("timeout", this, nameof(TimeOut));
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
