using Godot;
using System;

public class Interface : CanvasLayer
{
    private Panel _money_couleur;
    private Label _money_text;
    private Button _button_shop;
    private Button _buttonRoute;
    private Boutique _shop;
    private bool _achatRoute = false;
        
    private static int _money = 50000;
    private static bool hide = true;

    public static bool Hide
    {
        get => hide;
        set => hide = value;
    }

    public static int Money
    {
        get => _money;
        set => _money = value;
    }

    private const string _str_shop = "Boutique";
    private const string _str_button_shop = "ButtonShop";
    private const string _str_money_couleur = "MoneyColor";
    private const string _str_money_text = "MoneyColor/MoneyText";
    private const string _str_buttonRoute = "ButtonAjoutRoute";
    
    public override void _Ready()
    {
        _money_couleur = (Panel) GetNode(_str_money_couleur);
        _money_text = (Label) GetNode(_str_money_text);
        _button_shop = (Button) GetNode(_str_button_shop);
        _buttonRoute = (Button) GetNode(_str_buttonRoute);
        _shop = (Boutique) GetNode(_str_shop);
        _button_shop.Connect("pressed", this, nameof(ButtonShopPressed));
        _buttonRoute.Connect("mouse_entered", this, nameof(ButtonRouteOver));
        _buttonRoute.Connect("mouse_exited", this, nameof(ButtonRouteExited));
        _buttonRoute.Connect("pressed", this, nameof(ButtonRoutePressed));
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        _money_text.Text = Convert.ToString(_money);
    }

    public void ButtonShopPressed()
    {
        _shop.ViewShop(hide);
        hide = !hide;
    }
    
    public void ButtonRoutePressed()
    {
        _achatRoute = !_achatRoute;
        PlanInitial.AchatRoute(_achatRoute);
    }
    public void ButtonRouteOver()
    {
        if (_achatRoute)
        {
            PlanInitial.AchatRoute(false);
        }
    }
    public void ButtonRouteExited()
    {
        if (_achatRoute)
        {
            PlanInitial.AchatRoute(true);
        }
    }
    
}

