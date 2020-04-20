using Godot;
using System;
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
    private PackedScene _policeNodeScence;
    private PackedScene _hospitalNodeScene;
    private PackedScene _maison3NodeScene;

    private PackedScene _parkNodeScence;
    //private PackedScene;
    public string str_TileMap1 = "TileMap1";
    public string str_TileMap2 = "TileMap2";
    public string str_TileMap3 = "TileMap3";
    public string str_TileMap4 = "TileMap4";

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
        TileMap1 = (TileMap) GetNode(str_TileMap1);
        TileMap2 = (TileMap) GetNode(str_TileMap2);
        TileMap3 = (TileMap) GetNode(str_TileMap3);
        TileMap4 = (TileMap) GetNode(str_TileMap4);

        _maisonNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/MaisonNode.tscn");
        _caserNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/CaserneNode.tscn");
        _immeubleNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/ImmeubleNode.tscn");
        _policeNodeScence = (PackedScene) GD.Load("res://Scenes/Buildings/PoliceNode.tscn");
        _hospitalNodeScene = (PackedScene) GD.Load("res://Scenes/Buildings/HospitalNode.tscn");
        
        
        int[] batiments = new[]
        {
            Ref_donnees.maison1, Ref_donnees.maison4, Ref_donnees.ferme,
            Ref_donnees.maison3, Ref_donnees.mairie, Ref_donnees.maison5,
            Ref_donnees.eglise, Ref_donnees.shop, Ref_donnees.piscine
        };
        
        MaisonNode maison1 = (MaisonNode) _maisonNodeScene.Instance();
        AddChild(maison1);
        ImmeubleNode immeuble = (ImmeubleNode) _immeubleNodeScene.Instance();
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
            Vector2 tile = GetTilePosition();
            GD.Print(GetBlock(TileMap2, (int)tile.x, (int)tile.y));
            if (GetBlock(TileMap2, (int)tile.x, (int)tile.y) == _batiment)
            {
                if (GetBlock(TileMap1, (int)tile.x+1, (int)tile.y+1) == Ref_donnees.terre)
                {
                    AjoutNode(_batiment);
                }
                else
                {
                    SetBlock(TileMap2, (int)tile.x, (int)tile.y, -1);
                }
            }
            else
            {

            }
        }
    }
    
}
