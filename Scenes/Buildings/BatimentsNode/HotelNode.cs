using Godot;
using System;
using SshCity.Scenes.Plan;

public class HotelNode : Node2D
{
    private Timer _hotelTimer;
    private static int[] _bloc = {Ref_donnees.hotel};
    private static int[] _cost = {2000};
    private static int[] _earn = {2,6,12};
    private static string[] _titre = {"Hotel"};
    private static readonly int[] upgrade_cost = {15000, 20000};
    private static int lvl = 0;
    private static readonly int[] gain_xp = {10, 100, 500};
    private static string[] _image = {"res://assets/hotel.png"};

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

    private const string _str_hotel_timer = "Timer";
    public override void _Ready()
    {
        _hotelTimer = (Timer) GetNode(_str_hotel_timer);
        _hotelTimer.Start();
        _hotelTimer.Connect("timeout", this, nameof(TimeOut));
        Interface.Xp += gain_xp[lvl];
    }

    public void TimeOut()
    {
        Interface.Money += _earn[lvl];
    }
}
