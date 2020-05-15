using System;
using Godot;
using Godot.Collections;

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

        public void Init(PlanInitial planInitial, Vector2 position)
        {
            this._planInitial = planInitial;
            this.Position = planInitial.TileMap2.MapToWorld(position + new Vector2(1, 1));
        }
        
        public override void _Ready()
        {
            base._Ready();
            this.Animation = "NE";
        }

        public override void _Process(float delta)
        {
            base._Process(delta);
            Action<(Vehicules.Direction direction1, string anim)> MovingDirection = para =>
            {
                //CamionDecallage = CamionDecallageDico[para.anim];
                Vector2 positionActuel = _planInitial.TileMap2.WorldToMap(this.Position);
                Vector2 NextCase = Vehicules.DirectionToVector2(para.direction1) + new Vector2(-1, -1);
                if (Routes.IsRoute(_planInitial.GetBlock(_planInitial.TileMap2,
                    (int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y)))
                {
                    Animation = para.anim;
                    isMoving = true;
                    Vector2 nextBlock = positionActuel + Vehicules.DirectionToVector2(para.direction1);
                    _deplacement = (_planInitial.TileMap2.MapToWorld(nextBlock) + CamionDecallage) - this.Position;
                    arrive = _planInitial.TileMap2.MapToWorld(nextBlock) + CamionDecallage;
                    direction = para.direction1;
                }
            };

        if (isMoving)
        {
            if ((direction == Vehicules.Direction.RIGHT && this.Position >= arrive) ||
                (direction == Vehicules.Direction.LEFT && this.Position <= arrive) ||
                (direction == Vehicules.Direction.TOP && this.Position >= arrive) ||
                 (direction == Vehicules.Direction.BOT && this.Position <= arrive))
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
            MovingDirection((Vehicules.Direction.RIGHT, "NE"));
        }

        if (!isMoving && Input.IsActionPressed("ui_left"))
        {
            MovingDirection((Vehicules.Direction.LEFT, "SW"));
        }

        if (!isMoving && Input.IsActionPressed("ui_down"))
        {
            MovingDirection((Vehicules.Direction.BOT, "SE"));
        }

        if (!isMoving && Input.IsActionPressed("ui_up"))
        {
            MovingDirection((Vehicules.Direction.TOP, "NW"));
        }

        this.Position += _deplacement * delta;
        }
        
        Dictionary<string, Vector2> CamionDecallageDico = new Dictionary<string, Vector2>()
        {
            {"NE", new Vector2(100, 230)},
            {"NW", new Vector2()}, 
            {"SE", new Vector2()}, 
            {"SW", new Vector2()}
        };
        /*
        Dictionary<int, string> CamionAnimation = new Dictionary<int, string>()
        {
            {Ref_donnees.route_left, "NE"},
            {"NW", new Vector2()}, 
            {"SE", new Vector2()}, 
            {"SW", new Vector2()}
        };*/
    }
}