using Godot;
using System;

public class PlanInitial : Node2D
{
    public static Vector2 PositionTile = new Vector2(0,0);
    public TileMap TileMap1;
    public TileMap TileMap2;
    public TileMap TileMap3;
    public TileMap TileMap4;
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
        TileMap1 = (TileMap) GetNode("Navigation2D/TileMap1");
        TileMap2 = (TileMap) GetNode("Navigation2D/TileMap2");
        TileMap3 = (TileMap) GetNode("Navigation2D/TileMap3");
        TileMap4 = (TileMap) GetNode("Navigation2D/TileMap4");
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
        if (OneAction is InputEventMouse && (MenuEconomie.Achat|| MenuSante.Achat || MenuHabitation.Achat || MenuSpeciaux.Achat || MenuBienEtre.Achat))
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

        if (OneAction is InputEventMouseButton && (MenuEconomie.Achat|| MenuSante.Achat || MenuHabitation.Achat || MenuSpeciaux.Achat || MenuBienEtre.Achat))
        {
            MenuEconomie.Achat = false;
            MenuHabitation.Achat = false;
            MenuSante.Achat = false;
            MenuSpeciaux.Achat = false;
            MenuBienEtre.Achat = false;
            _lastTile = new Vector2(0,0);
            Interface.Money -= _prix;
        }
    }
    
}
