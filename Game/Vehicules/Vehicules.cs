using System;
using Godot;

namespace SshCity.Game.Plan
{
    public class Vehicules
    {
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
    }
}