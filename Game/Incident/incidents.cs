using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Godot;
using SshCity.Game.Plan;

public class incidents : CanvasLayer
{
	/* Maximum des incidents potentiels */
	public const int MAX_INCIDENTS = 8;
	public const int MAX_INCENDIES = 2;
	public const int MAX_ACCIDENT = 1;
	public const int MAX_NOYADES = 2;
	public const int MAX_BRACAGES = 2;
	/* Nombre actuel des incidents */
	public static int Nbincidents = 0;
	public static int Nbincendies = 0;
	public static int Nbaccident = 0;
	public static int Nbnoyades = 0;
	public static int Nbbracages = 0;
	
	public static bool ResoIncident = false;
	public static bool ResoAccident = false;

	private static int x;
	private static int y;
	private static int indexAv;
	private static int indexAp;

	
	public override void _Process(float delta)
	{
		base._Process(delta);
		
		/* INCENDIES */
		GenerateIncendies(MainPlan._planInitial);

		Nbincidents = Nbincendies + Nbaccident + Nbnoyades + Nbbracages;
	}

	public static (int x, int y, int indexAv, int indexAp) GenereCoords((int, int)[] listBat)
	{ /* Genere aleatoirement les coordonnees d un batiement a accidente */

		var rand = new Random();
		var coordinates = new List<Vector2>(); // Liste de stockage des coordonnees de l incident
		var nbBat = listBat.Length - 1;
		int nbBloc;
		int indexAv, indexAp;
		
		/* Ajoute a la liste toutes les positions du batiment a incendier */
		do {
			(indexAv, indexAp) = listBat[rand.Next(0, nbBat)]; // choix aleatoire du batiment parmit les possibilites
			
			foreach (var building in MainPlan.ListeBatiment)
			{
				(Vector2 coords, int bat) = building;
				if (bat == indexAv)
					coordinates.Add(coords);
			}
			nbBloc = coordinates.Count - 1;
		} while (nbBloc < 0); // verifie que le batiment existe et recommence s'il n'existe pas
		
		var pos = coordinates[rand.Next(0, nbBloc)]; // choisit aleatoirement un batiment parmit tous les batiments de meme type
		var x = (int) pos.x;
		var y = (int) pos.y;
		return (x, y, indexAv, indexAp);
	}

	public static void GenerateIncendies(PlanInitial planInitial)
	{
		(x, y, indexAv, indexAp) = GenereCoords(Ref_donnees.BatimentFeu);
		if (ResoIncident)
		{
			StopIncendie(MainPlan._planInitial);
			Nbincendies--;
		}
		else if (Nbincidents < MAX_INCIDENTS && Nbincendies < MAX_INCENDIES && !ResoIncident)
		{
			StartIncendie(MainPlan._planInitial);
			Nbincendies++;
		}
	}
	public static async void StartIncendie(PlanInitial planInitial)
	{ /* change le batiment normal avec celui accidente */
		await Task.Delay(5000);
		BuildingSwitch(planInitial, indexAv, indexAp, x, y);
		menu_incident.Flamme.Show();
	}
	
	public static async void StopIncendie(PlanInitial planInitial)
	{ /* revient au batiment normal */
		menu_incident.Flamme.Hide();
		await Task.Delay(3000);
		BuildingSwitch(planInitial, indexAp, indexAv, x, y);
	}
	
	public static void GenerateAccident(PlanInitial planInitial)
	{
		if (ResoAccident)
		{
			StopAccident(MainPlan._planInitial);
			Nbaccident--;
		}
		else if (Nbincidents < MAX_INCIDENTS && Nbaccident < MAX_INCENDIES && !ResoAccident)
		{
			StartAccident(MainPlan._planInitial);
			Nbaccident++;
		}
	}
	public static async void StartAccident(PlanInitial planInitial)
	{ /* fait apparaitre une image d'accident sur la route */
		menu_incident.Accident.Show();
	}
	
	public static async void StopAccident(PlanInitial planInitial)
	{ /* supprime l'accident */
		menu_incident.Accident.Hide();
	}
	
	public static void BuildingSwitch(PlanInitial planInitial, int indexAv, int indexAp, int x, int y)
	{ /* Change l'image d'un batiment */
		/* Initialise le bloc en x,y, comme batiment accidente */
		if (planInitial.GetBlock(planInitial.TileMap2, x, y) == indexAv) 
			planInitial.SetBlock(planInitial.TileMap2, x, y, indexAp);
	}
}
