using System;
using Godot;

namespace SshCity.Scenes.Plan
{
    public class Camion : AnimatedSprite
    {

        private PlanInitial _planInitial;
        private bool isMoving = false;
        private Vector2 _deplacement;
        private Vector2 arrive;
        private Vehicules.Direction direction;
        private Vector2 CamionDecallage = new Vector2(100, 230);

        public void Init(PlanInitial planInitial)
        {
            this._planInitial = planInitial;
            this.Position = _planInitial.TileMap2.MapToWorld(new Vector2(20, 0))+CamionDecallage;
        }
        
        public override void _Ready()
        {
            base._Ready();
            this.Animation = "NE";
        }

        public override void _Process(float delta)
        {
            base._Process(delta);
            Action<Vehicules.Direction> MovingDirection = direction1 =>
        {
            Vector2 positionActuel = _planInitial.TileMap2.WorldToMap(this.Position);
            Vector2 NextCase = Vehicules.DirectionToVector2(direction1)+new Vector2(-1, -1);
            if (Routes.IsRoute(_planInitial.GetBlock(_planInitial.TileMap2, (int)positionActuel.x+(int)NextCase.x, (int)positionActuel.y+(int)NextCase.y)))
            {
                isMoving = true;
                Vector2 nextBlock = positionActuel + Vehicules.DirectionToVector2(direction1);
                _deplacement = (_planInitial.TileMap2.MapToWorld(nextBlock) +CamionDecallage)- this.Position ;
                arrive = _planInitial.TileMap2.MapToWorld(nextBlock) + CamionDecallage;
                direction = direction1;
            }
        };

        if (isMoving)
        {
            if ((direction == Vehicules.Direction.RIGHT && this.Position >= arrive) ||
                (direction == Vehicules.Direction.LEFT && this.Position <= arrive))
            {
                Vector2 positionActuel = _planInitial.TileMap2.WorldToMap(this.Position);
                Vector2 NextCase = Vehicules.DirectionToVector2(direction)+new Vector2(-1, -1);
                if (Routes.IsRoute(_planInitial.GetBlock(_planInitial.TileMap2, (int)positionActuel.x+(int)NextCase.x, (int)positionActuel.y+(int)NextCase.y))
                && !Routes.IsCroisement(_planInitial.GetBlock(_planInitial.TileMap2, (int)positionActuel.x+(int)NextCase.x, (int)positionActuel.y+(int)NextCase.y)))
                {
                    Vector2 nextBlock = positionActuel + Vehicules.DirectionToVector2(direction);
                    _deplacement = (_planInitial.TileMap2.MapToWorld(nextBlock) + CamionDecallage) - this.Position; 
                    arrive = _planInitial.TileMap2.MapToWorld(nextBlock) + CamionDecallage;
                }
                else
                {
                    isMoving = false;
                    _deplacement = new Vector2(0, 0);
                }
            }
        }

        if (!isMoving && Input.IsActionPressed("ui_right"))
        {
            this.Animation = "NE";
            MovingDirection(Vehicules.Direction.RIGHT);
        }

        if (!isMoving && Input.IsActionPressed("ui_left"))
        {
            this.Animation = "SW";
            MovingDirection(Vehicules.Direction.LEFT);
        }

        if (!isMoving && Input.IsActionPressed("ui_down"))
        {
            this.Animation = "SE";
            MovingDirection(Vehicules.Direction.BOT);
        }

        if (!isMoving && Input.IsActionPressed("ui_up"))
        {
            this.Animation = "NW";
            MovingDirection(Vehicules.Direction.TOP);
        }

        this.Position += _deplacement * delta;
        }
    }
}