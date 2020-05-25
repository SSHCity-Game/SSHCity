using Godot;
using SshCity.Game.Buildings;

public class MenuSpeciaux : Node
{
    private const string _str_menu_achat = "Menu_Achat";
    private const string _str_cartePolice = _str_menu_achat + "/Police";
    private const string _str_carteEglise = _str_menu_achat + "/Eglise";
    private const string _str_carteCentraleElectrique = _str_menu_achat + "/CentraleElectrique";
    private const string _str_carteEpuration = _str_menu_achat + "/Epuration";
    private const string _str_carteMosque = _str_menu_achat + "/Mosque";
    public static TextureRect _clignoPolice;

    public static bool clignoPolice = false;
    private static bool _achat = false;
    private Carte _carteCentraleElectrique;
    private Carte _carteEpuration;
    private Carte _carteEglise;
    private Carte _cartePolice;
    private Carte _carteMosque;
    private Menu_Achat _menu_achat;
    public override void _Ready()
    {
        _menu_achat = (Menu_Achat) GetNode(_str_menu_achat);
        _menu_achat.Connect("CloseShop", this, nameof(CloseShop));


        //Config _cartePolice
        _cartePolice = (Carte) GetNode(_str_cartePolice);
        var police = BuildingCharacteristics.FromType(BuildingType.POLICE);
        _cartePolice.Bloc = police.Bloc[0];
        _cartePolice.Cost = police.Cost[0];
        _cartePolice.Titre(police.Titre[0]);
        _cartePolice.Gain(police.Earn[0]);
        _cartePolice.Prix(police.Cost[0]);
        _cartePolice.Enrgie(police.energy[0].ToString());
        _cartePolice.Eau(police.water[0].ToString());
        _cartePolice.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));


        //Config _carteCentraleElectrique
        _carteCentraleElectrique = (Carte) GetNode(_str_carteCentraleElectrique);
        var centrale = BuildingCharacteristics.FromType(BuildingType.CENTRALE);
        _carteCentraleElectrique.Bloc = centrale.Bloc[0];
        _carteCentraleElectrique.Cost = centrale.Cost[0];
        _carteCentraleElectrique.Titre(centrale.Titre[0]);
        _carteCentraleElectrique.Gain(centrale.Earn[0]);
        _carteCentraleElectrique.Prix(centrale.Cost[0]);
        _carteCentraleElectrique.Enrgie(centrale.energy[0].ToString());
        _carteCentraleElectrique.Eau(centrale.water[0].ToString());
        _carteCentraleElectrique.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        //config 
        
        _carteEpuration = (Carte) GetNode(_str_carteEpuration);
        var epur = BuildingCharacteristics.FromType(BuildingType.EPURATION);
        _carteEpuration.Bloc = epur.Bloc[0];
        _carteEpuration.Cost = epur.Cost[0];
        _carteEpuration.Titre(epur.Titre[0]);
        _carteEpuration.Gain(epur.Earn[0]);
        _carteEpuration.Prix(epur.Cost[0]);
        _carteEpuration.Enrgie(epur.energy[0].ToString());
        _carteEpuration.Eau(epur.water[0].ToString());
        _carteEpuration.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        //Config _carteEglise

        _carteEglise = (Carte) GetNode(_str_carteEglise);
        var eglise = BuildingCharacteristics.FromType(BuildingType.EGLISE);
        _carteEglise.Bloc = eglise.Bloc[0];
        _carteEglise.Cost = eglise.Cost[0];
        _carteEglise.Titre(eglise.Titre[0]);
        _carteEglise.Gain(eglise.Earn[0]);
        _carteEglise.Prix(eglise.Cost[0]);
        _carteEglise.Enrgie(eglise.energy[0].ToString());
        _carteEglise.Eau(eglise.water[0].ToString());
        _carteEglise.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));
        
        //config _carteMosque
        
        _carteMosque = (Carte) GetNode(_str_carteMosque);
        var mosque = BuildingCharacteristics.FromType(BuildingType.MOSQUE);
        _carteMosque.Bloc = mosque.Bloc[0];
        _carteMosque.Cost = mosque.Cost[0];
        _carteMosque.Titre(mosque.Titre[0]);
        _carteMosque.Gain(mosque.Earn[0]);
        _carteMosque.Prix(mosque.Cost[0]);
        _carteMosque.Enrgie(mosque.energy[0].ToString());
        _carteMosque.Eau(mosque.water[0].ToString());
        _carteMosque.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        /* Fond clignotant quand besoin du batiment*/
        _clignoPolice = (TextureRect) GetNode(_str_cartePolice + "/Background/Cligno");
        _clignoPolice.Hide();
        
        _menu_achat.Hide();
        AddUserSignal("CloseShop");

        Carte[] menu1 = new[] {_cartePolice, _carteCentraleElectrique,_carteEpuration };
        Carte[] menu2 = {_carteEglise, _carteMosque};
        Carte[][] menus = {menu1, menu2};
        _menu_achat.Menus = menus;
    }

    public void Reset()
    {
        Carte[] menu1 = new[] {_cartePolice, _carteCentraleElectrique,_carteEpuration };
        Carte[] menu2 = {_carteEglise, _carteMosque};
        _carteEglise.Hide();
        _carteMosque.Hide();
        Carte[][] menus = {menu1, menu2};
        _menu_achat.Menus = menus;
        if (Menu_Achat.WhichMenu <= menus.Length)
        {
            _menu_achat.Reset();
        }
        else
        {
            Menu_Achat.WhichMenu = 0;
        }    
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