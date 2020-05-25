using Godot;
using SshCity.Game.Buildings;

public class MenuBienEtre : Node
{
	private const string _str_menu_achat = "Menu_Achat";
	private const string _str_carteParc = _str_menu_achat + "/Parc";
	private const string _str_carteFoot = _str_menu_achat + "/Foot";

	private Carte _carteParc;
	private Carte _carteFoot;
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


		_menu_achat.Hide();
		AddUserSignal("CloseShop");

		Carte[] menu1 = {_carteParc, _carteFoot};
		Carte[][] menus = {menu1};
		_menu_achat.Menus = menus;
	}
	
	public void Reset()
	{
		Carte[] menu1 = {_carteParc, _carteFoot};
		_carteParc.Show();
		_carteFoot.Show();
		Carte[][] menus = {menu1};
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
