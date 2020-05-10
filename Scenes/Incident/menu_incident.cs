using Godot;
using System;
using SshCity.Scenes.Plan;

public class menu_incident : CanvasLayer
{
    public Button Boutique;
    public Button Resoudre;
    public Button Quitter;
    public TextureRect Background;
    public static Button Flamme;

    private Position2D alerte_position;
    
    public override void _Ready()
    {
        Boutique = (Button) GetNode("Boutique");
        Resoudre = (Button) GetNode("Resoudre");
        Quitter = (Button) GetNode("Quitter");
        Flamme = (Button) GetNode("Flamme");
        Background = (TextureRect) GetNode("Background");
        Boutique.Connect("pressed", this, nameof(on_boutique_pressed));
        Resoudre.Connect("pressed", this, nameof(on_resoudre_pressed));
        Quitter.Connect("pressed", this, nameof(on_quitter_pressed));
        Flamme.Connect("pressed", this, nameof(Resolution));
        //Background.Connect("pressed", this, nameof(Resolution));
        Boutique.Hide();
        Resoudre.Hide();
        Quitter.Hide();
        Background.Hide();
        Flamme.Hide();
    }

    public static void AlerteIncendie(Vector2 pos)
    {
        Flamme.SetPosition(pos);
        Flamme.Show();
    }
    
    
    public void Resolution()
    {
        Flamme.Hide();
        Background.Show();
        Boutique.Show();
        Resoudre.Show();
        Quitter.Show();
    }
    
    private void on_boutique_pressed()
    {
        Boutique.Hide();
        Resoudre.Hide();
        Quitter.Hide();
        Background.Hide();
        Flamme.Show();
    }

    private void on_resoudre_pressed()
    {
        Boutique.Hide();
        Resoudre.Hide();
        Quitter.Hide();
        Background.Hide();
        Flamme.Show();
    }

    private void on_quitter_pressed()
    {
        Boutique.Hide();
        Resoudre.Hide();
        Quitter.Hide();
        Background.Hide();
        Flamme.Show();
    }
}
