using Godot;
using System;

public class Interface : CanvasLayer
{
    private Panel _money_couleur;
    private Label _money_text;
    private int _money = 50000;

    public int Money
    {
        get => _money;
        set => _money = value;
    }

    private const string str_money_couleur = "Money_couleur";
    private const string str_money_text = "Money_couleur/Money_text";
    
    public override void _Ready()
    {
        _money_couleur = (Panel) GetNode(str_money_couleur);
        _money_text = (Label) GetNode(str_money_text);
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        _money_text.Text = Convert.ToString(_money);
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}

