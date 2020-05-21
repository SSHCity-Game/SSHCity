using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Godot;
using SshCity.Game.Plan;

public class incidents : CanvasLayer
{
	/* Maximum des incidents potentiels */
	public const int MAX_INCENDIES = 1;
	public const int MAX_ACCIDENT = 1;
	public const int MAX_NOYADES = 1;
	public const int MAX_BRACAGES = 1;
	/* Nombre actuel des incidents */
	public static int Nbincidents = 0;
	public static int Nbincendies = 0;
	public static int Nbaccident = 0;
	public static int Nbnoyades = 0;
	public static int Nbbracages = 0;
	/* definit si on peut resoudre un incident */	
	public static bool ResoIncident = false;
	public static bool ResoAccident = false;
	public static bool ResoBracage = false;
	public static bool ResoNoyade = false;
	/* batiment a changer par son batiment accidente */	
	private static int x;
	private static int y;
	private static int indexAv;
	private static int indexAp;
	/* niveau d apparition des differents incidents */	
	private static int levelIncendie = 2;
	private static int levelAccident = 5;
	private static int levelNoyade = 8;
	private static int levelBracage = 10;
	
	
	
	public override void _Process(float delta)
	{
		base._Process(delta);
		/* INCENDIES */
		if(Interface._level >= levelIncendie)
			GenerateIncendies(MainPlan._planInitial);
		if (menu_incident.TimerIncendie.IsStopped() && ResoIncident) // definit le temps entre l apparition de deux incendies
			ResoIncident = false;
		/* BRACAGES */
		if(Interface._level >= levelBracage)
			GenerateBracage(MainPlan._planInitial);
		if (menu_incident.TimerBracage.IsStopped() && ResoBracage) // definit le temps entre l apparition de deux bracage
			ResoBracage = false;
		/* NOYADES */		
		if(Interface._level >= levelNoyade)
			GenerateNoyade(MainPlan._planInitial);
		if (menu_incident.TimerNoyade.IsStopped() && ResoNoyade) // definit le temps entre l apparition de deux noyades
			ResoNoyade = false;
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
	
					/** INCENDIES **/
	public static void GenerateIncendies(PlanInitial planInitial)
	{
		if (ResoIncident && Nbincendies > 0)
		{
			StopIncendie(planInitial);
			Nbincendies--;
			Nbincidents--;
		}
		else if (!ResoIncident && Nbincendies < MAX_INCENDIES)
		{
			(x, y, indexAv, indexAp) = GenereCoords(Ref_donnees.BatimentFeu);
			StartIncendie(planInitial);
			Nbincendies++;
			Nbincidents++;
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
	
					/** ACCIDENTS **/
	public static void GenerateAccident(PlanInitial planInitial)
	{
		if (ResoAccident && Nbaccident > 0)
		{
			StopAccident(planInitial);
			Nbaccident--;
			Nbincidents--;
		}
		else if (Nbaccident < MAX_ACCIDENT && !ResoAccident)
		{
			StartAccident(planInitial);
			Nbaccident++;
			Nbincidents++;
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
	
					/** BRACAGES **/
	public static void GenerateBracage(PlanInitial planInitial)
	{
		(x, y, indexAv, indexAp) = GenereCoords(Ref_donnees.BatimentVol);
		if (ResoBracage && Nbbracages > 0)
		{
			StopBracage(planInitial);
			Nbbracages--;
			Nbincidents--;
		}
		else if (Nbbracages < MAX_BRACAGES && !ResoBracage)
		{
			StartBracage(planInitial);
			Nbbracages++;
			Nbincidents++;
		}
	}
	public static async void StartBracage(PlanInitial planInitial)
	{ /*fait apparaitre une image de braqueur devant la maison */
		await Task.Delay(5000);
		BuildingSwitch(planInitial, indexAv, indexAp, x, y);
		menu_incident.Bracage.Show();
	}
	public static async void StopBracage(PlanInitial planInitial)
	{ /* supprime le bracage */
		menu_incident.Bracage.Hide();
		await Task.Delay(3000);
		BuildingSwitch(planInitial, indexAp, indexAv, x, y);
	}
	
					/** NOYADES **/
	public static void GenerateNoyade(PlanInitial planInitial)
	{
		(x, y, indexAv, indexAp) = GenereCoords(Ref_donnees.LacNoyade);
		if (ResoNoyade && Nbnoyades > 0)
		{
			StopNoyade(planInitial);
			Nbnoyades--;
			Nbincidents--;
		}
		else if (Nbnoyades < MAX_NOYADES && !ResoNoyade)
		{
			StartNoyade(planInitial);
			Nbnoyades++;
			Nbincidents++;
		}
	}
	public static async void StartNoyade(PlanInitial planInitial)
	{ /* fait apparaitre une image de lac avec une personne qui se noie */
		await Task.Delay(5000);
		BuildingSwitch(planInitial, indexAv, indexAp, x, y);
		menu_incident.Noyade.Show();
	}
	public static async void StopNoyade(PlanInitial planInitial)
	{ /* revient au lac normal */
		menu_incident.Noyade.Hide();
		await Task.Delay(3000);
		BuildingSwitch(planInitial, indexAp, indexAv, x, y);
	}
	
	
	public static void BuildingSwitch(PlanInitial planInitial, int indexAv, int indexAp, int x, int y)
	{ /* Change l'image d'un batiment */
		/* Initialise le bloc en x,y, comme batiment accidente */
		if (planInitial.GetBlock(planInitial.TileMap2, x, y) == indexAv) 
			planInitial.SetBlock(planInitial.TileMap2, x, y, indexAp);
	}
}
