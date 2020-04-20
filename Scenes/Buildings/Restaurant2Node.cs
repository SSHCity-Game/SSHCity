using Godot;
using System;
using SshCity.Scenes.Plan;

public class Restaurant22 : Node2D
{
   private Timer _restaurant2Timer;
       private static int _bloc = Ref_donnees.restaurant2;
       private static int _cost = 10000;
       private static int[] _earn = {100,150,200};
       private static string _titre = "Restaurant2";
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
   
       private const string _str_restaurant2_timer = "Timer";
       public override void _Ready()
       {
           _restaurant2Timer = (Timer) GetNode(_str_restaurant2_timer);
           _restaurant2Timer.Start();
           _restaurant2Timer.Connect("timeout", this, nameof(TimeOut));
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
