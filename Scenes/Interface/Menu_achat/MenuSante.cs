using Godot;
using System;

public class MenuSante : Node
{
    private Carte _carteHopital;
    private Menu_Achat _menu_achat;
    private Carte _carteCaserne;
    public static TextureRect _cligno;
    
    private const string _str_menu_achat = "Menu_Achat";
    private const string _str_carteHopital = _str_menu_achat + "/Hopital";
    private const string _str_carteCaserne = _str_menu_achat + "/Caserne";
    
    private static bool _achat = false;
    public static bool cligno = false;
    
    public static bool Achat
    {
        get => _achat;
        set => _achat = value;
    }

    public static bool Cligno
    {
        get => cligno;
        set => cligno = value;
    }
    
    public override void _Ready()
    {
        _menu_achat = (Menu_Achat) GetNode(_str_menu_achat);
        _menu_achat.Connect("CloseShop", this, nameof(CloseShop));

        //Config _carteHopital
        _carteHopital = (Carte) GetNode(_str_carteHopital);
        _carteHopital.Bloc = Hospital._bloc[0];
        _carteHopital.Cost = Hospital._cost[0];
        _carteHopital.Titre(Hospital._titre[0]);
        _carteHopital.Gain(Hospital._earn[0]);
        _carteHopital.Prix(Hospital._cost[0]);
        _carteHopital.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));
        
        //Config _carteCaserne
        _carteCaserne = (Carte) GetNode(_str_carteCaserne);
        _carteCaserne.Bloc = Caserne._bloc[0];
        _carteCaserne.Cost = Caserne._cost[0];
        _carteCaserne.Titre(Caserne._titre[0]);
        _carteCaserne.Gain(Caserne._earn[0]);
        _carteCaserne.Prix(Caserne._cost[0]);
        _carteCaserne.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        /* Fond clignotant quand besoin du batiment*/
        _cligno = (TextureRect) GetNode(_str_carteCaserne + "/Background/Cligno");
        _cligno.Hide();
        
        _menu_achat.Hide();
        AddUserSignal("CloseShop");
        
        Carte[] menu1 = new[] {_carteHopital, _carteCaserne};
        Carte[][] menus = new[] {menu1};
        _menu_achat.Menus = menus;
    }
    

    public void CloseMenuSante()
    {
        _menu_achat.Hide();
    }

    public void OpenMenuSante()
    {
        _menu_achat.Show();
    }
    public void CloseShop()
    {
        EmitSignal("CloseShop", false);
    }
}
