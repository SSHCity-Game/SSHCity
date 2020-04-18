using Godot;
using System;

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
    private PackedScene _policeNodeScence;
    private PackedScene _hospitalNodeScene;
    public string str_TileMap1 = "Navigation2D/TileMap1";
    public string str_TileMap2 = "Navigation2D/TileMap2";
    public string str_TileMap3 = "Navigation2D/TileMap3";
    public string str_TileMap4 = "Navigation2D/TileMap4";

    private Vector2 _lastTile = new Vector2(0, 0);
    private static int _batiment;
    private static int _prix;

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
        TileMap1 = (TileMap) GetNode("TileMap1");
        TileMap2 = (TileMap) GetNode("TileMap2");
        TileMap3 = (TileMap) GetNode("TileMap3");
        TileMap4 = (TileMap) GetNode("TileMap4");

        _maisonNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/MaisonNode.tscn");
        _caserNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/CaserneNode.tscn");
        _immeubleNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/ImmeubleNode.tscn");
        _policeNodeScence = (PackedScene) GD.Load("res://Scenes/Buildings/PoliceNode.tscn");
        _hospitalNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/HospitalNode.tscn");
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
    
    public override void _Input(InputEvent OneAction)
    {
        base._Input(OneAction);
        if (OneAction is InputEventMouse && Menu_Achat.Achat)
        {
            Vector2 tile = GetTilePosition();
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

        if (OneAction is InputEventMouseButton && Menu_Achat.Achat)
        {
            Menu_Achat.Achat = false;
            _lastTile = new Vector2(0,0);
            Interface.Money -= _prix;
            
            if (_batiment == MaisonNode.Bloc)
            {
                MaisonNode maison = (MaisonNode) _maisonNodeScene.Instance();
                AddChild(maison);
            }
            else if (_batiment == CaserneNode.Bloc)
            {
                CaserneNode caserne = (CaserneNode) _caserNodeScene.Instance();
                AddChild(caserne);
            }
            else if (_batiment == ImmeubleNode.Bloc)
            {
                ImmeubleNode immeuble = (ImmeubleNode) _immeubleNodeScene.Instance();
                AddChild(immeuble);
            }
            else if (_batiment == PoliceNode.Bloc)
            {
                PoliceNode police = (PoliceNode) _policeNodeScence.Instance();
                AddChild(police);
            }
            else if (_batiment == HospitalNode.Bloc)
            {
                HospitalNode hopital = (HospitalNode) _hospitalNodeScene.Instance();
                AddChild(hopital);
            }
            
        }
    }
    
}
