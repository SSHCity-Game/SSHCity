using Godot;
using System;
using System.Security.Cryptography.X509Certificates;
using SshCity.Scenes.Buildings.BatimentsCaracteristiques;

public class MenuHabitation : Node
{
    private Menu_Achat _menu_achat;
    private Carte _carteMaison;
    private Carte _carteMaison3;
    private Carte _carteMaison4;
    private Carte _carteMaison5;

    private const string _str_menu_achat = "Menu_Achat";
    private const string _str_carteMaison = _str_menu_achat + "/Maison";
    private const string _str_carteMaison3 = _str_menu_achat + "/Maison2";
    private const string _str_carteMaison4 = _str_menu_achat + "/Maison3";
    private const string _str_carteMaison5 = _str_menu_achat + "/Maison5";
    
    private static bool _achat = false;
    private static Carte[][] menu;

    public static Carte[][] Menu
    {
        get => menu;
        set => menu = value;
    }

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
        _carteMaison.Bloc = Maison._bloc[0];
        _carteMaison.Cost = Maison._cost[0];
        _carteMaison.Titre(Maison._titre[0]);
        _carteMaison.Gain(Maison._earn[0]);
        _carteMaison.Prix(Maison._cost[0]);
        
        _carteMaison.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        
        //Config _carteMaison3
        _carteMaison3 = (Carte) GetNode(_str_carteMaison3);
        _carteMaison3.Bloc = Maison3._bloc[0];
        _carteMaison3.Cost = Maison3._cost[0];
        _carteMaison3.Titre(Maison3._titre[0]);
        _carteMaison3.Gain(Maison3._earn[0]);
        _carteMaison3.Prix(Maison3._cost[0]);
        _carteMaison3.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        //Config _carteMaison4
        _carteMaison4 = (Carte) GetNode(_str_carteMaison4);
        _carteMaison4.Bloc = Maison4._bloc[0];
        _carteMaison4.Cost = Maison4._cost[0];
        _carteMaison4.Titre(Maison4._titre[0]);
        _carteMaison4.Gain(Maison4._earn[0]);
        _carteMaison4.Prix(Maison4._cost[0]);
        _carteMaison4.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        //Config _carteMaison5
        _carteMaison5 = (Carte) GetNode(_str_carteMaison5);
        _carteMaison5.Bloc = Maison5._bloc[0];
        _carteMaison5.Cost = Maison5._cost[0];
        _carteMaison5.Titre(Maison5._titre[0]);
        _carteMaison5.Gain(Maison5._earn[0]);
        _carteMaison5.Prix(Maison5._cost[0]);
        _carteMaison5.Hide();
        _carteMaison5.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));
        
        _menu_achat.Hide();
        AddUserSignal("CloseShop");

        Carte[] menu1 = new[] {_carteMaison, _carteMaison3, _carteMaison4};
        Carte[] menu2 = new[] {_carteMaison5};
        Carte[][] menus = new[] {menu1, menu2};
        _menu_achat.Menus = menus;
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