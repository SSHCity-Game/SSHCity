using Godot;
using System;

public class MenuBienEtre : Node
{
    private Carte _carteParc;
    private Menu_Achat _menu_achat;

    private const string _str_menu_achat = "Menu_Achat";
    private const string _str_carteParc = _str_menu_achat + "/Parc";
    
    private static bool _achat = false;

    public static bool Achat
    {
        get => _achat;
        set => _achat = value;
    }
    public override void _Ready()
    {
        _carteParc = (Carte) GetNode(_str_carteParc);
        _carteParc.Connect("Achat", this, nameof(AchatBatiment));
        _menu_achat = (Menu_Achat) GetNode(_str_menu_achat);
        _menu_achat.Hide();
        AddUserSignal("CloseShop");
    }
    
    public void AchatBatiment(string typebatiment)
    {
        EmitSignal("CloseShop", false);
        _achat = true;
    }
    
    public void CloseMenuBienEtre()
    {
        _menu_achat.Hide();
    }

    public void OpenMenuBienEtre()
    {
        _menu_achat.Show();
    }
}

