using Godot;
using System;
using System.Collections.Concurrent;
using SshCity.Scenes.Buildings;
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
        
        
        //public Building(int bloc, int cost, int[] earn, string titre, int[]upgrade_cost, int[] gainXp, string image, Batiments.Class batimentClass, Vector2 position)

        if (batiment == MaisonNode.Bloc[0])
	    {
            MaisonNode maison1 = (MaisonNode) _maisonNodeScene.Instance();
            new Batiments.Building(MaisonNode.Bloc, MaisonNode.Cost, MaisonNode.EarnTableau, MaisonNode.Titre, MaisonNode.UpgradeCost, MaisonNode.GainXp, MaisonNode.Image, Batiments.Class.MAISON, tile);
            AddChild(maison1);
        }
        else if (batiment == CaserneNode.Bloc[0])
        {
            CaserneNode caserne = (CaserneNode) _caserNodeScene.Instance();
            new Batiments.Building(CaserneNode.Bloc, CaserneNode.Cost, CaserneNode.EarnTableau, CaserneNode.Titre, CaserneNode.UpgradeCost, CaserneNode.GainXp, CaserneNode.Image, Batiments.Class.CASERNE, tile);
            AddChild(caserne);
        }
        else if (batiment == ImmeubleNode.Bloc[0])
        {
            ImmeubleNode immeuble = (ImmeubleNode) _immeubleNodeScene.Instance();
            new Batiments.Building(ImmeubleNode.Bloc, ImmeubleNode.Cost, ImmeubleNode.EarnTableau, ImmeubleNode.Titre, ImmeubleNode.UpgradeCost, ImmeubleNode.GainXp, ImmeubleNode.Image, Batiments.Class.IMMEUBLE, tile);
            AddChild(immeuble);
        }
        else if (batiment == PoliceNode.Bloc[0])
        {
            PoliceNode police = (PoliceNode) _policeNodeScence.Instance();
            new Batiments.Building(PoliceNode.Bloc, PoliceNode.Cost, PoliceNode.EarnTableau, PoliceNode.Titre, PoliceNode.UpgradeCost, PoliceNode.GainXp, PoliceNode.Image, Batiments.Class.POLICE, tile);
            AddChild(police);
        }
        else if (batiment == HospitalNode.Bloc[0])
        {
            HospitalNode hopital = (HospitalNode) _hospitalNodeScene.Instance();
            new Batiments.Building(HospitalNode.Bloc, HospitalNode.Cost, HospitalNode.EarnTableau, HospitalNode.Titre, HospitalNode.UpgradeCost, HospitalNode.GainXp, HospitalNode.Image, Batiments.Class.HOSPITAL, tile);
            AddChild(hopital);
        }
        else if (batiment == CafeNode.Bloc[0])
        {
            CafeNode cafe = (CafeNode) _cafeNodeScene.Instance();
            new Batiments.Building(CafeNode.Bloc, CafeNode.Cost, CafeNode.EarnTableau, CafeNode.Titre, CafeNode.UpgradeCost, CafeNode.GainXp, CafeNode.Image, Batiments.Class.CAFE, tile);
            AddChild(cafe);
        } 
        else if (batiment == EgliseNode.Bloc[0])
        {
            EgliseNode eglise = (EgliseNode) _egliseNodeScene.Instance();
            new Batiments.Building(EgliseNode.Bloc, EgliseNode.Cost, EgliseNode.EarnTableau, EgliseNode.Titre, EgliseNode.UpgradeCost, EgliseNode.GainXp, EgliseNode.Image, Batiments.Class.EGLISE, tile);
            AddChild(eglise);
        }
        else if (batiment == FermeNode.Bloc[0])
        {
            FermeNode ferme = (FermeNode) _fermeNodeScene.Instance();
            new Batiments.Building(FermeNode.Bloc, FermeNode.Cost, FermeNode.EarnTableau, FermeNode.Titre, FermeNode.UpgradeCost, FermeNode.GainXp, FermeNode.Image, Batiments.Class.FERME, tile);
            AddChild(ferme);
        }
        else if (batiment == HotelNode.Bloc[0])
        {
            HotelNode hotel = (HotelNode) _hotelNodeScene.Instance();
            new Batiments.Building(HotelNode.Bloc, HotelNode.Cost, HotelNode.EarnTableau, HotelNode.Titre, HotelNode.UpgradeCost, HotelNode.GainXp, HotelNode.Image, Batiments.Class.HOTEL, tile);
            AddChild(hotel);
        }
        else if (batiment == ImmeubleVertNode.Bloc[0])
        {
            ImmeubleVertNode immeubleVert = (ImmeubleVertNode) _immeubleVertNodeScene.Instance();
            new Batiments.Building(ImmeubleVertNode.Bloc, ImmeubleVertNode.Cost, ImmeubleVertNode.EarnTableau, ImmeubleVertNode.Titre, ImmeubleVertNode.UpgradeCost, ImmeubleVertNode.GainXp, MaisonNode.Image, Batiments.Class.IMMEUBLEVERT, tile);
            AddChild(immeubleVert);
        }
        else if (batiment == Maison3Node.Bloc[0])
        {
            Maison3Node maison3 = (Maison3Node) _maison3NodeScene.Instance();
            new Batiments.Building(Maison3Node.Bloc, Maison3Node.Cost, Maison3Node.EarnTableau, Maison3Node.Titre, Maison3Node.UpgradeCost, Maison3Node.GainXp, Maison3Node.Image, Batiments.Class.MAISON3, tile);
            AddChild(maison3);
        }
        else if (batiment == Maison4Node.Bloc[0])
        {
            Maison4Node maison4 = (Maison4Node) _maison4NodeScence.Instance();
            new Batiments.Building(Maison4Node.Bloc, Maison4Node.Cost, Maison4Node.EarnTableau, Maison4Node.Titre, Maison4Node.UpgradeCost, Maison4Node.GainXp, Maison4Node.Image, Batiments.Class.MAISON4, tile);
            AddChild(maison4);
        }
        else if (batiment == Maison5Node.Bloc[0])
        {
            Maison5Node maison5 = (Maison5Node) _maison5NodeScene.Instance();
            new Batiments.Building(Maison5Node.Bloc, Maison5Node.Cost, Maison5Node.EarnTableau, Maison5Node.Titre, Maison5Node.UpgradeCost, Maison5Node.GainXp, Maison5Node.Image, Batiments.Class.MAISON5, tile);
            AddChild(maison5);
        }
        else if (batiment == McAllyNode.Bloc[0])
        {
            McAllyNode mcAlly = (McAllyNode) _McAllyNodeScene.Instance();
            new Batiments.Building(McAllyNode.Bloc, McAllyNode.Cost, McAllyNode.EarnTableau, McAllyNode.Titre, McAllyNode.UpgradeCost, McAllyNode.GainXp, McAllyNode.Image, Batiments.Class.MCALLY, tile);
            AddChild(mcAlly);
        }
        else if (batiment == ParcNode.Bloc[0])
        {
            ParcNode parc = (ParcNode) _parcNodeScence.Instance();
            new Batiments.Building(ParcNode.Bloc, ParcNode.Cost, ParcNode.EarnTableau, ParcNode.Titre, ParcNode.UpgradeCost, ParcNode.GainXp, ParcNode.Image, Batiments.Class.PARC, tile);
            AddChild(parc);
        }
        else if (batiment == PiscineNode.Bloc[0])
        {
            PiscineNode piscine = (PiscineNode) _piscineNodeScene.Instance();
            new Batiments.Building(PiscineNode.Bloc, PiscineNode.Cost, PiscineNode.EarnTableau, PiscineNode.Titre, PiscineNode.UpgradeCost, PiscineNode.GainXp, PiscineNode.Image, Batiments.Class.PISCINE, tile);
            AddChild(piscine);
        }
        else if (batiment == RestaurantNode.Bloc[0])
        {
            RestaurantNode restaurant = (RestaurantNode) _restaurantNodeScene.Instance();
            new Batiments.Building(RestaurantNode.Bloc, RestaurantNode.Cost, RestaurantNode.EarnTableau, RestaurantNode.Titre, RestaurantNode.UpgradeCost, RestaurantNode.GainXp, RestaurantNode.Image, Batiments.Class.RESTAURANT, tile);
            AddChild(restaurant);
        }
        else if (batiment == Restaurant2Node.Bloc[0])
        {
            Restaurant2Node restaurant2 = (Restaurant2Node) _restaurant2NodeScene.Instance();
            new Batiments.Building(Restaurant2Node.Bloc, Restaurant2Node.Cost, Restaurant2Node.EarnTableau, Restaurant2Node.Titre, Restaurant2Node.UpgradeCost, Restaurant2Node.GainXp, Restaurant2Node.Image, Batiments.Class.RESTAURANT2, tile);
            AddChild(restaurant2);
        }
        else if (batiment == CentraleElectriqueNode.Bloc[0])
        {
            CentraleElectriqueNode centraleElectrique = (CentraleElectriqueNode) _centraleElectriqueNodeScene.Instance();
            new Batiments.Building(CentraleElectriqueNode.Bloc, CentraleElectriqueNode.Cost, CentraleElectriqueNode.EarnTableau, CentraleElectriqueNode.Titre, CentraleElectriqueNode.UpgradeCost, CentraleElectriqueNode.GainXp, CentraleElectriqueNode.Image, Batiments.Class.CENTRALE, tile);
            AddChild(centraleElectrique);
        } 
    }
}
