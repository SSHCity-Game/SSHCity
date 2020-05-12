using Godot;
using System;
using SshCity.Scenes.Plan;

public class menu_incident : CanvasLayer
{
    public Button Boutique;
    public Button Resoudre;
    public Button Quitter;
    public static Button Flamme;
    public TextureRect Background;

    
    public override void _Ready()
    {
        Boutique = (Button) GetNode("Boutique");
        Resoudre = (Button) GetNode("Resoudre");
        Quitter = (Button) GetNode("Quitter");
        Flamme = (Button) GetNode("Flamme");
        Background = (TextureRect) GetNode("Background");

        Boutique.Hide();
        Resoudre.Hide();
        Quitter.Hide();
        Flamme.Hide();
        Background.Hide();

        Boutique.Connect("pressed", this, nameof(on_boutique_pressed));
        Resoudre.Connect("pressed", this, nameof(on_resoudre_pressed));
        Quitter.Connect("pressed", this, nameof(on_quitter_pressed));
        Flamme.Connect("pressed", this, nameof(Resolution));
        
    }
    
    private void on_boutique_pressed()
    {
        Boutique.Hide();
        Resoudre.Hide();
        Quitter.Hide();
        Background.Hide();
        Interface.OpenShop = true;
    }

    public void Resolution()
    {
        Boutique.Show();
        Resoudre.Show();
        Quitter.Show();
        Background.Show();
    }
    public static void AlerteIncendie()
    {
        Flamme.Show();
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
