using Godot.Collections;

namespace SshCity.Scenes.Sauvegarde
{
    public interface ISerializable
    {
        Dictionary<string, object> Save();
    }
}