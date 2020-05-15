using Godot;

namespace SshCity.Scenes.Buildings
{
    public partial class Batiments
    {
        public static void Suppression(Vector2 tile)
        {
            GetBuildingWithPosition(tile);
        }
    }
}