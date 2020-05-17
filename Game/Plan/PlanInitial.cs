using System;
using System.Collections.Generic;
using Godot;
using SshCity.Game.Buildings;
using SshCity.Game.Plan;
using SshCity.Game.Vehicules;

public partial class PlanInitial : Node2D
{
    public static Vector2 PositionTile = new Vector2(0, 0);
    private static int _batiment;
    private static int _prix;
    private static bool _achat = false;
    private static bool _achatRoute = false;
    private static bool _pressed = false;
    private static bool _delete = false;
    private static bool _deleteSure = false;
    private static bool _NotEnoughtMoney = false;
    private static Vector2 _tileSupressing;
    private static bool _buildOnTileMap2 = false;
    private static Vector2 _tileOnTileMap2;
    public static bool VehiculesInit = false;
    public static Vector2 VehiculesPosition;
    public static Vehicules.Type VehiculesType;
    private PackedScene _vehiculeScene;
    private Timer VehiculeTimer;
    private static bool VehiculesAutonome;
    public static List<Vector2> DepartRoute = new List<Vector2>();


    private Vector2 _lastTile = new Vector2(0, 0);


    public string str_TileMap1 = "TileMap1";
    public string str_TileMap2 = "TileMap2";
    public string str_TileMap3 = "TileMap3";
    private const string str_VehiculeTimer = "Vehicule";
    public TileMap TileMap1;
    public TileMap TileMap2;
    public TileMap TileMap3;

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
        VehiculeTimer = (Timer) GetNode(str_VehiculeTimer);
        VehiculeTimer.Autostart = true;
        _vehiculeScene = (PackedScene) GD.Load("res://Game/Vehicules/Vehicules.tscn");
        VehiculeTimer.Connect("timeout", this, nameof(TimerOutVehicule));
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        if (_buildOnTileMap2)
        {
            SetBlock(TileMap2, (int) _tileOnTileMap2.x, (int) _tileOnTileMap2.y, _batiment);
            _buildOnTileMap2 = false;
        }

        if (VehiculesInit)
        {
            Vehicules _vehicule = (Vehicules) _vehiculeScene.Instance();
            if (VehiculesAutonome)
            {
                _vehicule.Init(this, VehiculesPosition-new Vector2(1, 1), VehiculesType, VehiculesAutonome);
            }
            else
            {
                _vehicule.Init(this, Routes.WhereIsRoute(VehiculesPosition, this), VehiculesType, VehiculesAutonome);
            }
            AddChild(_vehicule);
            VehiculesInit = false;
        }
    }

    public void TimerOutVehicule()
    {
        Random rand = new Random();
        int whichVehicule = rand.Next(0, Vehicules.ListTypeVehicules.Count);
        Vehicules.Type type = Vehicules.ListTypeVehicules[whichVehicule];
        int WhereVehicule = rand.Next(0, DepartRoute.Count);
        AddVehicule(type, DepartRoute[WhereVehicule], true);
    }

    public static void AddVehicule(Vehicules.Type type, Vector2 position, bool autonome=false)
    {
        VehiculesInit = true;
        VehiculesPosition = position;
        VehiculesType = type;
        VehiculesAutonome = autonome;
    }

    public void SetBlock(TileMap tileMap, int x, int y, int index)
    {
        tileMap.SetCell(x, y, index);
    }

    public int GetBlock(TileMap tileMap, int x, int y)
    {
        return tileMap.GetCell(x, y);
    }

    public Vector2 GetTilePosition()
    {
        Vector2 mouse_pos = GetGlobalMousePosition();
        mouse_pos = new Vector2((float) (mouse_pos.x / 0.05), (float) (mouse_pos.y / 0.05));
        Vector2 tile = TileMap1.WorldToMap(mouse_pos);
        tile = new Vector2(tile.x - 1, tile.y - 1);
        return tile;
    }

    public static void Amelioration(Vector2 tile)
    {
        (bool worked, int bloc) amelio = Building.Upgrade(tile);
        GD.Print(amelio);
        if (amelio.worked)
        {
            BuildTileMap2(amelio.bloc, tile);
        }
    }

    public static void BuildTileMap2(int bloc, Vector2 tile)
    {
        _batiment = bloc;
        _tileOnTileMap2 = tile;
        _buildOnTileMap2 = true;
    }

    public override void _Input(InputEvent OneAction)
    {
        base._Input(OneAction);
        if (OneAction is InputEventMouse && (_achat || _achatRoute) && !_NotEnoughtMoney)
        {
            Vector2 tile = GetTilePosition();
            if (_achatRoute)
            {
                _batiment = Routes.ChoixRoute(tile, this);
            }

            if (!AlreadySomethingHere(tile))
            {
                Interface.Interdit = false;
                SetBlock(TileMap2, (int) tile.x, (int) tile.y, _batiment);
                if (tile != _lastTile)
                {
                    SetBlock(TileMap2, (int) _lastTile.x, (int) _lastTile.y, -1);
                }

                _lastTile = tile;
            }
            else
            {
                if (tile != _lastTile)
                {
                    SetBlock(TileMap2, (int) _lastTile.x, (int) _lastTile.y, -1);
                    Interface.Interdit = true;
                }
            }
        }

        if (OneAction.IsActionPressed("ClickG") && (_achat || _achatRoute) && !_NotEnoughtMoney)
        {
            _achat = false;
            _lastTile = new Vector2(0, 0);
            Vector2 tile = GetTilePosition();
            GD.Print(GetBlock(TileMap2, (int) tile.x, (int) tile.y));
            if (GetBlock(TileMap2, (int) tile.x, (int) tile.y) == _batiment)
            {
                if (GetBlock(TileMap1, (int) tile.x + 1, (int) tile.y + 1) == Ref_donnees.terre)
                {
                    Interface.Interdit = false;
                    SetAchatBlocs(tile);
                    if (_achatRoute)
                    {
                        Routes.ChangeRoute(tile, this);
                    }

                    MainPlan.ListeBatiment.Add((tile, _batiment));
                    if (!_achatRoute)
                    {
                        AjoutNode(_batiment, tile);
                    }
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
            _NotEnoughtMoney = true;
            ;
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
            if (GetBlock(TileMap1, (int) tile.x + 1, (int) tile.y + 1) != Ref_donnees.route) //Corrige _bug bouton route
            {
                SetBlock(TileMap2, (int) tile.x, (int) tile.y, -1);
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
            Building.Delete(_tileSupressing);
            SetBlock(TileMap2, (int) _tileSupressing.x, (int) _tileSupressing.y, -1);
            SetBlock(TileMap1, (int) _tileSupressing.x + 1, (int) _tileSupressing.y + 1, Ref_donnees.terre);
            Routes.ChangeRoute(_tileSupressing, this);
            _delete = false;
            MainPlan.ListeBatiment.Remove((_tileSupressing, bloc));
            DeleteSure = false;
        }

        if (OneAction.IsActionPressed("ClickG") && !(_achat) && !(_achatRoute) && !_delete && !DeleteVerif.Verif &&
            !Infos.IsOpen)
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
                Interface.ConfigInfos(tile);
            }
        }
    }
}