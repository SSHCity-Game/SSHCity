using Godot.Collections;

namespace SshCity.Game.Sauvegarde
{
    public interface ISerializable
    {
        Dictionary<string, object> Save();
    }
}