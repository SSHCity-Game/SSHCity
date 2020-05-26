using Godot;

public class MainMenu : CanvasLayer
{
    public static TextureRect Background;
    public static Button Connexion;
    public static Button NewGame;
    public static Button Options;
    public static Label SSHCity;
    public static CenterContainer CenterContainer;
    public static CenterContainer Centertop;

    public static bool options = false;

    public override void _Ready()
    {
        Connexion = (Button) GetNode("Center/MenuOptions/Connexion");
        NewGame = (Button) GetNode("Center/MenuOptions/NewGame");
        Options = (Button) GetNode("Center/MenuOptions/Options");
        Background = (TextureRect) GetNode("Background");
        SSHCity = (Label) GetNode("CenterTitle/SSHCity");
        CenterContainer = (CenterContainer) GetNode("Center");
        Centertop = (CenterContainer) GetNode("CenterTitle");
        
        Connexion.Connect("pressed", this, nameof(load_game));
        NewGame.Connect("pressed", this, nameof(new_game));
        Options.Connect("pressed", this, nameof(menu_options));

        AddUserSignal("game_started");
    }

    public void HideAll()
    {
        Connexion.Hide();
        NewGame.Hide();
        Options.Hide();
        Background.Hide();
        SSHCity.Hide();
        CenterContainer.Hide();
        Centertop.Hide();
    }

    public static void ShowAll()
    {
        Connexion.Show();
        NewGame.Show();
        Options.Show();
        Background.Show();
        SSHCity.Show();
        CenterContainer.Show();
        Centertop.Show();
    }

    public void menu_connexion()
    {
        new_game();
    }

    public void new_game()
    {
        MainPlan._planInitial.Show();
        Interface.Start();
        HideAll();
        EmitSignal("game_started");
        Parametres._parametres.Show();
        MainPlan.NewGame();
    }
    public void load_game()
    {
        if (MainPlan.LoadGame())
        {
            MainPlan._planInitial.Show();
            Interface.Start();
            HideAll();
            EmitSignal("game_started");
            Parametres._parametres.Show();
        }
    }

    public void menu_options()
    {
        Options.Pressed = false;
        HideAll();
        options = true;
        Parametres.param_pressed();
    }
}