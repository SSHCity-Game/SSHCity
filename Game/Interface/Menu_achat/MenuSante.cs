using Godot;
using SshCity.Game.Buildings;

public class MenuSante : Node
{
	private const string _str_menu_achat = "Menu_Achat";
	private const string _str_carteHopital = _str_menu_achat + "/Hopital";
	private const string _str_carteCaserne = _str_menu_achat + "/Caserne";
	public static TextureRect _clignoCaserne;
	public static TextureRect _clignoHopital;

	public static bool clignoCaserne = false;
	public static bool clignoHopital = false;
	private Carte _carteCaserne;
	private Carte _carteHopital;
	private Menu_Achat _menu_achat;

	public static bool Achat { get; set; } = false;

	public override void _Ready()
	{
		_menu_achat = (Menu_Achat) GetNode(_str_menu_achat);
		_menu_achat.Connect("CloseShop", this, nameof(CloseShop));

		//Config _carteHopital
		var hospital = BuildingCharacteristics.FromType(BuildingType.HOSPITAL);
		_carteHopital = (Carte) GetNode(_str_carteHopital);
		_carteHopital.Bloc = hospital.Bloc[0];
		_carteHopital.Cost = hospital.Cost[0];
		_carteHopital.Titre(hospital.Titre[0]);
		_carteHopital.Gain(hospital.Earn[0]);
		_carteHopital.Prix(hospital.Cost[0]);
		_carteHopital.Enrgie(hospital.energy[0].ToString());
		_carteHopital.Eau(hospital.water[0].ToString());
		_carteHopital.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

		//Config _carteCaserne
		_carteCaserne = (Carte) GetNode(_str_carteCaserne);
		var caserne = BuildingCharacteristics.FromType(BuildingType.CASERNE);
		_carteCaserne.Bloc = caserne.Bloc[0];
		_carteCaserne.Cost = caserne.Cost[0];
		_carteCaserne.Titre(caserne.Titre[0]);
		_carteCaserne.Gain(caserne.Earn[0]);
		_carteCaserne.Prix(caserne.Cost[0]);
		_carteCaserne.Enrgie(caserne.energy[0].ToString());
		_carteCaserne.Eau(caserne.water[0].ToString());
		_carteCaserne.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));

		/* Fond clignotant quand besoin du batiment*/
		_clignoCaserne = (TextureRect) GetNode(_str_carteCaserne + "/Background/Cligno");
		_clignoCaserne.Hide();
		_clignoHopital = (TextureRect) GetNode(_str_carteHopital + "/Background/Cligno");
		_clignoHopital.Hide();

		_menu_achat.Hide();
		AddUserSignal("CloseShop");

		Carte[] menu1 = {_carteHopital, _carteCaserne};
		Carte[][] menus = {menu1};
		_menu_achat.Menus = menus;
	}

	public void Reset()
	{
		Carte[] menu1 = {_carteHopital, _carteCaserne};
		Carte[][] menus = {menu1};
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
