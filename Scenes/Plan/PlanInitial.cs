using Godot;
using System;
using System.Collections.Concurrent;
using SshCity.Scenes.Plan;

public class PlanInitial : Node2D
{
    public static Vector2 PositionTile = new Vector2(0,0);
    public TileMap TileMap1;
    public TileMap TileMap2;
    public TileMap TileMap3;
    public TileMap TileMap4;
    private PackedScene _maisonNodeScene;
    private PackedScene _caserNodeScene;
    private PackedScene _immeubleNodeScene;
    private PackedScene _immeubleVertNodeScene;
    private PackedScene _policeNodeScence;
    private PackedScene _hospitalNodeScene;
    private PackedScene _maison3NodeScene;
    private PackedScene _maison4NodeScence;
    private PackedScene _maison5NodeScene;
    private PackedScene _parcNodeScence;
    private PackedScene _cafeNodeScene;
    private PackedScene _egliseNodeScene;
    private PackedScene _fermeNodeScene;
    private PackedScene _hotelNodeScene;
    private PackedScene _McAllyNodeScene;
    private PackedScene _piscineNodeScene;
    private PackedScene _restaurantNodeScene;
    private PackedScene _restaurant2NodeScene;
    

    public string str_TileMap1 = "TileMap1";
    public string str_TileMap2 = "TileMap2";
    public string str_TileMap3 = "TileMap3";
    public string str_TileMap4 = "TileMap4";

    private Vector2 _lastTile = new Vector2(0, 0);
    private static int _batiment;
    private static int _prix;
    private static bool _achat = false;
    private static bool _achatRoute = false;
    private static bool _pressed = false;

    public static bool Achat
    {
        get => _achat;
        set => _achat = value;
    }

    public static int Batiment
    {
        get => _batiment;
        set => _batiment = value;
    }

    public static int Prix
    {
        get => _prix;
        set => _prix = value;
    }

    public override void _Ready()
    { 
        TileMap1 = (TileMap) GetNode(str_TileMap1);
        TileMap2 = (TileMap) GetNode(str_TileMap2);
        TileMap3 = (TileMap) GetNode(str_TileMap3);
        TileMap4 = (TileMap) GetNode(str_TileMap4);

        _maisonNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/MaisonNode.tscn");
        _caserNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/CaserneNode.tscn");
        _immeubleNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/ImmeubleNode.tscn");
        _policeNodeScence = (PackedScene) GD.Load("res://Scenes/Buildings/PoliceNode.tscn");
        _hospitalNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/HospitalNode.tscn");
        _cafeNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/CafeNode.tscn");
        _egliseNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/EgliseNode.tscn");
        _fermeNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/FermeNode.tscn");
        _hotelNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/HospitalNode.tscn");
        _immeubleVertNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/ImmeubleNode.tscn");
        _maison3NodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/Maison3Node.tscn");
        _maison4NodeScence = (PackedScene) GD.Load("res://Scenes/Buildings/Maison4Node.tscn");
        _maison5NodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/Maison5Node.tscn");
        _McAllyNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/McAllyNode.tscn");
        _parcNodeScence = (PackedScene) GD.Load("res://Scenes/Buildings/ParcNode.tscn");
        _piscineNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/PiscineNode.tscn");
        _restaurantNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/RestaurantNode.tscn");
        _restaurant2NodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/Restaurant2Node.tscn");

        //Ajout Node village de base
        Maison3Node maison3 = (Maison3Node) _maison3NodeScene.Instance();
        AddChild(maison3);
        Maison4Node maison4 = (Maison4Node) _maison4NodeScence.Instance();
        AddChild(maison4);
        Maison5Node maison5 = (Maison5Node) _maison5NodeScene.Instance();
        AddChild(maison5);
        FermeNode ferme = (FermeNode) _fermeNodeScene.Instance();
        AddChild(ferme);
        ParcNode parc = (ParcNode) _parcNodeScence.Instance();
        AddChild(parc);
        EgliseNode eglise = (EgliseNode) _egliseNodeScene.Instance();
        AddChild(eglise);
        RestaurantNode restaurant = (RestaurantNode) _restaurantNodeScene.Instance();
        AddChild(restaurant);
        Restaurant2Node retsaurant2 = (Restaurant2Node) _restaurant2NodeScene.Instance();
        AddChild(retsaurant2);
    }

    public void SetBlock(TileMap tileMap, int x, int y, int index)
    {
        tileMap.SetCell(x, y, index);
    }
    
    public int GetBlock(TileMap tileMap, int x, int y)
    {
        return tileMap.GetCell(x, y);
    }

    private Vector2 GetTilePosition()
    {
        Vector2 mouse_pos = GetGlobalMousePosition();
        mouse_pos = new Vector2((float)(mouse_pos.x / 0.05), (float)(mouse_pos.y/0.05));
        Vector2 tile = TileMap1.WorldToMap(mouse_pos);
        tile = new Vector2(tile.x-1, tile.y-1);
        return tile;
    }

    private bool AlreadySomethingHere(Vector2 tile)
    {
        return GetBlock(TileMap2, (int) tile.x, (int) tile.y) != -1;
    }

    public static void AchatRoute(bool start)
    {
        if (start)
        {
            _batiment = Ref_donnees.route_left;
            _prix = 500;
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
        Interface.Money -= _prix;

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
    }

    public bool IsRoute(int bloc)
    {
        return bloc == Ref_donnees.route_left ||
               bloc == Ref_donnees.route_right ||
               bloc == Ref_donnees.route_bord_bas_droit ||
               bloc == Ref_donnees.route_bord_bas_gauche ||
               bloc == Ref_donnees.route_bord_haut_droit ||
               bloc == Ref_donnees.route_bord_haut_gauche ||
               bloc == Ref_donnees.route_croisement ||
               bloc == Ref_donnees.route_virage_bas ||
               bloc == Ref_donnees.route_virage_droit ||
               bloc == Ref_donnees.route_virage_gauche ||
               bloc == Ref_donnees.route_virage_haut ||
               bloc == Ref_donnees.route_T_bas_droite ||
               bloc == Ref_donnees.route_T_bas_gauche ||
               bloc == Ref_donnees.route_T_haut_droit ||
               bloc == Ref_donnees.route_T_haut_gauche;
    }
    
    public int ChoixRoute(Vector2 tile)
    {
        int x = (int)tile.x;
        int y = (int) tile.y;
        bool HD = IsRoute(GetBlock(TileMap2, x, y - 1)) && GetBlock(TileMap1, x+1, y) == Ref_donnees.route;
        bool BD = IsRoute(GetBlock(TileMap2, x + 1, y)) && GetBlock(TileMap1, x+2, y+1) == Ref_donnees.route;
        bool BG = IsRoute(GetBlock(TileMap2, x, y + 1)) && GetBlock(TileMap1, x+1, y+2) == Ref_donnees.route;
        bool HG = IsRoute(GetBlock(TileMap2, x - 1, y)) && GetBlock(TileMap1, x, y+1) == Ref_donnees.route;

        if (HD && BD && BG && HG)
        {
            return Ref_donnees.route_croisement;
        }

        if (HD && BD && HG)
        {
            return Ref_donnees.route_T_haut_droit;
        }

        if (HD && BD && BG)
        {
            return Ref_donnees.route_T_bas_droite;
        }

        if (HG && BG && BD)
        {
            return Ref_donnees.route_T_bas_gauche;
        }

        if (BG && HD && HG)
        {
            return Ref_donnees.route_T_haut_gauche;
        }

        if (HD && BG)
        {
            return Ref_donnees.route_right;
        }

        if (BD && HG)
        {
            return Ref_donnees.route_left;
        }

        if (HD && BD)
        {
            return Ref_donnees.route_virage_gauche;
        }

        if (BD && BG)
        {
            return Ref_donnees.route_virage_haut;
        }

        if (HG && BG)
        {
            return Ref_donnees.route_virage_droit;
        }

        if (HG && HD)
        {
            return Ref_donnees.route_virage_bas;
        }

        if (HD)
        {
            return Ref_donnees.route_bord_bas_gauche;
        }

        if (BD)
        {
            return Ref_donnees.route_bord_haut_gauche;
        }

        if (BG)
        {
            return Ref_donnees.route_bord_haut_droit;
        }

        if (HG)
        {
            return Ref_donnees.route_bord_bas_droit;
        }
        
        return Ref_donnees.route_left;
    }

    public void ChangeRoute(Vector2 tile)
    {
        int x = (int)tile.x;
        int y = (int) tile.y;
        bool HD = IsRoute(GetBlock(TileMap2, x, y - 1)) && GetBlock(TileMap1, x+1, y) == Ref_donnees.route;
        bool BD = IsRoute(GetBlock(TileMap2, x + 1, y)) && GetBlock(TileMap1, x+2, y+1) == Ref_donnees.route;
        bool BG = IsRoute(GetBlock(TileMap2, x, y + 1)) && GetBlock(TileMap1, x+1, y+2) == Ref_donnees.route;
        bool HG = IsRoute(GetBlock(TileMap2, x - 1, y)) && GetBlock(TileMap1, x, y+1) == Ref_donnees.route;

        if (HD)
        {
            SetBlock(TileMap2, x, y-1, ChoixRoute(new Vector2(x, y-1)));
        }
        if (BD)
        {
            SetBlock(TileMap2, x+1, y, ChoixRoute(new Vector2(x+1, y)));
        }
        if (BG)
        {
            SetBlock(TileMap2, x, y+1, ChoixRoute(new Vector2(x, y+1)));
        }
        if (HG)
        {
            SetBlock(TileMap2, x-1, y, ChoixRoute(new Vector2(x-1, y)));
        }
    }
    
    public override void _Input(InputEvent OneAction)
    {
        base._Input(OneAction);
        if (OneAction is InputEventMouse && (_achat ||_achatRoute))
        {

            Vector2 tile = GetTilePosition();
            if (_achatRoute)
            {
                _batiment = ChoixRoute(tile);
            }
            if (!AlreadySomethingHere(tile))
            {
                SetBlock(TileMap2, (int)tile.x, (int)tile.y, _batiment);
                if (tile != _lastTile)
                {
                    SetBlock(TileMap2, (int)_lastTile.x, (int)_lastTile.y, -1);
                }
                _lastTile = tile;
            }
            else
            {
                if (tile != _lastTile)
                {
                    SetBlock(TileMap2, (int)_lastTile.x, (int)_lastTile.y, -1);
                }
            }
 
        }

        if (OneAction.IsActionPressed("ClickG") && (_achat || _achatRoute))
        {
            _achat = false;
            _lastTile = new Vector2(0,0);
            Vector2 tile = GetTilePosition();
            GD.Print(GetBlock(TileMap2, (int)tile.x, (int)tile.y));
            if (GetBlock(TileMap2, (int)tile.x, (int)tile.y) == _batiment)
            {
                if (GetBlock(TileMap1, (int)tile.x+1, (int)tile.y+1) == Ref_donnees.terre)
                {
                    SetBlock(TileMap1, (int)tile.x+1, (int)tile.y+1, Ref_donnees.route);
                    if (_achatRoute)
                    {
                        ChangeRoute(tile);
                    }
                    AjoutNode(_batiment);
                }
                else
                {
                    //MESSAGE ERREUR
                }
            }
            else
            {
                //MESSAGE ERREUR
            }
        }

        if (_pressed)
        {
            Vector2 tile = GetTilePosition();
            if (GetBlock(TileMap1, (int)tile.x+1, (int)tile.y+1) != Ref_donnees.route)  //Corrige _bug bouton route
            {
                SetBlock(TileMap2, (int)tile.x, (int)tile.y, -1);
            }
            _pressed = false;
        }
    }
    
}
