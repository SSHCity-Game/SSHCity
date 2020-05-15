using System;
using Godot;
using Godot.Collections;

namespace SshCity.Scenes.Plan
{
    public class Camion : Area2D
    {
        private const string _strAnimatedSprite = "AnimatedSprite";
        private const string _strCollsionShape2D = "CollisionShape2D";
        private AnimatedSprite _animatedSprite;
        private CollisionShape2D _collisionShape2D;
        private Vector2 _deplacement;
        private PlanInitial _planInitial;
        private Vector2 arrive;

        Dictionary<int, string> CamionAnimation = new Dictionary<int, string>()
        {
            {Ref_donnees.route_left, "NE"},
            {Ref_donnees.route_right, "SE"},
            {Ref_donnees.route_bord_haut_gauche, "NE"},
            {Ref_donnees.route_bord_haut_droit, "SE"},
            {Ref_donnees.route_bord_bas_gauche, "NW"},
            {Ref_donnees.route_bord_bas_droit, "SW"},
            {Ref_donnees.route_T_bas_droite, "SE"},
            {Ref_donnees.route_T_bas_gauche, "SW"},
            {Ref_donnees.route_T_haut_droit, "NE"},
            {Ref_donnees.route_T_haut_gauche, "NW"}
        };

        private Vector2 CamionDecallage = new Vector2(175, 150);

        Dictionary<string, Vector2> CamionDecallageDico = new Dictionary<string, Vector2>()
        {
            {"NE", new Vector2(100, 230)},
            {"NW", new Vector2(70, 220)},
            {"SE", new Vector2(-20, 150)},
            {"SW", new Vector2(175, 150)}
        };

        Dictionary<string, int> CollisionAngle = new Dictionary<string, int>()
        {
            {"NE", 27},
            {"NW", -27},
            {"SE", -27},
            {"SW", 27}
        };

        private Vehicules.Direction direction;
        private bool isMoving = false;

        public void Init(PlanInitial planInitial, Vector2 position)
        {
            _animatedSprite = (AnimatedSprite) GetNode(_strAnimatedSprite);
            _collisionShape2D = (CollisionShape2D) GetNode(_strCollsionShape2D);
            this._planInitial = planInitial;
            int blocRoute = planInitial.GetBlock(planInitial.TileMap2, (int) position.x, (int) position.y);
            _animatedSprite.Animation = CamionAnimation[blocRoute];
            CamionDecallage = CamionDecallageDico[_animatedSprite.Animation];
            _collisionShape2D.Rotation = CollisionAngle[_animatedSprite.Animation];
            Connect("body_entered", this, nameof(CollisionCamion));
            this.Position = planInitial.TileMap2.MapToWorld(position + new Vector2(1, 1)) + CamionDecallage;
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
                    _animatedSprite.Animation = para.anim;
                    CamionDecallage = CamionDecallageDico[_animatedSprite.Animation];
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
                    (direction == Vehicules.Direction.BOTTOM && this.Position <= arrive))
                {
                    Vector2 positionActuel = _planInitial.TileMap2.WorldToMap(this.Position);
                    Vector2 NextCase = Vehicules.DirectionToVector2(direction) + new Vector2(-1, -1);
                    if (Routes.IsRoute(_planInitial.GetBlock(_planInitial.TileMap2,
                            (int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y))
                        && !Routes.IsCroisement(_planInitial.GetBlock(_planInitial.TileMap2,
                            (int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y)))
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
                MovingDirection((Vehicules.Direction.BOTTOM, "SE"));
            }

            if (!isMoving && Input.IsActionPressed("ui_up"))
            {
                MovingDirection((Vehicules.Direction.TOP, "NW"));
            }

            this.Position += _deplacement * delta;
        }

        public void CollisionCamion()
        {
            this.Hide();
        }
    }
}