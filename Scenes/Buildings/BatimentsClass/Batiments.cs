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
            private int nbrAmelioration;
            private int[] _bloc;
            private  int[] _cost;
            private  int[] _earn;
            private  string[] _titre;
            private static int[] _upgrade_cost;
            private  int lvl;
            private  int[] gain_xp;
            private  string[] _image;
            private  Class _class;
            private  Vector2 _position;

            public Vector2 Position => _position;

            public  Class Class => _class;

            public Building(int[] bloc, int[] cost, int[] earn, string[] titre, int[]upgrade_cost, int[] gainXp, string[] image, Batiments.Class batimentClass, Vector2 position)
            {
                _position = position;
                _class = batimentClass;
                _bloc = bloc;
                _cost = cost;
                _titre = titre;
                _upgrade_cost = upgrade_cost;
                gain_xp = gainXp;
                _image = image;
                lvl = 0;
                ListBuildings.Add(this);
            }
            
            public  int Bloc
            {
                get => _bloc[lvl];
            }

            public  string Titre => _titre[lvl];

            public  int[] Cost => _cost;

            public  string Image => _image[lvl];
            public  int Earn => _earn[lvl];
            

            public void Upgrade()
            {
                if (lvl <2 && Interface.Money> _upgrade_cost[lvl])
                {
                    lvl += 1;
                    Interface.Money -= _upgrade_cost[lvl - 1];
                    Interface.Xp += gain_xp[lvl - 1];
                }
            }   
            
        }
    }
}