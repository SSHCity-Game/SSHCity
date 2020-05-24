using System;
using System.Collections.Generic;
using System.Configuration;
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
	private static int x, y;
	private static int xincendie;
	private static int yincendie;
	private static int indexAvincendie;
	private static int indexApincendie;
	private static int xaccident;
	private static int yaccident;
	private static int indexAvaccident;
	private static int indexApaccident;
	private static int xnoyade;
	private static int ynoyade;
	private static int indexAvnoyade;
	private static int indexApnoyade;
	private static int xbracage;
	private static int ybracage;
	private static int indexAvbracage;
	private static int indexApbracage;
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
		x = (int) pos.x;
		y = (int) pos.y;
		return (x, y, indexAv, indexAp);
	}
	
					/** INCENDIES **/
	public static void GenerateIncendies(PlanInitial planInitial)
	{
		if (ResoIncident && Nbincendies > 0)
		{
			Nbincendies--;
			Nbincidents--;
			StopIncendie(planInitial);
		}
		else if (!ResoIncident && Nbincendies < MAX_INCENDIES)
		{
			(xincendie, yincendie, indexAvincendie, indexApincendie) = GenereCoords(Ref_donnees.BatimentFeu);
			StartIncendie(planInitial);
			Nbincendies++;
			Nbincidents++;
		}
	}
	public static async void StartIncendie(PlanInitial planInitial)
	{ /* change le batiment normal avec celui accidente */
		await Task.Delay(5000);
		BuildingSwitch(planInitial, indexAvincendie, indexApincendie, xincendie, yincendie);
		menu_incident.Flamme.Show();
	}
	public static async void StopIncendie(PlanInitial planInitial)
	{ /* revient au batiment normal */
		
		menu_incident.Flamme.Hide();
		await Task.Delay(3000);
		BuildingSwitch(planInitial, indexApincendie, indexAvincendie, xincendie, yincendie);
	}
	
					/** ACCIDENTS **/
	public static void GenerateAccident(PlanInitial planInitial)
	{
		if (ResoAccident && Nbaccident > 0)
		{
			Nbaccident--;
			Nbincidents--;
			StopAccident(planInitial);
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
		if (ResoBracage && Nbbracages > 0)
		{
			Nbbracages--;
			Nbincidents--;
			StopBracage(planInitial);
		}
		else if (Nbbracages < MAX_BRACAGES && !ResoBracage)
		{
			(xbracage, ybracage, indexAvbracage, indexApbracage) = GenereCoords(Ref_donnees.BatimentVol);
			StartBracage(planInitial);
			Nbbracages++;
			Nbincidents++;
		}
	}
	public static async void StartBracage(PlanInitial planInitial)
	{ /*fait apparaitre une image de braqueur devant la maison */
		await Task.Delay(5000);
		BuildingSwitch(planInitial, indexAvbracage, indexApbracage, xbracage, ybracage);
		menu_incident.Bracage.Show();
	}
	public static async void StopBracage(PlanInitial planInitial)
	{ /* supprime le bracage */
		menu_incident.Bracage.Hide();
		await Task.Delay(3000);
		BuildingSwitch(planInitial, indexApbracage, indexAvbracage, xbracage, ybracage);
	}
	
					/** NOYADES **/
	public static async void GenerateNoyade(PlanInitial planInitial)
	{
		if (ResoNoyade && Nbnoyades > 0)
		{
			Nbnoyades--;
			Nbincidents--;
			menu_incident.Noyade.Hide();
			await Task.Delay(3000);
			Lacs.GenerateLacNoyade(planInitial, Ref_donnees.lac1, xnoyade, ynoyade);
		}
		else if (!ResoNoyade && Nbnoyades < MAX_NOYADES)
		{
			Random rand = new Random();
			(xnoyade, ynoyade) = Lacs.CoordsLac1[rand.Next(0, Lacs.CoordsLac1.Count - 1)];
			Nbnoyades++;
			Nbincidents++;
			await Task.Delay(5000);
			Lacs.GenerateLacNoyade(planInitial, Ref_donnees.lac1_noyade, xnoyade, ynoyade);
			menu_incident.Noyade.Show();
		}
	}

	public static void BuildingSwitch(PlanInitial planInitial, int indexAv, int indexAp, int x, int y)
	{ /* Change l'image d'un batiment */
		/* Initialise le bloc en x,y, comme batiment accidente */
		if (planInitial.GetBlock(planInitial.TileMap2, x, y) == indexAv) 
			planInitial.SetBlock(planInitial.TileMap2, x, y, indexAp);
	}
}
