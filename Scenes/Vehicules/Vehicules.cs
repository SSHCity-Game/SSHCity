using Godot;

namespace SshCity.Scenes.Plan
{
    public class Vehicules
    {
        public enum Direction
        {
            TOP,
            LEFT,
            BOT,
            RIGHT
        }

        public enum Type
        {
            CAMION,
            AMBULANCE
        }

        public static Vector2 DirectionToVector2(Direction dir)
        {
            Vector2 res;
            switch (dir)
            {
                case Direction.TOP:
                {
                    res = new Vector2(0, -1);
                    break;
                }
                case Direction.BOT:
                {
                    res = new Vector2(0, 1);
                    break;
                }
                case Direction.RIGHT:
                {
                    res = new Vector2(1, 0);
                    break;
                }
                default:
                {
                    res = new Vector2(-1, 0);
                    break;
                }
            }

            return res;
        }
    }
}