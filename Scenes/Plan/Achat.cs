using Godot;
using System;
using System.Collections.Concurrent;
using SshCity.Scenes.Plan;

public partial class PlanInitial
{
    public bool AlreadySomethingHere(Vector2 tile)
    {/*
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

        return somehtingHere;*/
        return GetBlock(TileMap1, (int) tile.x+1, (int) tile.y+1) == Ref_donnees.route
            || GetBlock(TileMap1, (int) tile.x+1, (int) tile.y+1) == Ref_donnees.montagne_sol
            || GetBlock(TileMap1, (int) tile.x+1, (int) tile.y+1) == Ref_donnees.sable
            || GetBlock(TileMap1, (int) tile.x+1, (int) tile.y+1) == Ref_donnees.eau;
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
    public void AjoutNode(int batiment)
    {

        if (Interface.Money-_prix >=0 )
        {
            Interface.Money -= _prix;
        }

        if (batiment == MaisonNode.Bloc)
	    {
            MaisonNode maison1 = (MaisonNode) _maisonNodeScene.Instance();
            AddChild(maison1);
        }
        else if (batiment == CaserneNode.Bloc)
        {
            CaserneNode caserne = (CaserneNode) _caserNodeScene.Instance();
            AddChild(caserne);
        }
        else if (batiment == ImmeubleNode.Bloc)
        {
            ImmeubleNode immeuble = (ImmeubleNode) _immeubleNodeScene.Instance();
            AddChild(immeuble);
        }
        else if (batiment == PoliceNode.Bloc)
        {
            PoliceNode police = (PoliceNode) _policeNodeScence.Instance();
            AddChild(police);
        }
        else if (batiment == HospitalNode.Bloc)
        {
            HospitalNode hopital = (HospitalNode) _hospitalNodeScene.Instance();
            AddChild(hopital);
        }
        else if (batiment == CafeNode.Bloc)
        {
            CafeNode cafe = (CafeNode) _cafeNodeScene.Instance();
            AddChild(cafe);
        } 
        else if (batiment == EgliseNode.Bloc)
        {
            EgliseNode eglise = (EgliseNode) _egliseNodeScene.Instance();
            AddChild(eglise);
        }
        else if (batiment == FermeNode.Bloc)
        {
            FermeNode ferme = (FermeNode) _fermeNodeScene.Instance();
            AddChild(ferme);
        }
        else if (batiment == HotelNode.Bloc)
        {
            HotelNode hotel = (HotelNode) _hotelNodeScene.Instance();
            AddChild(hotel);
        }
        else if (batiment == ImmeubleVertNode.Bloc)
        {
            ImmeubleVertNode immeubleVert = (ImmeubleVertNode) _immeubleVertNodeScene.Instance();
            AddChild(immeubleVert);
        }
        else if (batiment == Maison3Node.Bloc)
        {
            Maison3Node maison3 = (Maison3Node) _maison3NodeScene.Instance();
            AddChild(maison3);
        }
        else if (batiment == Maison4Node.Bloc)
        {
            Maison4Node maison4 = (Maison4Node) _maison4NodeScence.Instance();
            AddChild(maison4);
        }
        else if (batiment == Maison5Node.Bloc)
        {
            Maison5Node maison5 = (Maison5Node) _maison5NodeScene.Instance();
            AddChild(maison5);
        }
        else if (batiment == McAllyNode.Bloc)
        {
            McAllyNode mcAlly = (McAllyNode) _McAllyNodeScene.Instance();
            AddChild(mcAlly);
        }
        else if (batiment == ParcNode.Bloc)
        {
            ParcNode parc = (ParcNode) _parcNodeScence.Instance();
            AddChild(parc);
        }
        else if (batiment == PiscineNode.Bloc)
        {
            PiscineNode piscine = (PiscineNode) _piscineNodeScene.Instance();
            AddChild(piscine);
        }
        else if (batiment == RestaurantNode.Bloc)
        {
            RestaurantNode restaurant = (RestaurantNode) _restaurantNodeScene.Instance();
            AddChild(restaurant);
        }
        else if (batiment == Restaurant2Node.Bloc)
        {
            Restaurant2Node restaurant2 = (Restaurant2Node) _restaurant2NodeScene.Instance();
            AddChild(restaurant2);
        }
        else if (batiment == CentraleElectriqueNode.Bloc)
        {
            CentraleElectriqueNode centraleElectrique = (CentraleElectriqueNode) _centraleElectriqueNodeScene.Instance();
            AddChild(centraleElectrique);
        } 
    }
}
