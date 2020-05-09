using Godot;
using System;
using SshCity.Scenes.Plan;

public class menu_incident : Control
{
    public static Button Boutique;
    public static Button Resoudre;
    public static Button Quitter;
    public static TextureRect Background;

    private Position2D alerte_position;
    
    
    public override void _Ready()
    {
        Boutique = (Button) GetNode("Boutique");
        Resoudre = (Button) GetNode("Resoudre");
        Quitter = (Button) GetNode("Quitter");
        Background = (TextureRect) GetNode("Background");
        Boutique.Connect("pressed", this, nameof(on_boutique_pressed));
        Resoudre.Connect("pressed", this, nameof(on_resoudre_pressed));
        Quitter.Connect("pressed", this, nameof(on_quitter_pressed));
        //Background.Connect("pressed", this, nameof(Resolution));
        Boutique.Hide();
        Resoudre.Hide();
        Quitter.Hide();
        Background.Hide();
    }

    private void on_boutique_pressed()
    {
        Boutique.Hide();
        Resoudre.Hide();
        Quitter.Hide();
        Background.Hide();
    }

    private void on_resoudre_pressed()
    {
        Boutique.Hide();
        Resoudre.Hide();
        Quitter.Hide();
        Background.Hide();
    }

    private void on_quitter_pressed()
    {
        Boutique.Hide();
        Resoudre.Hide();
        Quitter.Hide();
        Background.Hide();
    }
    
    
    
    
}
