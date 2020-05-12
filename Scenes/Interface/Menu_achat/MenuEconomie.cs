using Godot;
using System;
using SshCity.Scenes.Buildings.BatimentsCaracteristiques;

public class MenuEconomie : Node
{

    private Menu_Achat _menu_achat;
    private Carte _carteCafe;
    private Carte _carteRestaurant;
    private Carte _carteRestaurant2;
    private Carte _carteFerme;

    private const string _str_menu_achat = "Menu_Achat";
    private const string _str_carteCafe = "Menu_Achat/Cafe";
    private const string _str_carteRestaurant = _str_menu_achat + "/Restaurant";
    private const string _str_carteRestaurant2 = _str_menu_achat + "/Restaurant2";
    private const string _str_carteFerme = _str_menu_achat + "/Ferme";


    
    public override void _Ready()
    {
        _menu_achat = (Menu_Achat) GetNode(_str_menu_achat);

        //Config _carteCafe
        _carteCafe = (Carte) GetNode(_str_carteCafe);
        _carteCafe.Bloc = Cafe._bloc[0];
        _carteCafe.Cost = Cafe._cost[0];
        _carteCafe.Titre(Cafe._titre[0]);
        _carteCafe.Gain(Cafe._earn[0]);
        _carteCafe.Prix(Cafe._cost[0]);
        _carteCafe.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        //Config _carteRestaurant
        _carteRestaurant = (Carte) GetNode(_str_carteRestaurant);
        _carteRestaurant.Bloc = Restaurant._bloc[0];
        _carteRestaurant.Cost = Restaurant._cost[0];
        _carteRestaurant.Titre(Restaurant._titre[0]);
        _carteRestaurant.Gain(Restaurant._earn[0]);
        _carteRestaurant.Prix(Restaurant._cost[0]);
        _carteRestaurant.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));
        
        //Config _carteRestaurant2
        _carteRestaurant2 = (Carte) GetNode(_str_carteRestaurant2);
        _carteRestaurant2.Bloc = Restaurant2._bloc[0];
        _carteRestaurant2.Cost = Restaurant2._cost[0];
        _carteRestaurant2.Titre(Restaurant2._titre[0]);
        _carteRestaurant2.Gain(Restaurant2._earn[0]);
        _carteRestaurant2.Prix(Restaurant2._cost[0]);
        _carteRestaurant2.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));
        
        //Config _carteFerme
        _carteFerme = (Carte) GetNode(_str_carteFerme);
        _carteFerme.Bloc = Ferme._bloc[0];
        _carteFerme.Cost = Ferme._cost[0];
        _carteFerme.Titre(Ferme._titre[0]);
        _carteFerme.Gain(Ferme._earn[0]);
        _carteFerme.Prix(Ferme._cost[0]);
        _carteFerme.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        _menu_achat.Connect("CloseShop", this, nameof(CloseShop));
        
        _menu_achat.Hide();
        AddUserSignal("CloseShop");
        
        Carte[] menu1 = new[] {_carteCafe, _carteRestaurant, _carteRestaurant2};
        Carte[] menu2 = new[] {_carteFerme};
        Carte[][] menus = new[] {menu1, menu2};
        _menu_achat.Menus = menus;
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