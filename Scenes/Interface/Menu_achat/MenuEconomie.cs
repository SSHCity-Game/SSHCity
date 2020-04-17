using Godot;
using System;

public class MenuEconomie : Node
{

    private Menu_Achat _menu_achat;
    private Carte _carteMagasin;
    private static bool _achat = false;

    public static bool Achat
    {
        get => _achat;
        set => _achat = value;
    }

    private const string _str_menu_achat = "Menu_Achat";
    private const string _str_carteMagasin = "Menu_Achat/Magasin";

    
    public override void _Ready()
    {
        _menu_achat = (Menu_Achat) GetNode(_str_menu_achat);
        _carteMagasin = (Carte)GetNode(_str_carteMagasin);
        
        //Config _carteMaison
        
        //_carteMagasin.Bloc = MagasinNode.Bloc;
        //_carteMagasin.Titre(MagasinNode.Titre);
        _menu_achat.Connect("CloseShop", this, nameof(CloseShop));
        _carteMagasin.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));
        
        _menu_achat.Hide();
        AddUserSignal("CloseShop");
    }

    public void CloseMenuEconomie()
    {
        _menu_achat.Hide();
    }

    public void OpenMenuEconomie()
    {
        _menu_achat.Show();
    }
    public void CloseShop()
    {
        EmitSignal("CloseShop", false);
    }
}