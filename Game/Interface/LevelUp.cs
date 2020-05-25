using Godot;
using System;
using System.Threading.Tasks;

public class LevelUp : CanvasLayer
{

    private static TextureRect LevelUpBack;
    private static Label LevelUpText;
    
    public override void _Ready()
    {
        LevelUpBack = GetNode<TextureRect>("LevelUpBack");
        LevelUpText = GetNode<Label>("LevelUpText");
        
        LevelUpBack.Hide();
        LevelUpText.Hide();
    }

    public override void _Process(float delta)
    {
        if (Interface.levelup)
        {
            LevelUpBack.Show();
            LevelUpText.Text = "BRAVO \n Vous êtes maintenant niveau " + Interface._level;
            LevelUpText.Show();
            Interface.levelup = false;
            Hide();
        }
    }

    public async void Hide()
    {
        await Task.Delay(5000);
        LevelUpBack.Hide();
        LevelUpText.Hide();
    }
}
