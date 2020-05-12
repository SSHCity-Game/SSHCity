using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SshCity.Scenes.Plan;

public class Incident : PlanInitial
{
    private const int XpIncident = 0;

    public override void _Ready()
    {
        TileMap1 = (TileMap) GetNode("TileMap1");
        TileMap2 = (TileMap) GetNode("TileMap2");
        TileMap3 = (TileMap) GetNode("TileMap3");
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        GenereIncidents(MainPlan._planInitial);
    }

    /* Permet l'utilisation des methodes non static dans methode static */
    private static Incident Instance { get; } = new Incident();
    private static menu_incident MenuIncident { get; } = new menu_incident();

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
            BuildingOnFire(planInitial, indexAv, indexAp, x, y);
            await Task.Delay(1000); 
            menu_incident.AlerteIncendie();
            //PutOutFire(planInitial, indexAv, indexAp, x, y);
        //}
    }

     private static void BuildingOnFire(PlanInitial planInitial, int indexAv, int indexAp, int x, int y)
    {
        /***************************************
         * Genere un incendie dans un batiment *
         ***************************************/
        
        /* Initialise le bloc en x,y, comme batiment en feu */
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









