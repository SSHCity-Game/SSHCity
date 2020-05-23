using Godot;

public partial class Houloucoupter
{
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
            workDone = true;
            incidents.ResoNoyade = true;
            Init(_planInitial, Type.HOPITAL, _planInitial.TileMap2.WorldToMap(_destination), _planInitial.TileMap2.WorldToMap(depart));
        }
        else
        {
            QueueFree();
        }
    }
}
