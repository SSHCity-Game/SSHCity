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
		public class Building : ISerializable
		{
			private int nbrAmelioration;
			private int[] _bloc;
			private int[] _cost;
			private int[] _earn;
			private string[] _titre;
			private int lvl;
			private int[] gain_xp;
			private string[] _image;
			private Class _class;
			private Vector2 _position;

			public Vector2 Position => _position;

			public Class Class => _class;

			public Building(Class clazz, Vector2 position, int theLvl = 0)
			{
				var car = Caracteristiques.GiveCaracteristique(clazz);

				_position = position;
				_class = clazz;
				_bloc = car.Bloc;
				_earn = car.Earn;
				_cost = car.Cost;
				_titre = car.Titre;
				gain_xp = car.GainXp;
				_image = car.Image;
				nbrAmelioration = car.NbrAmelioration;
				lvl = theLvl;
				ListBuildings.Add(this);
			}

			public int Bloc
			{
				get => _bloc[lvl];
			}

			public string Titre => _titre[lvl];

			public string Image => _image[lvl];
			public int Earn => _earn[lvl];


			public void Upgrade()
			{
				GD.Print(nbrAmelioration);
				if (nbrAmelioration > lvl && lvl < 2 && Interface.Money >= _cost[lvl])
				{
					Interface.Money -= _cost[lvl];
					Interface.Xp += gain_xp[lvl];
					lvl += 1;
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
