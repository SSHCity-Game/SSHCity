using Godot;

namespace SshCity
{
    public class Player : Node2D
    {
        private Vector2 _screenSize; // Size of the game window.

        // Declare member variables here. Examples:
        // private int a = 2;
        // private string b = "text";
        [Export] public int Speed = 400; // How fast the player will move (pixels/sec).

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            _screenSize = GetViewport().Size;
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(float delta)
        {
            var velocity = new Vector2(); // The player's movement vector.

            if (Input.IsActionPressed("ui_right"))
                velocity.x += 1;

            if (Input.IsActionPressed("ui_left"))
                velocity.x -= 1;

            if (Input.IsActionPressed("ui_down"))
                velocity.y += 1;

            if (Input.IsActionPressed("ui_up"))
                velocity.y -= 1;

            if (velocity.Length() > 0)
                velocity = velocity.Normalized() * 500;

            Position += velocity * delta;
            Position = new Vector2(
                Mathf.Clamp(Position.x, 0, _screenSize.x),
                Mathf.Clamp(Position.y, 0, _screenSize.y)
            );
        }
    }
}