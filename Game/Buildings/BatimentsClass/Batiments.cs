using Godot;
using Godot.Collections;
using SshCity.Game.Buildings.BatimentsCaracteristiques;

namespace SshCity.Game.Buildings
{
	public partial class Batiments
	{
		public class Building
		{
			private int[] _bloc;
			private Class _class;
			private int[] _consomation_eau;
			private int[] _consomation_elec;
			private int[] _cost;
			private int[] _earn;
			private string[] _image;
			private Vector2 _position;
			private string[] _titre;
			private int[] gain_xp;
			private int lvl;
			private int nbrAmelioration;

			public Building(Class clazz, Vector2 position, int theLvl = 0)
			{
				var caracteristique = Caracteristiques.GiveCaracteristique(clazz);
				_position = position;
				_class = caracteristique._Class;
				_bloc = caracteristique.Bloc;
				_earn = caracteristique.Earn;
				_cost = caracteristique.Cost;
				_titre = caracteristique.Titre;
				GD.Print(_titre);
				gain_xp = caracteristique.GainXp;
				_image = caracteristique.Image;
				nbrAmelioration = caracteristique.NbrAmelioration;
				lvl = theLvl;
				ListBuildings.Add(this);
			}

			public int Lvl => lvl;
			public Vector2 Position => _position;

			public string[] Titre => _titre;

			public Class Class => _class;

			public int Bloc
			{
				get => _bloc[lvl];
			}

			public int[] EarnTab => _earn;
			public int AmeliorationCost => _cost[lvl + 1];
			public int NbrAmelioration => nbrAmelioration;


			public string Image => _image[lvl];
			public int Earn => _earn[lvl];

			public int[] ConsomationElec
			{
				get => _consomation_elec;
			}

			public int[] ConsomationEau
			{
				get => _consomation_eau;
			}

			public void Upgrade()
			{
				if (nbrAmelioration > lvl && lvl < 2 && Interface.Money >= _cost[lvl])
				{
					Interface.Money -= _cost[lvl];
					Interface.Xp += gain_xp[lvl];
					lvl += 1;
				}
			}

			public Dictionary<string, object> Save()
			{
				return new Dictionary<string, object>
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
