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
        _menu_achat = (Menu_Achat) GetNode(_str_menu_achat);
        _menu_achat.Connect("CloseShop", this, nameof(CloseShop));
        
        //Config _carteParc
        _carteParc = (Carte) GetNode(_str_carteParc);
        /*
        _carteParc.Bloc = ParcNode.Bloc;
        _carteParc.Cost = ParcNode.Cost;
        _carteParc.Titre(ParcNode.Titre);
        _carteParc.Gain(ParcNode.Earn);
        _carteParc.Prix(ParcNode.Cost);
        */
        _carteParc.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));
        

        _menu_achat.Hide();
        AddUserSignal("CloseShop");
        
        Carte[] menu1 = new[] {_carteParc};
        Carte[][] menus = new[] {menu1};
        _menu_achat.Menus = menus;
    }

    public void CloseMenuBienEtre()
    {
        _menu_achat.Hide();
    }

    public void OpenMenuBienEtre()
    {
        _menu_achat.Show();
    }

    public void CloseShop()
    {
        EmitSignal("CloseShop", false);
    }
}

