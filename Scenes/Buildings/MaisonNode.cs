using Godot;
using System;
using System.ComponentModel.Design;

public class MaisonNode : Timer
{
    //private Timer _maisonTimer;
    //private int _moneyWin = 1000;

   // private const string _str_maison_timer = "Timer";
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
      //  _maisonTimer = (Timer) GetNode(_str_maison_timer);
      //  _maisonTimer.Start();
      //  _maisonTimer.Connect("timeout", this, nameof(TimeOut));
    }

    public void TimeOut()
    {
       // Interface.Money += _moneyWin;
    }
}
