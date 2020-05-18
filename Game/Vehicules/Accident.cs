using Godot;
using System;

public class Accident : Area2D
{
    private bool _mouseIn = false;
    private PlanInitial _planInitial;
    private Sprite _sprite;
    private const string _strSprite = "Sprite";

    public override void _Ready()
    {
        
        Connect("mouse_entered", this, nameof(MouseEntered));
        Connect("mouse_exited", this, nameof(MouseExited));
        Connect("area_exited", this, nameof(AreaExited));
    }

    public void AreaExited(Area2D area2D)
    {
        if (area2D.CollisionMask == 3)
        {
            GD.Print("DELETE");
            QueueFree();
        }
    }

    public void MouseEntered()
    {
        _mouseIn = true;
    }
    public void MouseExited()
    {
        _mouseIn = false;
    }

    public override void _Input(InputEvent OneAction)
    {
        base._Input(OneAction);
        if (OneAction.IsActionPressed("ClickG") && _mouseIn )
        {
            Vector2 position = _planInitial.TileMap2.WorldToMap(GetGlobalMousePosition());
            _planInitial.SetBlock(_planInitial.TileMap3, (int)position.x, (int)position.y, -1);
            GD.Print("querefree");
            this.QueueFree();
        }
    }

    public void Init(PlanInitial planInitial, bool visi)
    {
        _planInitial = planInitial;
        _sprite = (Sprite) GetNode(_strSprite);
        _sprite.Visible = visi;
    }
}
