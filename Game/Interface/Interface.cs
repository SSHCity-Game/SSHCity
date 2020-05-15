using System;
using Godot;
using SshCity.Game.Buildings;
using SshCity.Game.Plan;

public class Interface : CanvasLayer
{
    private const string _str_shop = "Boutique";
    private const string _str_button_shop = "ButtonShop";
    private const string _str_money_couleur = "MoneyColor";
    private const string _str_money_text = "MoneyColor/MoneyText";
    private const string _str_buttonRoute = "ButtonAjoutRoute";
    private const string _str_buttonDelete = "ButtonDelete";
    private const string _str_sonouverture = ("ButtonShop/Ouverture");
    private const string _str_bulldozerMouse = "BulldozerMouse";
    private const string _str_croix = "CroixRouge";
    private const string _str_croixJaune = "CroixJaune";
    private const string _str_xp_couleur = "XpColor";
    private const string _str_xp_text = "XpColor/XpText";
    private const string _str_infos = "Infos";
    private const string _str_timer = "Timer";
    private static bool _interdit = false;
    private static bool _interdiMoney = false;
    private static Infos _infos;

    private static bool _infosBool = false;

    private static int _money = Ref_donnees.argent;
    private static bool _hide = true;
    private static int _xp = 0;
    private bool _achatRoute = false;
    private Sprite _bulldozerMouse;
    private Button _button_shop;
    private Button _buttonDelete;
    private Button _buttonRoute;
    public Sprite _croix;
    private Sprite _croixJaune;
    private bool _delete = false;
    private Panel _money_couleur;
    private Label _money_text;
    private AudioStreamPlayer _ouvertureboutique;
    private Boutique _shop;
    private Timer _timer;
    private bool _visible;

    private Panel _xp_couleur;
    private Label _xp_text;
    private int moneyWin = 0;

    public static bool InfosBool
    {
        get => _infosBool;
        set => _infosBool = value;
    }

    public static bool InterdiMoney
    {
        get => _interdiMoney;
        set => _interdiMoney = value;
    }

    public static bool Interdit
    {
        get => _interdit;
        set => _interdit = value;
    }

    public static bool Hide
    {
        get => _hide;
        set => _hide = value;
    }

    public static int Money
    {
        get => _money;
        set => _money = value;
    }

    public static int Xp
    {
        get => _xp;
        set => _xp = value;
    }


    public override void _Ready()
    {
        _money_couleur = (Panel) GetNode(_str_money_couleur);
        _money_text = (Label) GetNode(_str_money_text);
        _xp_couleur = (Panel) GetNode(_str_xp_couleur);
        _xp_text = (Label) GetNode(_str_xp_text);
        _button_shop = (Button) GetNode(_str_button_shop);
        _buttonRoute = (Button) GetNode(_str_buttonRoute);
        _buttonDelete = (Button) GetNode(_str_buttonDelete);
        _shop = (Boutique) GetNode(_str_shop);
        _bulldozerMouse = (Sprite) GetNode(_str_bulldozerMouse);
        _bulldozerMouse.Hide();
        _croix = (Sprite) GetNode(_str_croix);
        _croixJaune = (Sprite) GetNode(_str_croixJaune);
        _infos = (Infos) GetNode(_str_infos);
        _timer = (Timer) GetNode(_str_timer);

        _croix.Hide();
        _croixJaune.Hide();
        _infos.Hide();

        _timer.Start();

        _ouvertureboutique = (AudioStreamPlayer) GetNode(_str_sonouverture);
        _button_shop.Connect("pressed", this, nameof(ButtonShopPressed));
        _buttonDelete.Connect("pressed", this, nameof(ButtonDeletePressed));
        _buttonRoute.Connect("pressed", this, nameof(ButtonRoutePressed));

        _button_shop.Connect("mouse_entered", this, nameof(ButtonOver));
        _buttonDelete.Connect("mouse_entered", this, nameof(ButtonOver));
        _buttonRoute.Connect("mouse_entered", this, nameof(ButtonOver));

        _button_shop.Connect("mouse_exited", this, nameof(ButtonExited));
        _buttonRoute.Connect("mouse_exited", this, nameof(ButtonExited));
        _buttonDelete.Connect("mouse_exited", this, nameof(ButtonExited));

        _timer.Connect("timeout", this, nameof(WinMoney));
    }

    public static void ConfigInfos(Vector2 tile)
    {
        if (_infos.config(tile))
        {
            _infos.Show();
        }
    }


    public void WinMoney()
    {
        Money += moneyWin;
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        _money_text.Text = Convert.ToString(_money);
        _xp_text.Text = Convert.ToString(_xp);

        moneyWin = 0;
        foreach (Batiments.Building batiment in Batiments.ListBuildings)
        {
            moneyWin += batiment.Earn;
        }


        if (PlanInitial.Delete)
        {
            Vector2 mousePosition = GetViewport().GetMousePosition();
            _bulldozerMouse.Position = new Vector2(mousePosition.x + 25, mousePosition.y + 25);
        }
        else
        {
            _bulldozerMouse.Hide();
        }

        if (_interdit)
        {
            _croix.Show();
            Vector2 mousePosition = GetViewport().GetMousePosition();
            _croix.Position = new Vector2(mousePosition.x, mousePosition.y);
        }
        else
        {
            _croix.Hide();
        }

        if (_interdiMoney)
        {
            _croixJaune.Show();
            Vector2 mousePosition = GetViewport().GetMousePosition();
            _croixJaune.Position = new Vector2(mousePosition.x, mousePosition.y);
        }
        else
        {
            _croixJaune.Hide();
        }
    }

    public override void _Input(InputEvent OneAction)
    {
        base._Input(OneAction);
        if (OneAction.IsActionPressed("OuvertureBoutique"))
        {
            ButtonShopPressed();
        }

        if (OneAction.IsActionPressed("Route"))
        {
            ButtonRoutePressed();
        }

        if (OneAction.IsActionPressed("Delete"))
        {
            ButtonDeletePressed();
        }
    }

    public void ButtonShopPressed()
    {
        //Ferme Achat Route
        _achatRoute = false;
        PlanInitial.AchatRoute(_achatRoute);

        //_openShop = !_openShop;
        //_closeShop = !_closeShop;

        _delete = false;
        PlanInitial.Delete = _delete;
        DeleteVerif.Verif = false;

        Infos.Close = true;

        _shop.ViewShop(_hide);
        if (_hide)
        {
            _ouvertureboutique.Play();
        }

        _hide = !_hide;
    }

    public void ButtonRoutePressed()
    {
        _achatRoute = !_achatRoute;
        PlanInitial.AchatRoute(_achatRoute);

        _delete = false;
        PlanInitial.Delete = _delete;
        DeleteVerif.Verif = false;
        Infos.Close = true;
        _hide = false;
        _shop.ViewShop(_hide);
    }

    public void ButtonDeletePressed()
    {
        _hide = false;
        _shop.ViewShop(_hide);

        _interdit = false;
        _achatRoute = false;
        PlanInitial.AchatRoute(_achatRoute);
        Infos.Close = true;
        _delete = !_delete;
        PlanInitial.Delete = _delete;
        _bulldozerMouse.Show();
    }

    public void ButtonOver()
    {
        if (_achatRoute)
        {
            PlanInitial.AchatRoute(false);
        }

        if (_delete)
        {
            PlanInitial.Delete = false;
            _bulldozerMouse.Hide();
        }
    }

    public void ButtonExited()
    {
        if (_achatRoute)
        {
            PlanInitial.AchatRoute(true);
        }

        if (_delete)
        {
            PlanInitial.Delete = true;
            _bulldozerMouse.Show();
        }
    }
}