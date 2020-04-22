using Godot;
using System;
using SshCity.Scenes.Plan;

public class Maison5Node : Node2D
{
    private Timer _maison5Timer;
    private static int _bloc = Ref_donnees.maison5;
    private static int _cost = 1000;
    private static int[] _earn = {1,2,5};
    private static string _titre = "Maison5";
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

    private const string _str_maison5_timer = "Timer";
    public override void _Ready()
    {
        _maison5Timer = (Timer) GetNode(_str_maison5_timer);
        _maison5Timer.Start();
        _maison5Timer.Connect("timeout", this, nameof(TimeOut));
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
