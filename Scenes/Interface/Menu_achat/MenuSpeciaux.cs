using Godot;
using System;
using System.CodeDom;
using System.Collections.Generic;

public class MenuSpeciaux : Node
{
    private Menu_Achat _menu_achat;
    private Carte _cartePolice;
    private Carte _carteCentraleElectrique;
    
    private const string _str_menu_achat = "Menu_Achat";
    private const string _str_cartePolice = _str_menu_achat + "/Police";
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
        _cartePolice.Bloc = PoliceNode.Bloc;
        _cartePolice.Cost = PoliceNode.Cost;
        _cartePolice.Titre(PoliceNode.Titre);
        _cartePolice.Gain(PoliceNode.Earn);
        _cartePolice.Prix(PoliceNode.Cost);
        _cartePolice.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        
        //Config _carteCentraleElectrique
        _carteCentraleElectrique = (Carte) GetNode(_str_carteCentraleElectrique);
        _carteCentraleElectrique.Bloc = CentraleElectriqueNode.Bloc;
        _carteCentraleElectrique.Cost = CentraleElectriqueNode.Cost;
        _carteCentraleElectrique.Titre(CentraleElectriqueNode.Titre);
        _carteCentraleElectrique.Gain(CentraleElectriqueNode.Earn);
        _carteCentraleElectrique.Prix(CentraleElectriqueNode.Cost);
        _carteCentraleElectrique.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        
        
        _menu_achat.Hide();
        AddUserSignal("CloseShop");
        
        Carte[] menu1 = new[] {_cartePolice};
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