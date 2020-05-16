using Godot;
using SshCity.Game.Buildings;

public class MenuBienEtre : Node
{
	private const string _str_menu_achat = "Menu_Achat";
	private const string _str_carteParc = _str_menu_achat + "/Parc";

	private Carte _carteParc;
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
		_carteParc.Connect("Achat", _menu_achat, nameof(Menu_Achat.AchatBatiment));


		_menu_achat.Hide();
		AddUserSignal("CloseShop");

		Carte[] menu1 = {_carteParc};
		Carte[][] menus = {menu1};
		_menu_achat.Menus = menus;
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
