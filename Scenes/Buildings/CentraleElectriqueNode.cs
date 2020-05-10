using Godot;
using System;
using SshCity.Scenes.Plan;

public class CentraleElectriqueNode : Node2D
{
    private Timer _centraleTimer;
    private static int _bloc = Ref_donnees.centrale;
    private static int _cost = 3000;
    private static int[] _earn = {2,5,8};
    private static string _titre = "centrale electrique";
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

    private const string _str_centrale_timer = "Timer";
    public override void _Ready()
    {
        _centraleTimer = (Timer) GetNode(_str_centrale_timer);
        _centraleTimer.Start();
        _centraleTimer.Connect("timeout", this, nameof(TimeOut));
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