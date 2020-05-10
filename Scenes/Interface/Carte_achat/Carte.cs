using Godot;
using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Principal;

public class Carte : Panel
{
    private Button _buttonAchat;
    private Sprite _sprite;
    private Label _titre;
    private Label _gain;
    private Label _prix;
    private const string _str_sprite = "Background/Image";
    private const string _str_button_achat = "ButtonAchat";
    private const string _str_titre = "Titre";
    private const string _str_gain = "Gain";
    private const string _str_prix = "Prix";
    private int _bloc = 1;
    private int _cost;

    public int Cost
    {
        get => _cost;
        set => _cost = value;
    }

    public int Bloc
    {
        get => _bloc;
        set => _bloc = value;
    }
    
    public override void _Ready()
    {
        _buttonAchat = (Button) GetNode(_str_button_achat);
        _buttonAchat.Connect("pressed", this, nameof(ButtonAchatPressed));
        _buttonAchat.Connect("mouse_entered", this, nameof(ButtonOver));
        _buttonAchat.Connect("mouse_exited", this, nameof(ButtonExited));

        _titre = (Label) GetNode(_str_titre);
        _sprite = (Sprite) GetNode(_str_sprite);
        _prix = (Label) GetNode(_str_prix);
        _gain = (Label) GetNode(_str_gain);

        AddUserSignal("Achat");
    }

    public void ButtonAchatPressed()
    {
        EmitSignal("Achat", _bloc, _cost);
    }

    public void Titre(string titre)
    {
        _titre.Text = titre;
    }

    public void Prix(int prix)
    {
        _prix.Text = Convert.ToString(prix);
    }

    public void Gain(int gain)
    {
        _gain.Text = Convert.ToString(gain);
    }

    public void ButtonOver()
    {
        
    }

    public void ButtonExited()
    {
        
    }
}
