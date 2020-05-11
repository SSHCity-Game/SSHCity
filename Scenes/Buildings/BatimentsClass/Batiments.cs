using Godot;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using SshCity.Scenes.Plan;

namespace SshCity.Scenes.Buildings
{
    public partial class Batiments
    {
        public class Building
        {
            private static int _bloc;
            private static int _cost;
            private static int[] _earn;
            private static string _titre;
            private static int[] upgrade_cost;
            private static int lvl;
            private static int[] gain_xp;
            private static string _image;
            private static Class _class;
            private  Vector2 _position;

            public Vector2 Position => _position;

            public static Class Class => _class;

            public Building(int bloc, int cost, int[] earn, string titre, int[]upgrade_cost, int[] gainXp, string image, Batiments.Class batimentClass, Vector2 position)
            {
                _position = position;
                _class = batimentClass;
                _bloc = bloc;
                _cost = cost;
                _titre = titre;
                Building.upgrade_cost = upgrade_cost;
                gain_xp = gainXp;
                _image = image;
                lvl = 0;
                ListBuildings.Add(this);
            }
            
            public static int Bloc
            {
                get => _bloc;
                set => _bloc = value;
            }

            public static string Titre => _titre;

            public static int Cost => _cost;

            public static string Image => _image;
            public static int Earn => _earn[lvl];
            

            public void Upgrade()
            {
                if (lvl <2 && Interface.Money> upgrade_cost[lvl])
                {
                    lvl += 1;
                    Interface.Money -= upgrade_cost[lvl - 1];
                    Interface.Xp += gain_xp[lvl - 1];
                }
            }   
        }
    }
}