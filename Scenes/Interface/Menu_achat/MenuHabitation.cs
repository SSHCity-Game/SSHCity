using Godot;
using System;

public class MenuHabitation : Node
{
    private Menu_Achat _menu_achat;
    private Carte _carteMaison;

    private const string _str_menu_achat = "Menu_Achat";
    private const string _str_carteMaison = _str_menu_achat + "/Maison";
    
    private static bool _achat = false;

    public static bool Achat
    {
        get => _achat;
        set => _achat = value;
    }


    public override void _Ready()
    {
        //Config _carteMaison
        _carteMaison = (Carte) GetNode(_str_carteMaison);
        _carteMaison.Bloc = MaisonNode.Bloc;
        _carteMaison.Titre(MaisonNode.Titre);
        _carteMaison.Gain(MaisonNode.Earn);
        _carteMaison.Prix(MaisonNode.Cost);
        
        _carteMaison.Connect("Achat", this, nameof(Menu_Achat.AchatBatiment));
        
        _menu_achat = (Menu_Achat) GetNode(_str_menu_achat);
        _menu_achat.Hide();
        AddUserSignal("CloseShop");
    }
    public void CloseMenuHabitation()
    {
        _menu_achat.Hide();
    }

    public void OpenMenuHabitation()
    {
        _menu_achat.Show();
    }
    
}