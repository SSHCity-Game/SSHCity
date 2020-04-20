using Godot;
using System;
using SshCity.Scenes.Plan;

public class Incidents : PlanInitial
{

    private bool exist_accident;
    private bool exist_incident;
    private bool exist_fire;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        TileMap1 = (TileMap) GetNode("TileMap1");
        TileMap2 = (TileMap) GetNode("TileMap2");
        
        var rand = new Random();

        /*index1 = TileMap1.GetCell(x,y);
        index2 = TileMap2.GetCell(x,y);
        if (!exist_fire && index1 != water && index1 != sand)
        {
            exist_incident = true;
            TileMap2.SetCell(x,y,fire);
        }
        
        x = rand.Next(min_x,max_x);
        y = rand.Next(min_y,max_y);
        index1 = TileMap1.GetCell(x,y);
        index2 = TileMap2.GetCell(x,y);
        if (!exist_accident && index1 == grass || index1 == street && index2 == -1 || index2 == house)
        {
            exist_accident = true;
            TileMap2.SetCell(x,y,accident);
        }
        x = rand.Next(min_x,max_x);
        y = rand.Next(min_y,max_y);
        index1 = TileMap1.GetCell(x,y);
        index2 = TileMap2.GetCell(x,y);
        if (!exist_incident)
        {
            exist_fire = true;
            TileMap2.SetCell(x,y,incident);
        }*/
		
    }

    public void HouseOnFire(int batiment)
    {
        /**************************************
         * Genere un incendie dans une maison *
         **************************************/
        Vector2 tile = GetTilePosition();
    }

}