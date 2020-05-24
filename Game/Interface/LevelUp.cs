using Godot;
using System;

public class LevelUp : CanvasLayer
{

    private static TextureRect LevelUpBack;
    private static Label LevelUpText;
    private static Button Quitter;
    
    public override void _Ready()
    {
        LevelUpBack = GetNode<TextureRect>("LevelUpBack");
        LevelUpText = GetNode<Label>("LevelUpBack/LevelUpText");
        Quitter = GetNode<Button>("LevelUpBack/Quitter");
        
        LevelUpBack.Hide();
        LevelUpText.Hide();
        Quitter.Hide();
        
        Quitter.Connect("pressed", this, nameof(ButtonQuitter));
    }

    public override void _Process(float delta)
    {
        if (Interface.levelup)
        {
            LevelUpBack.Show();
            LevelUpText.Text = "BRAVO \n Vous etes maintenant niveau " + Interface._level;
            LevelUpText.Show();
            Quitter.Show();
            Interface.levelup = false;
        }
    }
    
    private void ButtonQuitter()
    {
        Quitter.Hide();
        LevelUpBack.Hide();
        LevelUpText.Hide();
    }
}
