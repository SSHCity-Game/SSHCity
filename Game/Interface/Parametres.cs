using Godot;
using System;
using SshCity.Game;

public class Parametres : CanvasLayer
{
    public static Button _parametres;
    private static TextureRect _background;
    private static Label _login;
    private static Button _gamePlay;
    private static Label _effetsSonores;
    private static Label _musique;
    private static CheckButton _checkEffet;
    private static CheckButton _checkMusique;
    private static Button _quitter;
    private static Sprite _croix;

    private static bool musique = true;
    public static bool effets = true;
    
    public override void _Ready()
    {
        _parametres = GetNode<Button>("Parametres");
        _background = GetNode<TextureRect>("back");
        _login = GetNode<Label>("back/login");
        _gamePlay = GetNode<Button>("back/GamePlay");
        _effetsSonores = GetNode<Label>("back/EffetSonore");
        _musique = GetNode<Label>("back/Musique");
        _checkEffet = GetNode<CheckButton>("back/EffetSonore/CheckButton");
        _checkMusique = GetNode<CheckButton>("back/Musique/CheckButton");
        _quitter = GetNode<Button>("back/Quitter");
        _croix = GetNode<Sprite>("back/Quitter/Sprite");

        _login.Text = "username";
        HideAll();
        _parametres.Hide();
        
        _parametres.Connect("pressed", this, nameof(param_pressed));
        _gamePlay.Connect("pressed", this, nameof(gameplay_pressed));
        _quitter.Connect("pressed", this, nameof(quitter_pressed));
        _checkEffet.Connect("pressed", this, nameof(effet_pressed));
        _checkMusique.Connect("pressed", this, nameof(musique_pressed));
    }

    private void HideAll()
    {
        _background.Hide();
        _quitter.Hide();
        _croix.Hide();
        _login.Hide();
        _gamePlay.Hide();
        _effetsSonores.Hide();
        _musique.Hide();
        _checkEffet.Hide();
        _checkMusique.Hide();
    }

    public static void param_pressed()
    {
        _background.Show();
        _quitter.Show();
        _croix.Show();
        _login.Text = Player.ThePlayer.Username;
        _login.Show();
        _gamePlay.Show();
        _effetsSonores.Show();
        _musique.Show();
        _checkEffet.Show();
        _checkMusique.Show();
    }

    private void gameplay_pressed()
    {
        HideAll();
    }

    private void quitter_pressed()
    {
        HideAll();
        if (MainMenu.options)
            MainMenu.ShowAll();
        MainMenu.options = false;
    }

    private void effet_pressed()
    {
        effets = !effets;
    }

    private void musique_pressed()
    {
        musique = !musique;
        if(!musique)
            MainPlan._musique.Stop();
        else
            MainPlan._musique.Play();
    }
}
