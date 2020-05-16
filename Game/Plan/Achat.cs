using System;
using Godot;
using SshCity.Game.Buildings;
using SshCity.Game.Plan;

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
        while (!somehtingHere && i < dimensions.longueur + 1)
        {
            int j = 1;
            while (!somehtingHere && j < dimensions.largeur + 1)
            {
                somehtingHere = GetBlock(TileMap1, (int) tile.x + i, (int) tile.y + j) == Ref_donnees.route
                                || GetBlock(TileMap1, (int) tile.x + i, (int) tile.y + j) == Ref_donnees.montagne_sol
                                || GetBlock(TileMap1, (int) tile.x + i, (int) tile.y + j) == Ref_donnees.sable
                                || GetBlock(TileMap1, (int) tile.x + i, (int) tile.y + j) == Ref_donnees.eau;
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
        while (!somehtingHere && i < dimensions.longueur + 1)
        {
            int j = 1;
            while (!somehtingHere && j < dimensions.largeur + 1)
            {
                SetBlock(TileMap1, (int) tile.x + i, (int) tile.y + j, Ref_donnees.route);
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
            Prix = 50;
            _achatRoute = true;
        }
        else
        {
            _batiment = -1;
            Prix = 0;
            _achatRoute = false;
            _pressed = true;
        }
    }

    public void AjoutNode(int batiment, Vector2 tile)
    {
        if (Interface.Money - Prix >= 0)
        {
            Interface.Money -= Prix;
        }

        var batimentClass = (BuildingType) batiment;
        new Batiments.Building(batimentClass, tile);
    }
}