using Godot;
using System;
public class MenuEconomie : Node
{

    private Menu_Achat _menu_achat;
    private Carte _carteCafe;
    private Carte _carteRestaurant;
    private Carte _carteRestaurant2;
    
    
    private static bool _achat = false;

    public static bool Achat
    {
        get => _achat;
        set => _achat = value;
    }

    private const string _str_menu_achat = "Menu_Achat";
    private const string _str_carteCafe = "Menu_Achat/Cafe";
    private const string _str_carteRestaurant = _str_menu_achat + "/Restaurant";
    private const string _str_carteRestaurant2 = _str_menu_achat + "/Restaurant2";

    
    public override void _Ready()
    {
        _menu_achat = (Menu_Achat) GetNode(_str_menu_achat);

        //Config _carteCafe
        _carteCafe = (Carte) GetNode(_str_carteCafe);
        _carteCafe.Bloc = CafeNode.Bloc;
        _carteCafe.Cost = CafeNode.Cost;
        _carteCafe.Titre(CafeNode.Titre);
        _carteCafe.Gain(CafeNode.Earn);
        _carteCafe.Prix(CafeNode.Cost);
        _carteCafe.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        //Config _carteRestaurant
        _carteRestaurant = (Carte) GetNode(_str_carteRestaurant);
        _carteRestaurant.Bloc = RestaurantNode.Bloc;
        _carteRestaurant.Cost = RestaurantNode.Cost;
        _carteRestaurant.Titre(RestaurantNode.Titre);
        _carteRestaurant.Gain(RestaurantNode.Earn);
        _carteRestaurant.Prix(RestaurantNode.Cost);
        _carteRestaurant.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));
        
        //Config _carteRestaurant2
        _carteRestaurant2 = (Carte) GetNode(_str_carteRestaurant2);
        _carteRestaurant2.Bloc = Restaurant2Node.Bloc;
        _carteRestaurant2.Cost = Restaurant2Node.Cost;
        _carteRestaurant2.Titre(Restaurant2Node.Titre);
        _carteRestaurant2.Gain(Restaurant2Node.Earn);
        _carteRestaurant2.Prix(Restaurant2Node.Cost);
        _carteRestaurant2.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));
        
        _menu_achat.Connect("CloseShop", this, nameof(CloseShop));
        
        _menu_achat.Hide();
        AddUserSignal("CloseShop");
        
        Carte[] menu1 = new[] {_carteCafe, _carteRestaurant, _carteRestaurant2};
        Carte[][] menus = new[] {menu1};
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