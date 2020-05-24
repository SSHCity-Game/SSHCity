using Godot;

public class MainMenu : CanvasLayer
{
    public TextureRect Background;
    public Button Connexion;
    public Button NewGame;
    public Button Options;
    public Label SSHCity;
    public CenterContainer CenterContainer;
    public CenterContainer Centertop;


    public override void _Ready()
    {
        Connexion = (Button) GetNode("Center/MenuOptions/Connexion");
        NewGame = (Button) GetNode("Center/MenuOptions/NewGame");
        Options = (Button) GetNode("Center/MenuOptions/Options");
        Background = (TextureRect) GetNode("Background");
        SSHCity = (Label) GetNode("CenterTitle/SSHCity");
        CenterContainer = (CenterContainer) GetNode("Center");
        Centertop = (CenterContainer) GetNode("CenterTitle");

        Connexion.Connect("pressed", this, nameof(menu_connexion));
        NewGame.Connect("pressed", this, nameof(new_game));
        Options.Connect("pressed", this, nameof(menu_options));

        AddUserSignal("game_started");
    }

    public void menu_connexion()
    {
        new_game();
    }

    public void new_game()
    {
        Connexion.Hide();
        NewGame.Hide();
        Options.Hide();
        Background.Hide();
        SSHCity.Hide();
        CenterContainer.Hide();
        Centertop.Hide();
        EmitSignal("game_started");
        Parametres._parametres.Show();
    }

    public void menu_options()
    {
    }
}