using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SshCity.Scenes.Plan;

public class Incident : PlanInitial
{
    private const int XpIncident = 80;

    public override void _Ready()
    {
        TileMap1 = (TileMap) GetNode("TileMap1");
        TileMap2 = (TileMap) GetNode("TileMap2");
        TileMap3 = (TileMap) GetNode("TileMap3");
    }

    /* Permet l'utilisation des methodes non static dans methode static */
     public static Incident Instance { get; } = new Incident();
     

     public static async void GenereIncidents(PlanInitial planInitial)
    {
        /******************************************
         * Genere differents incidents sur la map *
         ******************************************/
        
        var rand = new Random();
        int indexAv = Ref_donnees.maison3;
        int indexAp = Ref_donnees.maison3_flamme;
        List<(int,int)> coordinates = new List<(int,int)>(); // positions du bloc index_av
        int x, y;
        
        /* recherche des coordonnees du batiment voulut et ajout a la liste coordinates */
        foreach (var building in MainPlan.ListeBatiment)
        {
            (Vector2 coords, int bat) = building;
            if (bat == indexAv)
                coordinates.Add(((int) coords.x, (int) coords.y));
        }

        int nbBloc = coordinates.Count;
        (x, y) = coordinates[rand.Next(0, nbBloc)]; // choisit la tuile aleatoirement
        Vector2 pos;
        pos.x = x;
        pos.y = y;

        if (Interface.Xp >= XpIncident)
        {
            await Task.Delay(5000);
            BuildingOnFire(planInitial, indexAv, indexAp, x, y);
            await Task.Delay(1000); 
            alertes.AlerteIncendie(pos);
            //PutOutFire(planInitial, indexAv, indexAp, x, y);
        }
    }
    
    public static async void BuildingOnFire(PlanInitial planInitial, int indexAv, int indexAp, int x, int y)
    {
        /***************************************
         * Genere un incendie dans un batiment *
         ***************************************/

        int alerte = Ref_donnees.alerte_incendie;
       
        /* Initialise le bloc en x,y, s'il existe, comme batiment en feu */
        if (planInitial.GetBlock(planInitial.TileMap2, x, y) == indexAv)
            planInitial.SetBlock(planInitial.TileMap2, x, y, indexAp);
    }

    public static void PutOutFire(PlanInitial planInitial, int indexAv, int indexAp, int x, int y)
    {
        /*************************************
         * Eteint l'incendie dans un batiment *
         *************************************/

        Vector2 mousePosition = Instance.GetViewport().GetMousePosition();
        (int xMouse, int yMouse) = ((int) mousePosition.x, (int) mousePosition.y);
        if (xMouse >= x - 10 && xMouse <= x + 10 && yMouse >= y - 10 && yMouse <= y + 10)
            planInitial.SetBlock(planInitial.TileMap2, x, y, indexAv);
    }
}









