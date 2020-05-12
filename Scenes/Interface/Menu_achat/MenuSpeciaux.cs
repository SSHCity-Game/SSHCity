using Godot;
using System;
using System.CodeDom;
using System.Collections.Generic;
using SshCity.Scenes.Buildings.BatimentsCaracteristiques;

public class MenuSpeciaux : Node
{
    private Menu_Achat _menu_achat;
    private Carte _cartePolice;
    private Carte _carteCentraleElectrique;
    private Carte _carteEglise;
    
    private const string _str_menu_achat = "Menu_Achat";
    private const string _str_cartePolice = _str_menu_achat + "/Police";
    private const string _str_carteEglise = _str_menu_achat + "/Eglise";
    private const string _str_carteCentraleElectrique = _str_menu_achat + "/CentraleElectrique";
    
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
        

        //Config _cartePolice
        _cartePolice = (Carte) GetNode(_str_cartePolice);
        _cartePolice.Bloc = Police._bloc[0];
        _cartePolice.Cost = Police._cost[0];
        _cartePolice.Titre(Police._titre[0]);
        _cartePolice.Gain(Police._earn[0]);
        _cartePolice.Prix(Police._cost[0]);
        _cartePolice.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        
        //Config _carteCentraleElectrique
        _carteCentraleElectrique = (Carte) GetNode(_str_carteCentraleElectrique);
        _carteCentraleElectrique.Bloc = CentraleElectrique._bloc[0];
        _carteCentraleElectrique.Cost = CentraleElectrique._cost[0];
        _carteCentraleElectrique.Titre(CentraleElectrique._titre[0]);
        _carteCentraleElectrique.Gain(CentraleElectrique._earn[0]);
        _carteCentraleElectrique.Prix(CentraleElectrique._cost[0]);
        _carteCentraleElectrique.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));
        
        //Config _carteEglise
        
        _carteEglise = (Carte) GetNode(_str_carteEglise);
        _carteEglise.Bloc = Eglise._bloc[0];
        _carteEglise.Cost = Eglise._cost[0];
        _carteEglise.Titre(Eglise._titre[0]);
        _carteEglise.Gain(Eglise._earn[0]);
        _carteEglise.Prix(Eglise._cost[0]);
        _carteEglise.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        
        _menu_achat.Hide();
        AddUserSignal("CloseShop");
        
        Carte[] menu1 = new[] {_cartePolice, _carteCentraleElectrique, _carteEglise};
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