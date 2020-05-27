using System.Threading.Tasks;
using Godot;
using Godot.Collections;

public partial class Houloucoupter : Area2D
{
    public enum Type
    {
        HOPITAL
    }

    private const string _strAnimatedSprite = "AnimatedSprite";
    private const string _strCollsionShape2D = "CollisionShape2D";
    private AnimatedSprite _animatedSprite;
    private CollisionShape2D _collisionShape2D;
    private Vector2 _deplacement;
    private Vector2 _destination;
    private PlanInitial _planInitial;

    Dictionary<Type, SpriteFrames> AnimatedSpriteType =
        new Dictionary<Type, SpriteFrames>()
        {
            {
                Type.HOPITAL,
                ResourceLoader.Load("res://Game/Vehicules/AnimatedSpriteHouloucoupter/Hopital.tres") as SpriteFrames
            }
        };

    Dictionary<string, int> CollisionAngle = new Dictionary<string, int>()
    {
        {"NE", 60},
        {"NW", -60},
        {"SE", -60},
        {"SW", 60}
    };

    private Vector2 depart;
    private bool workDone = false;

    public async void Init(PlanInitial planInitial, Type type, Vector2 position, Vector2 destination)
    {
        if (wait)
        {
            await Task.Delay(3000);
            ok = true;
        }

        _animatedSprite = (AnimatedSprite) GetNode(_strAnimatedSprite);
        _collisionShape2D = (CollisionShape2D) GetNode(_strCollsionShape2D);
        this._planInitial = planInitial;
        SpriteFrames spriteFrames = AnimatedSpriteType[type];
        _animatedSprite.Frames = spriteFrames;
        _collisionShape2D.Rotation = CollisionAngle[_animatedSprite.Animation];
        Position = planInitial.TileMap2.MapToWorld(position);
        depart = Position;
        _deplacement = planInitial.TileMap2.MapToWorld(destination) - Position;
        _destination = planInitial.TileMap2.MapToWorld(destination);

        if (_destination.x >= Position.x && _destination.y >= Position.y)
        {
            _animatedSprite.Animation = "NE";
        }
        else if (_destination.x >= Position.x && _destination.y <= Position.y)
        {
            _animatedSprite.Animation = "NW";
        }
        else if (_destination.x <= Position.x && _destination.y <= Position.y)
        {
            _animatedSprite.Animation = "SW";
        }
        else if (_destination.x <= Position.x && _destination.y >= Position.y)
        {
            _animatedSprite.Animation = "SE";
        }
    }
}