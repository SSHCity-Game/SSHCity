using Godot;
using System;

public class Boutique : CanvasLayer
{
    private Panel _background;
    private Label _title;
    private Button _button_sante;
    private Button _button_habitation;
    private Button _button_economie;
    private Button _button_bien_etre;
    private Button _button_speciaux;
    private MenuHabitation _menuHabitation;

    private const string _str_background = "Background";
    private const string _str_title = _str_background + "/Title";
    private const string _str_button_sante = _str_background + "/ButtonSante";
    private const string _str_button_habitation = _str_background + "/ButtonHabitation";
    private const string _str_button_economie = _str_background + "/ButtonEconomie";
    private const string _str_button_bien_etre = _str_background + "/ButtonBienEtre";
    private const string _str_button_speciaux = _str_background + "/ButtonSpeciaux";
    private const string _str_menuHabitation = _str_background + "/MenuHabitation";

    public override void _Ready()
    {
        _background = (Panel) GetNode(_str_background);
        _title = (Label) GetNode(_str_title);
        _button_sante = (Button) GetNode(_str_button_sante);
        _button_economie = (Button) GetNode(_str_button_economie);
        _button_habitation = (Button) GetNode(_str_button_habitation);
        _button_speciaux = (Button) GetNode(_str_button_speciaux);
        _button_bien_etre = (Button) GetNode(_str_button_bien_etre);
        _menuHabitation = (MenuHabitation) GetNode(_str_menuHabitation);
        _background.Hide();
        _button_habitation.Connect("pressed", this, nameof(ButtonHabitationPressed));
    }

    public void ButtonHabitationPressed()
    {
        _button_bien_etre.Pressed = false;
        _button_economie.Pressed = false;
        _button_sante.Pressed = false;
        _button_speciaux.Pressed = false;
    }


    public void ViewShop(bool open)
    {
        if (open)
        {
            _background.Show();
        }
        else
        {
            _background.Hide();
            _menuHabitation.CloseMenuHabitation();
        }
    }

    public override void _Process(float delta)
    {
        if (_button_habitation.Pressed)
        {
            _menuHabitation.OpenMenuHabitation();
        }
        else
        {
            _menuHabitation.CloseMenuHabitation();
        }
    }
}
