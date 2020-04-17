using Godot;
using System;
using System.Security;
using System.Security.Principal;

public class Carte : Panel
{
    private Button _buttonAchat;
    private Label _titre;
    private const string _str_button_achat = "ButtonAchat";
    private const string _str_titre = "Titre";
    private int _bloc = 1;

    public int Bloc
    {
        get => Bloc;
        set => Bloc = value;
    }
    
    public override void _Ready()
    {
        _buttonAchat = (Button) GetNode(_str_button_achat);
        _buttonAchat.Connect("pressed", this, nameof(ButtonAchatPressed));
        _titre = (Label) GetNode(_str_titre);

        AddUserSignal("Achat");
    }

    public void ButtonAchatPressed()
    {
        EmitSignal("Achat", _bloc);
    }

    public void Titre(string titre)
    {
        _titre.Text = titre;
    }
}
