using Godot;
using System;
using System.ComponentModel.Design;

public class MaisonNode : Timer
{
    private Timer _maisonTimer;
    private int _moneyWin = 1000;
    private static int _bloc = 5;
    private static int _cost = 1000;
    private static int _earn = 10;
    private static string _titre = "Maison";

    public static int Bloc
    {
        get => _bloc;
    }

    public static string Titre => _titre;

    public static int Cost => _cost;

    public static int Earn => _earn;

    private const string _str_maison_timer = "Timer";
    public enum BuildingType
    {
        None, MAISON, 
    }

    protected BuildingType type;
    public BuildingType Type
    {
        get { return type; }
    }
    public override void _Ready()
    {
        _maisonTimer = (Timer) GetNode(_str_maison_timer);
        _maisonTimer.Start();
        _maisonTimer.Connect("timeout", this, nameof(TimeOut));
    }

    public void TimeOut()
    {
        Interface.Money += _moneyWin;
    }
}
