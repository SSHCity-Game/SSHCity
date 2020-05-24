namespace SshCity.Game
{
    public class Player
    {
        public static Player CreateInstance()
        {
            return new Player();
        }

        public static Player ThePlayer;

        private Player()
        {
            ThePlayer ??= this;
        }
        
        public string GameId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}