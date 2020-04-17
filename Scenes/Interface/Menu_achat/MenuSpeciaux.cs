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
        _carteMairie = (Carte) GetNode(_str_carteMairie);
        _carteMairie.Connect("Achat", this, nameof(AchatBatiment));
        _menu_achat = (Menu_Achat) GetNode(_str_menu_achat);
        _menu_achat.Hide();
        AddUserSignal("CloseShop");
    }
    
    public void AchatBatiment(string typebatiment)
    {
        EmitSignal("CloseShop", false);
        _achat = true;
    }

    public void CloseMenuSpeciaux()
    {
        _menu_achat.Hide();
    }

    public void OpenMenuSpeciaux()
    {
        _menu_achat.Show();
    }
    
}