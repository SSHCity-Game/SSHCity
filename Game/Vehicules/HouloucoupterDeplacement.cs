using Godot;

public partial class Houloucoupter
{

    private bool wait = false;
    private bool ok = false;
    public override void _Process(float delta)
    {
        base._Process(delta);
        
        if (!(_planInitial.TileMap2.WorldToMap(Position) == _planInitial.TileMap2.WorldToMap(_destination)
            || _planInitial.TileMap2.WorldToMap(Position) == _planInitial.TileMap2.WorldToMap(_destination) - new Vector2(1, 1)
            || _planInitial.TileMap2.WorldToMap(Position) == _planInitial.TileMap2.WorldToMap(_destination) - new Vector2(0, 1)
            || _planInitial.TileMap2.WorldToMap(Position) == _planInitial.TileMap2.WorldToMap(_destination) - new Vector2(1, 0)))
        {
            Position += _deplacement * delta/10;
        }
        else if(!workDone)
        {
            wait = true;
            incidents.ResoNoyade = true;
            Interface.Xp += 50;
            Init(_planInitial, Type.HOPITAL, _planInitial.TileMap2.WorldToMap(_destination), _planInitial.TileMap2.WorldToMap(depart));
            workDone = true;
        }
        else if (ok)
        {
            QueueFree();
        }
    }
}
