using Godot;
using System;
using System.Collections.Generic;
using SshCity.Game.Plan;

public class Bateau : Area2D
{
    private AnimatedSprite _animatedSprite2D;
    private Vector2 _deplacement;
    private Direction direction;
    private Vector2 arrive;
    private bool isMoving = false;
    private PlanInitial _planInitial;
    private Random rand = new Random();
    private const string _strAnimatedSprite2D = "AnimatedSprite";
    public enum Direction
    {
        RIGHT,
        TOP,
        LEFT,
        BOTTOM,
    }
        
    public static List<Direction> ListDirection = new List<Direction>()
    {
        {Direction.LEFT},
        {Direction.TOP},
        {Direction.BOTTOM},
        {Direction.RIGHT},
    };
    
    Godot.Collections.Dictionary<Direction, string> DirectionToAnim = new Godot.Collections.Dictionary<Direction, string>()
    {
        {Direction.TOP, "NW"},
        {Direction.BOTTOM, "SE"},
        {Direction.LEFT, "SW"},
        {Direction.RIGHT, "NE"}
    };
    
    /// <summary>
    /// Permet avec la direction du vehicule d'avoir le vecteur a ajouter par rapport à sa position pour aller sur le bloc suivant
    /// </summary>
    /// <param name="dir">Direction du vehicule</param>
    /// <returns>Le vecteur a ajouté pour aller sur le bloc suivant</returns>
    public Vector2 DirectionToVector2(Direction dir)
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

    public void Init(PlanInitial planInitial, Vector2 position)
    {
        _planInitial = planInitial;
        Position = position+ new Vector2(0, 20);
        isMoving = false;
    }
    
    public override void _Ready()
    {
        _animatedSprite2D = (AnimatedSprite) GetNode(_strAnimatedSprite2D);
            
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        if (isMoving && (direction == Direction.RIGHT && Position.x >= arrive.x) ||
            (direction == Direction.LEFT && Position.x <= arrive.x) ||
            (direction == Direction.TOP && Position.y <= arrive.y) ||
            (direction == Direction.BOTTOM && Position.y >= arrive.y))
        {
            isMoving = false;
            _deplacement = new Vector2(0, 0);
        }
        if (!isMoving)
        {
            Random random = new Random();
            int randNumber = random.Next(0, 4);
            Direction dir = ListDirection[randNumber];
            Vector2 posActuel = _planInitial.TileMap1.WorldToMap(Position);
            Vector2 next = DirectionToVector2(dir);
            Vector2 NextCase = posActuel + next;
            if (_planInitial.GetBlock(_planInitial.TileMap1, (int)NextCase.x+(int)next.x, (int)NextCase.y+(int)next.y) == Ref_donnees.water_terre)
            {
                direction = dir;
                _animatedSprite2D.Animation = DirectionToAnim[dir];
                _deplacement = _planInitial.TileMap1.MapToWorld(NextCase) - Position+ new Vector2(0, 25);
                arrive = _planInitial.TileMap1.MapToWorld(NextCase) + new Vector2(0, 25);
                isMoving = true; 
            }
        }
        Position += _deplacement * delta;
    }
}
