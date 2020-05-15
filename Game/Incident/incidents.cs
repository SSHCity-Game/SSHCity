using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Godot;
using SshCity.Game.Plan;

public class Incident : PlanInitial
{
	private const int XpIncident = 0;

	public static bool resoIncident = false;


	/* Permet l'utilisation des methodes non static dans methode static */
	private static Incident Instance { get; } = new Incident();
	private static menu_incident MenuIncident { get; } = new menu_incident();


	public override void _Ready()
	{
		TileMap1 = (TileMap) GetNode("TileMap1");
		TileMap2 = (TileMap) GetNode("TileMap2");
		TileMap3 = (TileMap) GetNode("TileMap3");
	}

	public static async void GenereIncidents(PlanInitial planInitial)
	{
		/******************************************
		 * Genere differents incidents sur la map *
		 ******************************************/

		var rand = new Random();
		int indexAv = Ref_donnees.maison3;
		int indexAp = Ref_donnees.maison3_flamme;
		List<Vector2> coordinates = new List<Vector2>(); // positions du bloc index_av
		int x, y;
		Vector2 pos;

		/* recherche des coordonnees du batiment voulut et ajout a la liste coordinates */
		foreach (var building in MainPlan.ListeBatiment)
		{
			(Vector2 coords, int bat) = building;
			if (bat == indexAv)
				coordinates.Add(coords);
		}

		int nbBloc = coordinates.Count - 1;
		pos = coordinates[rand.Next(0, nbBloc)]; // choisit la tuile aleatoirement
		x = (int) pos.x;
		y = (int) pos.y;

		//if (Interface.Xp >= XpIncident)
		//{
		await Task.Delay(5000);
		BuildingSwitch(planInitial, indexAv, indexAp, x, y);
		await Task.Delay(1000);
		menu_incident.AlerteIncendie = true;
		if (resoIncident)
		{
			BuildingSwitch(planInitial, indexAp, indexAv, x, y);
			resoIncident = false;
		}

		//}
	}

	public static void BuildingSwitch(PlanInitial planInitial, int indexAv, int indexAp, int x, int y)
	{
		/***************************************
		 * Change l'image d'un batiment *
		 ***************************************/

		/* Initialise le bloc en x,y, comme batiment en feu */
		if (planInitial.GetBlock(planInitial.TileMap2, x, y) == indexAv)
			planInitial.SetBlock(planInitial.TileMap2, x, y, indexAp);
	}
}
