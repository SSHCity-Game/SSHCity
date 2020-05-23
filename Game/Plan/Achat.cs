using System;
using System.Collections.Generic;
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
                                || GetBlock(TileMap1, (int) tile.x + i, (int) tile.y + j) == Ref_donnees.eau
                                || GetBlock(TileMap1, (int) tile.x + i, (int) tile.y + j) == Ref_donnees.water_terre
                                || GetBlock(TileMap1, (int) tile.x + i, (int) tile.y + j) == Ref_donnees.sol_stationEpuration
                                || GetBlock(TileMap1, (int) tile.x + i, (int) tile.y + j) == Ref_donnees.sol_maisonEau;
                j++;
            }

            i++;
        }

        return somehtingHere;
    }
    public bool AlreadySomethingHereTuyaux(Vector2 tile)
    {
        bool somehtingHere = false;

        somehtingHere = GetBlock(TileMap0, (int) tile.x , (int) tile.y) == Ref_donnees.route
                        || GetBlock(TileMap0, (int) tile.x , (int) tile.y) == Ref_donnees.eau
                        || GetBlock(TileMap0, (int) tile.x , (int) tile.y) == Ref_donnees.montagne_sol
                        || SshCity.Game.Plan.Tuyaux.IsTuyaux(GetBlock(TileMap0, (int) tile.x , (int) tile.y));

        return somehtingHere;
    }

    public void SetAchatBlocs(Vector2 tile, bool route)
    {
        (int largeur, int longueur) dimensions = (1, 1);
        try
        {
            dimensions = Ref_donnees.dimensions[_batiment];
        }
        catch (Exception)
        {
        }

        int i = 1;
        while (i < dimensions.longueur + 1)
        {
            int j = 1;
            while (j < dimensions.largeur + 1)
            {
                if (_batiment == Ref_donnees.stationEpuration)
                {
                    SshCity.Game.Plan.Tuyaux.ListEpuration.Add(new Vector2(tile.x + i, tile.y + j));
                }
                SetBlock(TileMap1, (int) tile.x + i, (int) tile.y + j, Ref_donnees.route);
                if (!route)
                {
                    SetBlock(TileMap0, (int) tile.x + i, (int) tile.y + j, Ref_donnees.route);
                }
                MainPlan.BatimentsTiles.Add(new Vector2(tile.x + i-1, tile.y + j-1), new Vector2(tile.x, tile.y));
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
        BuildingType batimentClass = (BuildingType) batiment; 
        Building.Create(batimentClass, tile);
        Building batima = Building.Delete(tile);
        batima.energyAndWater(batima);
        Building.ListBuildings.Add(batima);
    }
}