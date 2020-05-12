using Godot;
using System;
using System.Collections.Concurrent;
using SshCity.Scenes.Buildings;
using SshCity.Scenes.Buildings.BatimentsCaracteristiques;
using SshCity.Scenes.Plan;

public partial class PlanInitial
{
    public bool AlreadySomethingHere(Vector2 tile)
    {
        (int largeur, int longueur) dimensions = (1, 1);
        bool somehtingHere = false;
        try
        {
            dimensions = Ref_donnees.dimensions[_batiment];
        }
        catch (Exception)
        {
            
        }
        int i = 1;
        while (!somehtingHere && i < dimensions.longueur +1)
        {
            int j = 1;
            while (!somehtingHere && j < dimensions.largeur+1)
            {
                somehtingHere =  GetBlock(TileMap1, (int) tile.x+i, (int) tile.y+j) == Ref_donnees.route
                                 || GetBlock(TileMap1, (int) tile.x+i, (int) tile.y+j) == Ref_donnees.montagne_sol
                                 || GetBlock(TileMap1, (int) tile.x+i, (int) tile.y+j) == Ref_donnees.sable
                                 || GetBlock(TileMap1, (int) tile.x+i, (int) tile.y+j) == Ref_donnees.eau;
                j++;
            }

            i++;
        }

        return somehtingHere;
    }

    public void SetAchatBlocs(Vector2 tile)
    {
        (int largeur, int longueur) dimensions = (1, 1);
        bool somehtingHere = false;
        try
        {
            dimensions = Ref_donnees.dimensions[_batiment];
        }
        catch (Exception)
        {
            
        }
        int i = 1;
        while (!somehtingHere && i < dimensions.longueur +1)
        {
            int j = 1;
            while (!somehtingHere && j < dimensions.largeur+1)
            {
                SetBlock(TileMap1, (int)tile.x+i, (int)tile.y+j, Ref_donnees.route);
                j++;
            }

            i++;
        }
    }
    
    
    public static void AchatRoute(bool start)
    {
        if (start)
        {
            _batiment = Ref_donnees.route_left;
            _prix = 50;
            _achatRoute = true;
        }
        else
        {
            _batiment = -1;
            _prix = 0;
            _achatRoute = false;
            _pressed = true;
        }
    }
    public void AjoutNode(int batiment, Vector2 tile)
    {

        if (Interface.Money-_prix >=0 )
        {
            Interface.Money -= _prix;
        }

        Batiments.Class batimentClass = DictionnaireCaracteristiques.dictionnaireCaracteristiques[batiment];
        new Batiments.Building(batimentClass, tile);
    }
}
