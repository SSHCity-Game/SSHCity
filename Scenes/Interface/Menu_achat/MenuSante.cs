using Godot;
using System;

public class MenuSante : Node
{
    private Carte _carteHopital;
    private Menu_Achat _menu_achat;

    private const string _str_menu_achat = "Menu_Achat";
    private const string _str_carteHopital = _str_menu_achat + "/Hopital";
    
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

        //Config _carteHopital
        _carteHopital = (Carte) GetNode(_str_carteHopital);
        //_carteHopital.Bloc = HopitalNode.Block;
        //_carteHopital.Titre(HopitalNode.Titre);
        _carteHopital.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));
        

        _menu_achat.Hide();
        AddUserSignal("CloseShop");
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
