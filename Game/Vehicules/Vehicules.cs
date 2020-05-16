using System;
using Godot;
using Godot.Collections;

namespace SshCity.Game.Vehicules
{
    public partial class Vehicules: Area2D
    {
        private const string _strAnimatedSprite = "AnimatedSprite";
        private const string _strCollsionShape2D = "CollisionShape2D";
        private AnimatedSprite _animatedSprite;
        private CollisionShape2D _collisionShape2D;
        private Vector2 _deplacement;
        private PlanInitial _planInitial;
        private Vector2 arrive;
        public enum Direction
        {
            TOP,
            LEFT,
            BOTTOM,
            RIGHT
        }

        public enum Type
        {
            CAMION,
            AMBULANCE
        }

        public static Vector2 DirectionToVector2(Direction dir)
        {
            return dir switch
            {
                Direction.BOTTOM => new Vector2(0, 1),
                Direction.TOP => new Vector2(0, -1),
                Direction.LEFT => new Vector2(-1, 0),
                Direction.RIGHT => new Vector2(1, 0),
                _ => throw new ArgumentException()
            };
        }
        
        //Choisis l'animation du vehicule (son orientation) par rapport à a la route au depart
        Dictionary<int, string> WhichAnimation = new Dictionary<int, string>()
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
            {Ref_donnees.route_T_haut_gauche, "NW"},
            {-1, "NE"}
        };
        
        private Vector2 Decallage = new Vector2(175, 150);

        Dictionary<string, Vector2> DecallageDico = new Dictionary<string, Vector2>()
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
        
        Dictionary<Type, SpriteFrames> AnimatedSpriteType = new Dictionary<Type, SpriteFrames>()
        {
            {Type.AMBULANCE, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/Ambulance_animatedSprite.tres") as SpriteFrames},
            {Type.CAMION, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/Camion_animatedSprite.tres") as SpriteFrames}
        };
        
        private Direction direction;
        private bool isMoving = false;

        public void Init(PlanInitial planInitial, Vector2 position, Type type)
        {
            _animatedSprite = (AnimatedSprite) GetNode(_strAnimatedSprite);
            _collisionShape2D = (CollisionShape2D) GetNode(_strCollsionShape2D);
            this._planInitial = planInitial;
            SpriteFrames spriteFrames = AnimatedSpriteType[type];
            _animatedSprite.Frames = spriteFrames;
            int blocRoute = planInitial.GetBlock(planInitial.TileMap2, (int) position.x, (int) position.y);
            _animatedSprite.Animation = WhichAnimation[blocRoute];
            Decallage = DecallageDico[_animatedSprite.Animation];
            _collisionShape2D.Rotation = CollisionAngle[_animatedSprite.Animation];
            Connect("body_entered", this, nameof(CollisionCamion));
            this.Position = planInitial.TileMap2.MapToWorld(position + new Vector2(1, 1)) + Decallage;
        }
    }
}