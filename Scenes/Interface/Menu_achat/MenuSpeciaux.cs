using Godot;
using System;

public class MenuSpeciaux : Node
{
    private Menu_Achat _menu_achat;
    private Carte _carteMairie;
    
    private const string _str_menu_achat = "Menu_Achat";
    private const string _str_carteMairie = _str_menu_achat + "/Mairie";
    
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
        
        //Config _carteMairie
        _carteMairie = (Carte) GetNode(_str_carteMairie);
        /*
        _carteMairie.Bloc = MairieNode.Bloc;
        _carteMairie.Cost = MairieNode.Cost;
        _carteMairie.Titre(MairieNode.Titre);
        _carteMairie.Gain(MairieNode.Earn);
        _carteMairie.Prix(MairieNode.Cost);
        */
        
        _carteMairie.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));
        
        _menu_achat.Hide();
        AddUserSignal("CloseShop");
        
        Carte[] menu1 = new[] {_carteMairie};
        Carte[][] menus = new[] {menu1};
        _menu_achat.Menus = menus;
    }

    public void CloseMenuSpeciaux()
    {
        _menu_achat.Hide();
    }

    public void OpenMenuSpeciaux()
    {
        _menu_achat.Show();
    }
    
    public void CloseShop()
    {
        EmitSignal("CloseShop", false);
    }
}