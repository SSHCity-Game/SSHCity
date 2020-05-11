using Godot;
using System;
using System.Collections.Concurrent;
using SshCity.Scenes.Buildings;
using SshCity.Scenes.Plan;

public partial class PlanInitial : Node2D
{
    public static Vector2 PositionTile = new Vector2(0,0);
    public TileMap TileMap1;
    public TileMap TileMap2;
    public TileMap TileMap3;

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
    private PackedScene _centraleElectriqueNodeScene;
    

    public string str_TileMap1 = "TileMap1";
    public string str_TileMap2 = "TileMap2";
    public string str_TileMap3 = "TileMap3";


    private Vector2 _lastTile = new Vector2(0, 0);
    private static int _batiment;
    private static int _prix;
    private static bool _achat = false;
    private static bool _achatRoute = false;
    private static bool _pressed = false;
    private static bool _delete = false;
    private static bool _deleteSure = false;
    private static bool _NotEnoughtMoney = false;
    private static Vector2 _tileSupressing;
    private static int _nbr_Node;

    public static bool DeleteSure
    {
        get => _deleteSure;
        set => _deleteSure = value;
    }

    public static bool Delete
    {
        get => _delete;
        set => _delete = value;
    }

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

        Func<string, string> chemin = str => "res://Scenes/Buildings/" + str +".tscn"; 
        _maisonNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/MaisonNode.tscn");
        _caserNodeScene = (PackedScene) GD.Load(chemin("CaserneNode"));
        _immeubleNodeScene = (PackedScene) GD.Load(chemin("ImmeubleNode"));
        _policeNodeScence = (PackedScene) GD.Load(chemin("PoliceNode"));
        _hospitalNodeScene = (PackedScene) GD.Load(chemin("HospitalNode"));
        _cafeNodeScene = (PackedScene) GD.Load(chemin("CafeNode"));
        _egliseNodeScene = (PackedScene) GD.Load(chemin("EgliseNode"));
        _fermeNodeScene = (PackedScene) GD.Load(chemin("FermeNode"));
        _hotelNodeScene = (PackedScene) GD.Load(chemin("HotelNode"));
        _immeubleVertNodeScene = (PackedScene) GD.Load(chemin("ImmeubleVertNode"));
        _maison3NodeScene = (PackedScene) GD.Load(chemin("Maison3Node"));
        _maison4NodeScence = (PackedScene) GD.Load(chemin("Maison4Node"));
        _maison5NodeScene = (PackedScene) GD.Load(chemin("Maison5Node"));
        _McAllyNodeScene = (PackedScene) GD.Load(chemin("McAllyNode"));
        _parcNodeScence = (PackedScene) GD.Load(chemin("ParcNode"));
        _piscineNodeScene = (PackedScene) GD.Load(chemin("PiscineNode"));
        _restaurantNodeScene = (PackedScene) GD.Load(chemin("RestaurantNode"));
        _restaurant2NodeScene = (PackedScene) GD.Load(chemin("Restaurant2Node"));
        _centraleElectriqueNodeScene = (PackedScene) GD.Load(chemin("CentraleElectriqueNode"));

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
    
    public int GetBlock( TileMap tileMap, int x, int y)
    {
        return tileMap.GetCell(x, y);
    }

    public Vector2 GetTilePosition()
    {
        Vector2 mouse_pos = GetGlobalMousePosition();
        mouse_pos = new Vector2((float)(mouse_pos.x / 0.05), (float)(mouse_pos.y/0.05));
        Vector2 tile = TileMap1.WorldToMap(mouse_pos);
        tile = new Vector2(tile.x-1, tile.y-1);
        return tile;
    }
    


    public override void _Input(InputEvent OneAction)
    {
        base._Input(OneAction);
        _nbr_Node = GetChildCount();
        if (OneAction is InputEventMouse && (_achat ||_achatRoute) && !_NotEnoughtMoney)
        {

            Vector2 tile = GetTilePosition();
            if (_achatRoute)
            {
                _batiment = Routes.ChoixRoute(tile, this);
            }
            if (!AlreadySomethingHere(tile))
            {
                Interface.Interdit = false;
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
                    Interface.Interdit = true;
                }
            }
 
        }

        if (OneAction.IsActionPressed("ClickG") && (_achat || _achatRoute)&& !_NotEnoughtMoney)
        {
            _achat = false;
            _lastTile = new Vector2(0,0);
            Vector2 tile = GetTilePosition();
            GD.Print(GetBlock(TileMap2, (int)tile.x, (int)tile.y));
            if (GetBlock(TileMap2, (int)tile.x, (int)tile.y) == _batiment)
            {
                if (GetBlock(TileMap1, (int)tile.x+1, (int)tile.y+1) == Ref_donnees.terre)
                {
                    Interface.Interdit = false;
                    SetAchatBlocs(tile);
                    if (_achatRoute)
                    {
                        Routes.ChangeRoute(tile, this);
                    }
                    else
                    {
                        MainPlan.ListeNode.Add((tile, _nbr_Node)); 
                    }
                    MainPlan.ListeBatiment.Add((tile, _batiment));
                    AjoutNode(_batiment, tile);
                }
                else
                {
                    //ERROR
                }
            }
            else
            {
                //ERROR
            }
        }
        if ((_achat || _achatRoute) && Interface.Money - _prix < 0)
        {
            _NotEnoughtMoney = true; ;
            Interface.InterdiMoney = true;
        }
        else
        {
            _NotEnoughtMoney = false;
            Interface.InterdiMoney = false;
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

        if (OneAction.IsActionPressed("ClickG") && _delete)
        {
            _tileSupressing = GetTilePosition();
            _delete = false;
            DeleteVerif.Verif = true;
        }

        if (DeleteSure)
        {            
            int bloc = GetBlock(TileMap2, (int) _tileSupressing.x, (int) _tileSupressing.y);
            Batiments.Suppression(_tileSupressing);
            SetBlock(TileMap2, (int)_tileSupressing.x, (int)_tileSupressing.y, -1);
            SetBlock(TileMap1, (int)_tileSupressing.x+1, (int)_tileSupressing.y+1, Ref_donnees.terre);
            Routes.ChangeRoute(_tileSupressing, this);
            if (!Routes.IsRoute(bloc))
            {
                SshCity.Scenes.Plan.Delete.DeleteNode(this, _tileSupressing);
            }
            _delete = false;
            MainPlan.ListeBatiment.Remove((_tileSupressing, bloc));
            DeleteSure = false;
        }

        if (OneAction.IsActionPressed("ClickG") && !(_achat) && !(_achatRoute) && !_delete && !DeleteVerif.Verif)
        {
            Vector2 tile = GetTilePosition();
            int batiment = -1;
            foreach ((Vector2 posi, int node) tuple in MainPlan.ListeBatiment)
            {
                if (tuple.posi == tile)
                {
                    batiment = tuple.node;
                    break;
                }
            }

            if (batiment != -1)
            {
                Interface.ConfigInfos(batiment, this);
            }
        }
    }
    
}
