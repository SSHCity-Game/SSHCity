using Godot;
using System;
using SshCity.Scenes.Plan;

public class RestaurantNode : Node2D
{
    private Timer _restaurantTimer;
    private static int _bloc = Ref_donnees.restaurant;
    private static int _cost = 5000;
    private static int[] _earn = {10,15,20};
    private static string _titre = "Restaurant";
    private static readonly int[] upgrade_cost = {15000, 20000};
    private static int lvl = 0;
    private static readonly int[] gain_xp = {10, 100, 500};
    private static string _image = "res://assets/isometric boutique5.png";

    public static int Bloc
    {
        get => _bloc;
        set => _bloc = value;
    }

    public static string Image => _image;
    public static string Titre => _titre;
    public static int[] UpgradeCost => upgrade_cost;

    public static int[] GainXp => gain_xp;
    public static int Cost => _cost;
    public static int[] EarnTableau => _earn;

    public static int Earn => _earn[lvl];

    private const string _str_restaurant_timer = "Timer";
    public override void _Ready()
    {
        _restaurantTimer = (Timer) GetNode(_str_restaurant_timer);
        _restaurantTimer.Start();
        _restaurantTimer.Connect("timeout", this, nameof(TimeOut));
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
