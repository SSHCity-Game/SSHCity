using Godot;
using SshCity.Game.Buildings;

public class MenuBienEtre : Node
{
    private const string _str_menu_achat = "Menu_Achat";
    private const string _str_carteParc = _str_menu_achat + "/Parc";
    private const string _str_carteFoot = _str_menu_achat + "/Foot";
    private const string _str_carteZoo = _str_menu_achat + "/Zoo";
    private const string _str_carteFeteForraine = _str_menu_achat + "/FeteForraine";
    private const string _str_carteBasket = _str_menu_achat + "/Basket";
    private Carte _carteBasket;
    private Carte _carteFeteForraine;
    private Carte _carteFoot;

    private Carte _carteParc;
    private Carte _carteZoo;
    private Menu_Achat _menu_achat;

    public static bool Achat { get; set; } = false;

    public override void _Ready()
    {
        _menu_achat = (Menu_Achat) GetNode(_str_menu_achat);
        _menu_achat.Connect("CloseShop", this, nameof(CloseShop));

        //Config _carteParc
        _carteParc = (Carte) GetNode(_str_carteParc);
        var parc = BuildingCharacteristics.FromType(BuildingType.PARC);
        _carteParc.Bloc = parc.Bloc[0];
        _carteParc.Cost = parc.Cost[0];
        _carteParc.Titre(parc.Titre[0]);
        _carteParc.Gain(parc.Earn[0]);
        _carteParc.Prix(parc.Cost[0]);
        _carteParc.Enrgie(parc.energy[0].ToString());
        _carteParc.Eau(parc.water[0].ToString());
        _carteParc.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        //Config _carteFoot
        _carteFoot = (Carte) GetNode(_str_carteFoot);
        var foot = BuildingCharacteristics.FromType(BuildingType.FOOT);
        _carteFoot.Bloc = foot.Bloc[0];
        _carteFoot.Cost = foot.Cost[0];
        _carteFoot.Titre(foot.Titre[0]);
        _carteFoot.Gain(foot.Earn[0]);
        _carteFoot.Prix(foot.Cost[0]);
        _carteFoot.Enrgie(foot.energy[0].ToString());
        _carteFoot.Eau(foot.water[0].ToString());
        _carteFoot.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        //Config _carteZoo
        _carteZoo = (Carte) GetNode(_str_carteZoo);
        var zoo = BuildingCharacteristics.FromType(BuildingType.ZOO);
        _carteZoo.Bloc = zoo.Bloc[0];
        _carteZoo.Cost = zoo.Cost[0];
        _carteZoo.Titre(zoo.Titre[0]);
        _carteZoo.Gain(zoo.Earn[0]);
        _carteZoo.Prix(zoo.Cost[0]);
        _carteZoo.Enrgie(zoo.energy[0].ToString());
        _carteZoo.Eau(zoo.water[0].ToString());
        _carteZoo.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        //Config _carteFeteForraine
        _carteFeteForraine = (Carte) GetNode(_str_carteFeteForraine);
        var feteForraine = BuildingCharacteristics.FromType(BuildingType.FETEFORRAINE);
        _carteFeteForraine.Bloc = feteForraine.Bloc[0];
        _carteFeteForraine.Cost = feteForraine.Cost[0];
        _carteFeteForraine.Titre(feteForraine.Titre[0]);
        _carteFeteForraine.Gain(feteForraine.Earn[0]);
        _carteFeteForraine.Prix(feteForraine.Cost[0]);
        _carteFeteForraine.Enrgie(feteForraine.energy[0].ToString());
        _carteFeteForraine.Eau(feteForraine.water[0].ToString());
        _carteFeteForraine.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

        //Config _carteBasket
        _carteBasket = (Carte) GetNode(_str_carteBasket);
        var basket = BuildingCharacteristics.FromType(BuildingType.BASKET);
        _carteBasket.Bloc = basket.Bloc[0];
        _carteBasket.Cost = basket.Cost[0];
        _carteBasket.Titre(basket.Titre[0]);
        _carteBasket.Gain(basket.Earn[0]);
        _carteBasket.Prix(basket.Cost[0]);
        _carteBasket.Enrgie(basket.energy[0].ToString());
        _carteBasket.Eau(basket.water[0].ToString());
        _carteBasket.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));


        _menu_achat.Hide();
        AddUserSignal("CloseShop");

        Carte[] menu1 = {_carteParc, _carteFoot, _carteZoo};
        Carte[] menu2 = {_carteFeteForraine, _carteBasket};
        Carte[][] menus = {menu1, menu2};
        _menu_achat.Menus = menus;
    }

    public void Reset()
    {
        Carte[] menu1 = {_carteParc, _carteFoot, _carteZoo};
        Carte[] menu2 = {_carteFeteForraine, _carteBasket};
        Carte[][] menus = {menu1, menu2};
        _carteParc.Show();
        _carteFoot.Show();
        _carteZoo.Show();
        _carteFeteForraine.Hide();
        _carteBasket.Hide();
        _menu_achat.Menus = menus;
        _menu_achat._whichMenu = 0;
    }

    public void CloseMenuBienEtre()
    {
        _menu_achat.Hide();
    }

    public void OpenMenuBienEtre()
    {
        _menu_achat.Show();
    }

    public void CloseShop()
    {
        EmitSignal("CloseShop", false);
    }
}