using Godot;
using System;

public class alertes : Control
{
    
    private static Button Flamme;
    
    public override void _Ready()
    {
        Flamme = (Button) GetNode("Flamme");
        Flamme.Connect("pressed", this, nameof(Resolution));
        Flamme.Hide();
    }
    
    public static void AlerteIncendie(Vector2 pos)
    {
        Flamme.SetPosition(pos);
        Flamme.Show();
    }
    
    
    public void Resolution()
    {
        menu_incident.Background.Show();
        menu_incident.Boutique.Show();
        menu_incident.Resoudre.Show();
        menu_incident.Quitter.Show();
    }
}
