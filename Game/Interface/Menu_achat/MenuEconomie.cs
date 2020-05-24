using Godot;
using SshCity.Game.Buildings;

public class MenuEconomie : Node
{
	private const string _str_menu_achat = "Menu_Achat";
	private const string _str_carteCafe = "Menu_Achat/Cafe";
	private const string _str_carteRestaurant = _str_menu_achat + "/Restaurant";
	private const string _str_carteRestaurant2 = _str_menu_achat + "/Restaurant2";
	private const string _str_carteFerme = _str_menu_achat + "/Ferme";
	private Carte _carteCafe;
	private Carte _carteFerme;
	private Carte _carteRestaurant;
	private Carte _carteRestaurant2;
	private Menu_Achat _menu_achat;


	public override void _Ready()
	{
		_menu_achat = (Menu_Achat) GetNode(_str_menu_achat);

		//Config _carteCafe
		_carteCafe = (Carte) GetNode(_str_carteCafe);
		var cafe = BuildingCharacteristics.FromType(BuildingType.CAFE);
		_carteCafe.Bloc = cafe.Bloc[0];
		_carteCafe.Cost = cafe.Cost[0];
		_carteCafe.Titre(cafe.Titre[0]);
		_carteCafe.Gain(cafe.Earn[0]);
		_carteCafe.Prix(cafe.Cost[0]);
		_carteCafe.Enrgie(cafe.energy[0].ToString());
		_carteCafe.Eau(cafe.water[0].ToString());
		_carteCafe.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

		//Config _carteRestaurant
		_carteRestaurant = (Carte) GetNode(_str_carteRestaurant);
		var restaurant = BuildingCharacteristics.FromType(BuildingType.RESTAURANT);
		_carteRestaurant.Bloc = restaurant.Bloc[0];
		_carteRestaurant.Cost = restaurant.Cost[0];
		_carteRestaurant.Titre(restaurant.Titre[0]);
		_carteRestaurant.Gain(restaurant.Earn[0]);
		_carteRestaurant.Prix(restaurant.Cost[0]);
		_carteRestaurant.Enrgie(restaurant.energy[0].ToString());
		_carteRestaurant.Eau(restaurant.water[0].ToString());
		_carteRestaurant.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

		//Config _carteRestaurant2
		_carteRestaurant2 = (Carte) GetNode(_str_carteRestaurant2);
		var restaurant2 = BuildingCharacteristics.FromType(BuildingType.RESTAURANT2);
		_carteRestaurant2.Bloc = restaurant2.Bloc[0];
		_carteRestaurant2.Cost = restaurant2.Cost[0];
		_carteRestaurant2.Titre(restaurant2.Titre[0]);
		_carteRestaurant2.Gain(restaurant2.Earn[0]);
		_carteRestaurant2.Prix(restaurant2.Cost[0]);
		_carteRestaurant2.Enrgie(restaurant2.energy[0].ToString());
		_carteRestaurant2.Eau(restaurant2.water[0].ToString());
		_carteRestaurant2.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

		//Config _carteFerme
		_carteFerme = (Carte) GetNode(_str_carteFerme);
		var ferme = BuildingCharacteristics.FromType(BuildingType.FERME);
		_carteFerme.Bloc = ferme.Bloc[0];
		_carteFerme.Cost = ferme.Cost[0];
		_carteFerme.Titre(ferme.Titre[0]);
		_carteFerme.Gain(ferme.Earn[0]);
		_carteFerme.Prix(ferme.Cost[0]);
		_carteFerme.Enrgie(ferme.energy[0].ToString());
		_carteFerme.Eau(ferme.water[0].ToString());
		_carteFerme.Hide();
		_carteFerme.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

		_menu_achat.Connect("CloseShop", this, nameof(CloseShop));

		_menu_achat.Hide();
		AddUserSignal("CloseShop");

		Carte[] menu1 = {_carteCafe, _carteRestaurant, _carteRestaurant2};
		Carte[] menu2 = {_carteFerme};
		Carte[][] menus = {menu1, menu2};
		_menu_achat.Menus = menus;
	}
	
	public void Reset()
	{
		Carte[] menu1 = {_carteCafe, _carteRestaurant, _carteRestaurant2};
		Carte[] menu2 = {_carteFerme};
		_carteFerme.Hide();
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
