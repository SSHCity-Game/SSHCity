using Godot;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using SshCity.Scenes.Buildings.BatimentsCaracteristiques;
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
            private  int lvl;
            private  int[] gain_xp;
            private  string[] _image;
            private  Class _class;
            private  Vector2 _position;
            private int[] _consomation_elec;

            public Vector2 Position => _position;

            public  Class Class => _class;

            public Building(Class batimentClass, Vector2 position)
            {
                Caracteristiques.BatimentsCaracteristiques caracteristique = Caracteristiques.GiveCaracteristique(batimentClass);
                
                _position = position;
                _class = batimentClass;
                _bloc = caracteristique.Bloc;
                _earn = caracteristique.Earn;
                _cost = caracteristique.Cost;
                _titre = caracteristique.Titre;
                gain_xp = caracteristique.GainXp;
                _image = caracteristique.Image;
                nbrAmelioration = caracteristique.NbrAmelioration;
                _consomation_elec = caracteristique.ConsomationElec;
                lvl = 0;
                ListBuildings.Add(this);
            }
            
            public  int Bloc
            {
                get => _bloc[lvl];
            }

            public  string Titre => _titre[lvl];

            public  string Image => _image[lvl];
            public  int Earn => _earn[lvl];

            public int[] ConsomationElec
            {
                get => _consomation_elec;
            }


            public void Upgrade()
            {
                GD.Print(nbrAmelioration);
                if (nbrAmelioration > lvl && lvl <2 && Interface.Money>= _cost[lvl])
                {
                    Interface.Money -= _cost[lvl];
                    Interface.Xp += gain_xp[lvl];
                    lvl += 1;
                }
                GD.Print(lvl);
            }
        }
    }
}