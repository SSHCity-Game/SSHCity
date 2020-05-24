using Godot;

public class Boutique : CanvasLayer
{
    private const string _str_background = "Background";
    private const string _str_button_sante = _str_background + "/ButtonSante";
    private const string _str_button_habitation = _str_background + "/ButtonHabitation";
    private const string _str_button_economie = _str_background + "/ButtonEconomie";
    private const string _str_button_bien_etre = _str_background + "/ButtonBienEtre";
    private const string _str_button_speciaux = _str_background + "/ButtonSpeciaux";
    private const string _str_menuHabitation = _str_background + "/MenuHabitation";
    private const string _str_menuSante = _str_background + "/MenuSante";
    private const string _str_menuSpeciaux = _str_background + "/MenuSpeciaux";
    private const string _str_menuBienEtre = _str_background + "/MenuBienEtre";
    private const string _str_menuEconomie = _str_background + "/MenuEconomie";
    private Panel _background;
    private Button _button_bien_etre;
    private Button _button_economie;
    private Button _button_habitation;
    private Button _button_sante;
    private Button _button_speciaux;
    private MenuBienEtre _menuBienEtre;
    private MenuEconomie _menuEconomie;
    private MenuHabitation _menuHabitation;
    private MenuSante _menuSante;
    private MenuSpeciaux _menuSpeciaux;

    public override void _Ready()
    {
        _background = (Panel) GetNode(_str_background);
        _button_sante = (Button) GetNode(_str_button_sante);
        _button_economie = (Button) GetNode(_str_button_economie);
        _button_habitation = (Button) GetNode(_str_button_habitation);
        _button_speciaux = (Button) GetNode(_str_button_speciaux);
        _button_bien_etre = (Button) GetNode(_str_button_bien_etre);
        _menuHabitation = (MenuHabitation) GetNode(_str_menuHabitation);
        _menuSante = (MenuSante) GetNode(_str_menuSante);
        _menuSpeciaux = (MenuSpeciaux) GetNode(_str_menuSpeciaux);
        _menuBienEtre = (MenuBienEtre) GetNode(_str_menuBienEtre);
        _menuEconomie = (MenuEconomie) GetNode(_str_menuEconomie);

        _menuEconomie.Connect("CloseShop", this, nameof(ViewShop));
        _menuSante.Connect("CloseShop", this, nameof(ViewShop));
        _menuHabitation.Connect("CloseShop", this, nameof(ViewShop));
        _menuBienEtre.Connect("CloseShop", this, nameof(ViewShop));
        _menuSpeciaux.Connect("CloseShop", this, nameof(ViewShop));

        _background.Hide();
        _button_habitation.Connect("pressed", this, nameof(ButtonHabitationPressed));
        _button_economie.Connect("pressed", this, nameof(ButtonEconomiePressed));
        _button_bien_etre.Connect("pressed", this, nameof(ButtonBienEtrePressed));
        _button_speciaux.Connect("pressed", this, nameof(ButtonSpeciauxPressed));
        _button_sante.Connect("pressed", this, nameof(ButtonSantePressed));
    }

    public void ButtonHabitationPressed()
    {
        _button_bien_etre.Pressed = false;
        _button_economie.Pressed = false;
        _button_sante.Pressed = false;
        _button_speciaux.Pressed = false;
    }

    public void ButtonSantePressed()
    {
        _button_bien_etre.Pressed = false;
        _button_economie.Pressed = false;
        _button_habitation.Pressed = false;
        _button_speciaux.Pressed = false;
    }

    public void ButtonSpeciauxPressed()
    {
        _button_bien_etre.Pressed = false;
        _button_economie.Pressed = false;
        _button_sante.Pressed = false;
        _button_habitation.Pressed = false;
    }

    public void ButtonBienEtrePressed()
    {
        _button_economie.Pressed = false;
        _button_habitation.Pressed = false;
        _button_sante.Pressed = false;
        _button_speciaux.Pressed = false;
    }


    public void ButtonEconomiePressed()
    {
        _button_bien_etre.Pressed = false;
        _button_habitation.Pressed = false;
        _button_sante.Pressed = false;
        _button_speciaux.Pressed = false;
    }


    public void ViewShop(bool open)
    {
        if (open)
        {
            _background.Show();
            _menuSante.OpenMenuSante();
            _button_sante.Pressed = true;
        }
        else
        {
            _background.Hide();
            _menuHabitation.CloseMenuHabitation();
            _menuEconomie.CloseMenuEconomie();
            _menuSante.CloseMenuSante();
            _menuSpeciaux.CloseMenuSpeciaux();
            _menuBienEtre.CloseMenuBienEtre();
            _button_bien_etre.Pressed = false;
            _button_economie.Pressed = false;
            _button_habitation.Pressed = false;
            _button_sante.Pressed = false;
            _button_speciaux.Pressed = false;
            Menu_Achat.Reset1 = true;
            MenuSante._clignoCaserne.Hide();
            MenuSante._clignoHopital.Hide();
            MenuSpeciaux._clignoPolice.Hide();
            menu_incident.CaserneopenShop = false;
            menu_incident.HopitalopenShop = false;
            menu_incident.PoliceopenShop = false;
            menu_incident.OpenIncident = false;
        }
    }

    public override void _Process(float delta)
    {
        if (menu_incident.OpenIncident) // ferme la boutique si appui sur incident
            ViewShop(false);

        if (menu_incident.CaserneopenShop) // ouvre le shop et fait clignoter la caserne
        {
            MenuSante._clignoCaserne.Show();
            _button_sante.Pressed = true;
            ViewShop(true);
        }
        else if (menu_incident.PoliceopenShop) // ouvre le shop et fait clignoter le commissariat
        {
            MenuSpeciaux._clignoPolice.Show();
            _button_speciaux.Pressed = true;
            ViewShop(true);
        }
        else if (menu_incident.HopitalopenShop) // ouvre le shop et fait clignoter l'hopital
        {
            MenuSante._clignoHopital.Show();
            _button_sante.Pressed = true;
            ViewShop(true);
        }
        else
        
        {
            MenuSante._clignoCaserne.Hide();
            MenuSante._clignoHopital.Hide();
            MenuSpeciaux._clignoPolice.Hide();
        }

        if (_button_habitation.Pressed)
        {
            _menuHabitation.OpenMenuHabitation();
        }
        else
        {
            _menuHabitation.CloseMenuHabitation();
        }

        if (_button_sante.Pressed)
        {
            _menuSante.OpenMenuSante();
        }
        else
        {
            _menuSante.CloseMenuSante();
        }

        if (_button_speciaux.Pressed)
        {
            _menuSpeciaux.OpenMenuSpeciaux();
        }
        else
        {
            _menuSpeciaux.CloseMenuSpeciaux();
        }

        if (_button_bien_etre.Pressed)
        {
            _menuBienEtre.OpenMenuBienEtre();
        }
        else
        {
            _menuBienEtre.CloseMenuBienEtre();
        }

        if (_button_economie.Pressed)
        {
            _menuEconomie.OpenMenuEconomie();
        }
        else
        {
            _menuEconomie.CloseMenuEconomie();
        }
    }
}