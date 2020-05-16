using Godot;
using SshCity.Game.Buildings;

public class MenuSpeciaux : Node
{
	private const string _str_menu_achat = "Menu_Achat";
	private const string _str_cartePolice = _str_menu_achat + "/Police";
	private const string _str_carteEglise = _str_menu_achat + "/Eglise";
	private const string _str_carteCentraleElectrique = _str_menu_achat + "/CentraleElectrique";

	private Carte _carteCentraleElectrique;
	private Carte _carteEglise;
	private Carte _cartePolice;
	private Menu_Achat _menu_achat;

	public static bool Achat { get; set; } = false;

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
		_cartePolice.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));


		//Config _carteCentraleElectrique
		_carteCentraleElectrique = (Carte) GetNode(_str_carteCentraleElectrique);
		var centrale = BuildingCharacteristics.FromType(BuildingType.CENTRALE);
		_carteCentraleElectrique.Bloc = centrale.Bloc[0];
		_carteCentraleElectrique.Cost = centrale.Cost[0];
		_carteCentraleElectrique.Titre(centrale.Titre[0]);
		_carteCentraleElectrique.Gain(centrale.Earn[0]);
		_carteCentraleElectrique.Prix(centrale.Cost[0]);
		_carteCentraleElectrique.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

		//Config _carteEglise

		_carteEglise = (Carte) GetNode(_str_carteEglise);
		var eglise = BuildingCharacteristics.FromType(BuildingType.EGLISE);
		_carteEglise.Bloc = eglise.Bloc[0];
		_carteEglise.Cost = eglise.Cost[0];
		_carteEglise.Titre(eglise.Titre[0]);
		_carteEglise.Gain(eglise.Earn[0]);
		_carteEglise.Prix(eglise.Cost[0]);
		_carteEglise.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));


		_menu_achat.Hide();
		AddUserSignal("CloseShop");

		Carte[] menu1 = {_cartePolice, _carteCentraleElectrique, _carteEglise};
		Carte[][] menus = {menu1};
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
