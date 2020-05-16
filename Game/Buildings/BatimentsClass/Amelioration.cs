using Godot;

namespace SshCity.Game.Buildings
{
    public partial class Batiments
    {
        public static (bool, int) Amelioration(Vector2 tile)
        {
            Building batimentToUpgrade = GetBuildingWithPosition(tile);
            if (batimentToUpgrade != null)
            {
                batimentToUpgrade.Upgrade();
                ListBuildings.Add(batimentToUpgrade);
                return (true, batimentToUpgrade.Bloc);
            }
            
            return (false, -1);
        }
    }
}