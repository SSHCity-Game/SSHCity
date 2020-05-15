namespace SshCity.Game.Sauvegarde
{
    public interface ISauvegarde
    {
        /// <summary>
        /// Load a save to the tileMap
        /// </summary>
        void Load();

        /// <summary>
        /// Delete a save
        /// </summary>
        void Delete();

        /// <summary>
        /// Upload the save to the account
        /// </summary>
        void Upload();
    }
}