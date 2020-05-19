using System;
using Godot;

public class Carte : Panel
{
    private const string _str_sprite = "Background/Image";
    private const string _str_button_achat = "ButtonAchat";
    private const string _str_titre = "Titre";
    private const string _str_gain = "Gain";
    private const string _str_prix = "Prix";
    private const string _str_energie = "Energie";
    private const string _str_eau = "Eau";
    private int _bloc = 1;
    private Button _buttonAchat;
    private int _cost;
    private Label _gain;
    private Label _prix;
    private Sprite _sprite;
    private Label _titre;
    private Label _energie;
    private Label _eau;

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
        _energie = (Label) GetNode(_str_energie);
        _eau = (Label) GetNode(_str_eau);

        AddUserSignal("Achat");
    }

    public void ButtonAchatPressed()
    {
        EmitSignal("Achat", _bloc, _cost, _energie, _eau);
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

    public void Enrgie(string energie)
    {
        _energie.Text = energie;
    }

    public void Eau(string eau)
    {
        _eau.Text = eau;
    }

    public void ButtonOver()
    {
    }

    public void ButtonExited()
    {
    }
}