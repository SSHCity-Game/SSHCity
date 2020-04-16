using Godot;
using System;
using System.Security.Principal;

public class Carte : Panel
{
    private Button _buttonAchat;
    private Label _titre;
    private string _typeBatiment;
    private const string _str_button_achat = "ButtonAchat";
    private const string _str_titre = "Titre";
    
    public override void _Ready()
    {
        _buttonAchat = (Button) GetNode(_str_button_achat);
        _buttonAchat.Connect("pressed", this, nameof(ButtonAchatPressed));
        _titre = (Label) GetNode(_str_titre);
        _typeBatiment = _titre.Text;

        AddUserSignal("Achat");
    }

    public void ButtonAchatPressed()
    {
        GD.Print("OKKKY");
        EmitSignal("Achat");
    }
}
