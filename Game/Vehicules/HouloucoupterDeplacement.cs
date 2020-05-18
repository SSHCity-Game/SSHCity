using Godot;

public partial class Houloucoupter
{
    public override void _Process(float delta)
    {
        base._Process(delta);
        if (arrive(Position, _destination))
        {
            GD.Print("VITE");
            Position += _deplacement * delta;
        }
    }
}
