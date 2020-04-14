using Godot;
using System;

public class Interface : CanvasLayer
{
    private Panel _money_couleur;
    private Label _money_text;

    private const string str_money_couleur = "Money_couleur";
    private const string str_money_text = "Money_couleur/Money_text";
    
    public override void _Ready()
    {
        _money_couleur = (Panel) GetNode(str_money_couleur);
        _money_text = (Label) GetNode(str_money_text);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
