using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SshCity.Scenes.Plan;

public class Incident : PlanInitial
{
    /*
    private bool exist_accident;
    private bool exist_incident;
    private bool exist_fire;
    */
    private const int XP_incident = 90;
    private static Timer incident_timer;
    
    public override void _Ready()
    {
        TileMap1 = (TileMap) GetNode("TileMap1");
        TileMap2 = (TileMap) GetNode("TileMap2");
    }
    
    /*******************************************************************
    * Permet l'utilisation des methodes non static dans methode static *
     *******************************************************************/

    private static Incident Instance { get; } = new Incident();

    public static void HouseOnFire(PlanInitial planInitial, int index_av, int index_ap)
    {
        /**************************************
         * Genere un incendie dans une maison *
         **************************************/
        
        var rand = new Random();
        
        /* VARIABLES */
        int x, y; // position du bloc
        
        Vector2 coord;
        int bat;

        List<(int,int)> coordonnees = new List<(int,int)>(); // positions du bloc index_maison
        
        
        /* recherche des coordonnees du batiment voulut */
        foreach (var batiment in MainPlan.ListeBatiment)
        {
            (coord,bat) = batiment;
            if (bat == index_av)
                coordonnees.Add(((int) coord.x, (int) coord.y));
        }

        if (coordonnees != null)
        {
            int nb_bloc = coordonnees.Count;
            (x, y) = coordonnees[rand.Next(0, nb_bloc)];
            
            if(planInitial.GetBlock(planInitial.TileMap2, x, y) == index_av)
                planInitial.SetBlock(planInitial.TileMap2, x, y,index_ap); 
        }
        
    }

    
    public static async void GenereIncidents(PlanInitial planInitial)
    {
        if (Interface.Xp >= XP_incident)
        {
            await Task.Delay(5000);
            HouseOnFire(planInitial, 21, 57);
        }
    }

}









