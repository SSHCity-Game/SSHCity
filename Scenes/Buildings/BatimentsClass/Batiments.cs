using Godot;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using SshCity.Scenes.Buildings.BatimentsCaracteristiques;
using SshCity.Scenes.Plan;
using SshCity.Scenes.Sauvegarde;

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
            private int[] _consomation_eau;

			public Vector2 Position => _position;

			public Class Class => _class;

			public Building(Class clazz, Vector2 position, int theLvl = 0)
			{
           var caracteristique = Caracteristiques.GiveCaracteristique(clazz);
             
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
                _consomation_eau = caracteristique.ConsomationEau;
                lvl = 0;
                ListBuildings.Add(this);
            }
            
			public int Bloc
			{
				get => _bloc[lvl];
			}
      
      public  string Image => _image[lvl];
      public  int Earn => _earn[lvl];
      public int[] EarnTab => _earn;
      public int AmeliorationCost => _cost[lvl + 1];
      public int NbrAmelioration => nbrAmelioration;


            public  string Image => _image[lvl];
            public  int Earn => _earn[lvl];

            public int[] ConsomationElec
            {
                get => _consomation_elec;
            }
            public int[] ConsomationEau
            {
                get => _consomation_eau;
            }

				GD.Print(lvl);
			}
      
			public Godot.Collections.Dictionary<string, object> Save()
			{
				return new Godot.Collections.Dictionary<string, object>
				{
					{"PosX", Position.x},
					{"PosY", Position.y},
					{"Class", Class},
					{"Level", lvl}
				};
			}
		}
	}
}
