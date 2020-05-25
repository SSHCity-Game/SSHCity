using Godot;
using System;

public class LevelUp : CanvasLayer
{

    private static TextureRect LevelUpBack;
    private static Label LevelUpText;
    private static Button Quitter;
    private static Sprite Croix;
    
    public override void _Ready()
    {
        LevelUpBack = GetNode<TextureRect>("LevelUpBack");
        LevelUpText = GetNode<Label>("LevelUpBack/LevelUpText");
        Quitter = GetNode<Button>("LevelUpBack/Quitter");
        Croix = GetNode<Sprite>("LevelUpBack/Quitter/Sprite");
        
        LevelUpBack.Hide();
        LevelUpText.Hide();
        Quitter.Hide();
        Croix.Hide();
        
        Quitter.Connect("pressed", this, nameof(ButtonQuitter));
    }

    public override void _Process(float delta)
    {
        if (Interface.levelup)
        {
            LevelUpBack.Show();
            LevelUpText.Text = "BRAVO \n Vous êtes maintenant niveau " + Interface._level;
            LevelUpText.Show();
            Quitter.Show();
            Croix.Show();
            Interface.levelup = false;
        }
    }
    
    private void ButtonQuitter()
    {
        Quitter.Hide();
        Croix.Hide();
        LevelUpBack.Hide();
        LevelUpText.Hide();
    }
}
