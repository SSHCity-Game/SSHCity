using Godot;
using System;
using System.Collections.Generic;
using SshCity.Scenes.Plan;

public class Incident : PlanInitial
{
    /*
    private bool exist_accident;
    private bool exist_incident;
    private bool exist_fire;
    */
    
    public override void _Ready()
    {
        TileMap1 = (TileMap) GetNode("TileMap1");
        TileMap2 = (TileMap) GetNode("TileMap2");
    }
    
    public static void HouseOnFire(PlanInitial planInitial)
    {
        /**************************************
         * Genere un incendie dans une maison *
         **************************************/
        
        var rand = new Random();
        
        /* VARIABLES */
        int x, y; // position du bloc
        
        Vector2 coord;
        int bat;
        
        int index_maison = 21; // indexe du bloc avant incident
        int index_maison_in = 57; // indexe du bloc apres incident
        
        List<(int,int)> coordonnees = new List<(int,int)>(); // positions du bloc index_maison
        
        
        /* recherche des coordonnees du batiment voulut */
        foreach (var batiment in MainPlan.ListeBatiment)
        {
            (coord,bat) = batiment;
            if (bat == index_maison)
                coordonnees.Add(((int) coord.x, (int) coord.y));
        }

        if (coordonnees != null)
        {
            int nb_bloc = coordonnees.Count;
            (x, y) = coordonnees[rand.Next(0, nb_bloc)];
            
            if(planInitial.GetBlock(planInitial.TileMap2, x, y) == index_maison)
                planInitial.SetBlock(planInitial.TileMap2, x, y,index_maison_in); 
        }
        
    }

}









