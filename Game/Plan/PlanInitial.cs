using System;
using System.Collections.Generic;
using Godot;
using SshCity.Game.Buildings;
using SshCity.Game.Plan;
using SshCity.Game.Vehicules;

public partial class PlanInitial : Node2D
{
    public static bool Tuyaux = false;
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
    
    //Add Vehicules
    public static bool VehiculesInit = false;
    private static bool addVehicule = true; //MairieMenu desactivation des vehicules
    public static Vector2 VehiculesPosition;
    public static Vehicules.Type VehiculesType;
    private PackedScene _vehiculeScene;
    private Timer VehiculeTimer;
    private static bool VehiculesAutonome;
    
    //Accidents
    private PackedScene _accidentArea2D;
    private static bool addAccident = false;
    private static Vector2 positionAccident;
    private static bool deleteAccident = false;
    private static Vector2 positionDeleteAccident;
    private static bool _accidentVisi = false;
    
    public static List<Vector2> DepartRoute = new List<Vector2>();

    //Add Houloucoupters
    public static bool HouloucoupterInit = false;
    public static Vector2 HouloucoupterPosition = new Vector2(60, 0);
    public static Houloucoupter.Type HouloucoupterType;
    public static Vector2 HouloucoupterDestination;
    private PackedScene _houloucoupterScene;
   
    //Add Bateaux
    public PackedScene _bateauxScene;



    public static int MAX_CAR = 0;
    public static int NbCar = 0;
    
    public static bool AddVehicule1
    {
        get => addVehicule;
        set => addVehicule = value;
    }
    
    private Vector2 _lastTile = new Vector2(0, 0);

    public string str_TileMapNeg = "TileMap-1";
    public string str_TileMap0 = "TileMap0";
    public string str_TileMap1 = "TileMap1";
    public string str_TileMap2 = "TileMap2";
    public string str_TileMap3 = "TileMap3";
    private const string str_VehiculeTimer = "Vehicule";
    public TileMap TileMap0;
    public TileMap TileMap1;
    public TileMap TileMap2;
    public TileMap TileMap3;
    public TileMap TileMapNeg;

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
        TileMap0 = (TileMap) GetNode(str_TileMap0);
        TileMap1 = (TileMap) GetNode(str_TileMap1);
        TileMap2 = (TileMap) GetNode(str_TileMap2);
        TileMap3 = (TileMap) GetNode(str_TileMap3);
        TileMapNeg = (TileMap) GetNode(str_TileMapNeg);
        VehiculeTimer = (Timer) GetNode(str_VehiculeTimer);
        VehiculeTimer.Autostart = true;
        _vehiculeScene = (PackedScene) GD.Load("res://Game/Vehicules/Vehicules.tscn");
        _accidentArea2D = (PackedScene) GD.Load("res://Game/Vehicules/Accident.tscn");
        _houloucoupterScene = (PackedScene) GD.Load("res://Game/Vehicules/Houloucoupter.tscn");
        _bateauxScene = (PackedScene) GD.Load("res://Game/Vehicules/Bateau.tscn");
        VehiculeTimer.Connect("timeout", this, nameof(TimerOutVehicule));
        Interface.Init(this);
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

        if (addAccident)
        {
            Accident area = (Accident) _accidentArea2D.Instance();
            area.Position = positionAccident;
            
            area.Init(_accidentVisi);
            AddChild(area);
            addAccident = false;
        }

        if (HouloucoupterInit)
        {
            Houloucoupter _houloucoupter = (Houloucoupter) _houloucoupterScene.Instance();
            _houloucoupter.Init(this, HouloucoupterType, HouloucoupterPosition, HouloucoupterDestination);
            AddChild(_houloucoupter);
            HouloucoupterInit = false;
        }
    }

    public static void AddZoneAccident(Vector2 posi, bool visi)
    {
        _accidentVisi = visi;
        positionAccident = posi;
        addAccident = true;
    }

    public void TimerOutVehicule()
    {
        if (addVehicule)
        {
            Random rand = new Random();
            int whichVehicule = rand.Next(0, Vehicules.ListTypeVehicules.Count);
            Vehicules.Type type = Vehicules.ListTypeVehicules[whichVehicule];
            int WhereVehicule = rand.Next(0, DepartRoute.Count);
            AddVehicule(type, DepartRoute[WhereVehicule], true);
        }
    }

    public static void AddVehicule(Vehicules.Type type, Vector2 position, bool autonome=false)
    {
        if (MAX_CAR <= NbCar)
        {
            VehiculesInit = false;
        }
        else
        {
            VehiculesInit = true;
            NbCar += 1;
            VehiculesPosition = position;
            VehiculesType = type;
            VehiculesAutonome = autonome;
        }
    }

    public static void AddHouloucoupter(Houloucoupter.Type type, Vector2 position, Vector2 destination)
    {
        HouloucoupterPosition = position;
        HouloucoupterType = type;
        HouloucoupterDestination = destination;
        HouloucoupterInit = true;
    }

    public void SetBlock(TileMap tileMap, int x, int y, int index)
    {
        tileMap.SetCell(x, y, index);
    }

    public int GetBlock(TileMap tileMap, int x, int y)
    {
        return tileMap.GetCell(x, y);
    }

    public Vector2 GetTilePosition(TileMap tileMap)
    {
        Vector2 mouse_pos = GetGlobalMousePosition();
        mouse_pos = new Vector2((float) (mouse_pos.x / 0.05), (float) (mouse_pos.y / 0.05));
        Vector2 tile = tileMap.WorldToMap(mouse_pos);
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
            Vector2 tile = GetTilePosition(TileMap1);
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
            Vector2 tile = GetTilePosition(TileMap1);
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
            Interface.InterdiMoney = true;
        }
        else
        {
            _NotEnoughtMoney = false;
            Interface.InterdiMoney = false;
        }

        if (_pressed)
        {
            Vector2 tile = GetTilePosition(TileMap1);
            if (GetBlock(TileMap1, (int) tile.x + 1, (int) tile.y + 1) != Ref_donnees.route) //Corrige _bug bouton route
            {
                SetBlock(TileMap2, (int) tile.x, (int) tile.y, -1);
            }

            _pressed = false;
        }

        if (OneAction.IsActionPressed("ClickG") && _delete)
        {
            _tileSupressing = GetTilePosition(TileMap1);
            try
            {
                _tileSupressing = MainPlan.BatimentsTiles[_tileSupressing];
            }
            catch (Exception)
            {
                
            }
            _delete = false;
            DeleteVerif.Verif = true;
        }

        if (DeleteSure)
        {
            int bloc = GetBlock(TileMap2, (int) _tileSupressing.x, (int) _tileSupressing.y);
            Building.Delete(_tileSupressing);
            SetBlock(TileMap2, (int) _tileSupressing.x, (int) _tileSupressing.y, -1);
            (int largeur, int longueur) dimensions = (1, 1);
            try
            {
                dimensions = Ref_donnees.dimensions[bloc];
            }
            catch (Exception)
            {
            }

            int i = +1;
            while (i < dimensions.longueur+1)
            {
                int j = 0+1;
                while (j < dimensions.largeur+1)
                {
                    SetBlock(TileMap1, (int) _tileSupressing.x + i, (int) _tileSupressing.y + j, Ref_donnees.terre);
                    SetBlock(TileMap0, (int) _tileSupressing.x + i, (int) _tileSupressing.y + j, Ref_donnees.terre);
                    j++;
                }

                i++;
            }
            //SetBlock(TileMap1, (int) _tileSupressing.x + 1, (int) _tileSupressing.y + 1, Ref_donnees.terre);
            Routes.ChangeRoute(_tileSupressing, this);
            _delete = false;
            MainPlan.ListeBatiment.Remove((_tileSupressing, bloc));
            DeleteSure = false;
        }

        if (OneAction.IsActionPressed("ClickG") && !(_achat) && !(_achatRoute) && !_delete && !DeleteVerif.Verif &&
            !Infos.IsOpen)
        {
            Vector2 tile = GetTilePosition(TileMap1);
            int batiment = -1;
            
            try
            {
                tile = MainPlan.BatimentsTiles[tile];
            }
            catch (Exception)
            {
                
            }
            
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
        
        //Tuyaux
        if (OneAction is InputEventMouse && Tuyaux)
        {
            Vector2 tile = GetTilePosition(TileMap0) + new Vector2(1, 1);
            _batiment = SshCity.Game.Plan.Tuyaux.ChoixTuyaux(tile, this);
            

            if (!AlreadySomethingHereTuyaux(tile))
            {
                Interface.Interdit = false;
                SetBlock(TileMap0, (int) tile.x, (int) tile.y, _batiment);
                if (tile != _lastTile)
                {
                    SetBlock(TileMap0, (int) _lastTile.x, (int) _lastTile.y, Ref_donnees.terre);
                }

                _lastTile = tile;
            }
            else
            {
                if (tile != _lastTile)
                {
                    SetBlock(TileMap0, (int) _lastTile.x, (int) _lastTile.y, Ref_donnees.terre);
                    Interface.Interdit = true;
                }
            }
        }

        if (OneAction.IsActionPressed("ClickG") && Tuyaux)
        {
            Tuyaux = false;
            _lastTile = new Vector2(0, 0);
            Vector2 tile = GetTilePosition(TileMap0) + new Vector2(1, 1);
            if (GetBlock(TileMap0, (int) tile.x, (int) tile.y) == _batiment)
            {
                if (GetBlock(TileMapNeg, (int) tile.x, (int) tile.y) == Ref_donnees.sol_tuyaux)
                {
                    Interface.Interdit = false;
                    SetBlock(TileMapNeg, (int)tile.x, (int)tile.y, Ref_donnees.tuyaux_terre);
                    SshCity.Game.Plan.Tuyaux.ChangeTuyaux(tile, this);
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
    }
}