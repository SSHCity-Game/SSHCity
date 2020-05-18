using Godot;
using System;
using System.Collections.Generic;

public partial class Houloucoupter : Area2D
{
    private PlanInitial _planInitial;
    private AnimatedSprite _animatedSprite;
    private CollisionShape2D _collisionShape2D;
    private Vector2 _deplacement;
    private Func<Vector2, Vector2, bool> arrive;
    private Vector2 _destination;

    private const string _strAnimatedSprite = "AnimatedSprite";
    private const string _strCollsionShape2D = "CollisionShape2D";
    public enum Type
    {
        HOPITAL
    }

    Godot.Collections.Dictionary<string, int> CollisionAngle = new Godot.Collections.Dictionary<string, int>()
    {
        {"NE", 27},
        {"NW", -27},
        {"SE", -27},
        {"SW", 27}
    };

    Godot.Collections.Dictionary<Type, SpriteFrames> AnimatedSpriteType = new Godot.Collections.Dictionary<Type, SpriteFrames>()
    {
        {Type.HOPITAL, ResourceLoader.Load("res://Game/Vehicules/AnimatedSpriteHouloucoupter/Hopital.tres") as SpriteFrames},
    };
    
    public static List<Type> ListTypeHouloucoupter = new List<Type>()
    {
        {Type.HOPITAL},
    };

    public void Init(PlanInitial planInitial, Type type, Vector2 position, Vector2 destination)
    {
        _animatedSprite = (AnimatedSprite) GetNode(_strAnimatedSprite);
        _collisionShape2D = (CollisionShape2D) GetNode(_strCollsionShape2D);
        this._planInitial = planInitial;
        SpriteFrames spriteFrames = AnimatedSpriteType[type];
        _animatedSprite.Frames = spriteFrames;
        int blocRoute = planInitial.GetBlock(planInitial.TileMap2, (int) position.x, (int) position.y);
        _collisionShape2D.Rotation =  CollisionAngle[_animatedSprite.Animation];
        this.Connect("area_entered", this, nameof(Collision));
        this.Position = position;
        _deplacement = destination - Position;
        _destination = destination;
        
        if (_deplacement.x >= Position.x && _deplacement.y >= Position.y)
        {
            _animatedSprite.Animation = "NE";
            arrive = (vector2, vector3) => Position.x >= destination.x;
        }
        else if(_deplacement.x >= Position.x && _deplacement.y <= Position.y)
        {
            _animatedSprite.Animation = "NW";
            arrive = (vector2, vector3) => Position.y <= destination.y;
        }
        else if(_deplacement.x <= Position.x && _deplacement.y <= Position.y)
        {
            _animatedSprite.Animation = "SE";
            arrive = (vector2, vector3) => Position.x <= destination.x;
        }
        else if(_deplacement.x <= Position.x && _deplacement.y >= Position.y)
        {
            _animatedSprite.Animation = "SW";
            arrive = (vector2, vector3) => Position.y >= destination.y;
        }
    }
    
    public void Collision(Area2D area2D)
    {
        
    }

}
