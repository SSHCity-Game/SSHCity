using Godot;
using System;
using System.Security.Principal;

public class Carte : Panel
{
    private Button _buttonAchat;
    private Button _buttonInfo;
    private Label _titre;
    private string _typeBatiment;
    private const string _str_button_achat = "ButtonAchat";
    private const string _str_button_info = "ButtonInfo";
    private const string _str_titre = "Titre";
    
    public override void _Ready()
    {
        _buttonAchat = (Button) GetNode(_str_button_achat);
        _buttonInfo = (Button) GetNode(_str_button_info);
        _buttonAchat.Connect("pressed", this, nameof(ButtonAchatPressed));
        _titre = (Label) GetNode(_str_titre);
        _typeBatiment = _titre.Text;
    }

    public void ButtonInfoPressed()
    {
        EmitSignal("Info"+_typeBatiment);
    }
    public void ButtonAchatPressed()
    {
        EmitSignal("Achat"+_typeBatiment);
    }
}
