using Godot;
using System;

public class MainMenu : CanvasLayer
{
    public Button Connexion;
    public Button NewGame;
    public Button Options;
    public TextureRect Background;
    public Label SSHCity;
    
    /* Permet l'utilisation des methodes non static dans methode static */

    public override void _Ready()
    {
        Connexion = (Button) GetNode("Center/MenuOptions/Connexion");
        NewGame = (Button) GetNode("Center/MenuOptions/NewGame");
        Options = (Button) GetNode("Center/MenuOptions/Options");
        Background = (TextureRect) GetNode("Background");
        SSHCity = (Label) GetNode("CenterTitle/SSHCity");

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
        EmitSignal("game_started");
    }
    public void menu_options()
    {
        
    }
}
