using Godot;
using System;

public class MenuHabitation : Node
{
    private Menu_Achat _menu_achat;
    private Carte _carteMaison;
    private Carte _carteMaison3;
    private Carte _carteMaison4;

    private const string _str_menu_achat = "Menu_Achat";
    private const string _str_carteMaison = _str_menu_achat + "/Maison";
    private const string _str_carteMaison3 = _str_menu_achat + "/Maison2";
    private const string _str_carteMaison4 = _str_menu_achat + "/Maison3";
    
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

        
        //Config _carteMaison
        _carteMaison = (Carte) GetNode(_str_carteMaison);
        _carteMaison.Bloc = MaisonNode.Bloc;
        _carteMaison.Cost = MaisonNode.Cost;
        _carteMaison.Titre(MaisonNode.Titre);
        _carteMaison.Gain(MaisonNode.Earn);
        _carteMaison.Prix(MaisonNode.Cost);
        
        _carteMaison.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        
        //Config _carteMaison3
        _carteMaison3 = (Carte) GetNode(_str_carteMaison3);
        _carteMaison3.Bloc = Maison3Node.Bloc;
        _carteMaison3.Cost = Maison3Node.Cost;
        _carteMaison3.Titre(Maison3Node.Titre);
        _carteMaison3.Gain(Maison3Node.Earn);
        _carteMaison3.Prix(Maison3Node.Cost);
        _carteMaison3.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        //Config _carteMaison4
        _carteMaison4 = (Carte) GetNode(_str_carteMaison4);
        _carteMaison4.Bloc = Maison4Node.Bloc;
        _carteMaison4.Cost = Maison4Node.Cost;
        _carteMaison4.Titre(Maison4Node.Titre);
        _carteMaison4.Gain(Maison4Node.Earn);
        _carteMaison4.Prix(Maison4Node.Cost);
        _carteMaison4.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

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
    public void CloseShop()
    {
        EmitSignal("CloseShop", false);
    }
}