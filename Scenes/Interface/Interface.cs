using Godot;
using System;
using SshCity.Scenes.Plan;

public class Interface : CanvasLayer
{
    private Panel _money_couleur;
    private Label _money_text;
    private Button _button_shop;
    private Button _buttonRoute;
    private Button _buttonDelete;
    private Boutique _shop;
    private bool _achatRoute = false;
    private AudioStreamPlayer _ouvertureboutique;
    private Sprite _bulldozerMouse;
    public Sprite _croix;
    private bool _delete = false;
    private static bool _interdit = false;

    public static bool Interdit
    {
        get => _interdit;
        set => _interdit = value;
    }

    private static int _money = Ref_donnees.argent;
    private static bool hide = true;

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

    private const string _str_shop = "Boutique";
    private const string _str_button_shop = "ButtonShop";
    private const string _str_money_couleur = "MoneyColor";
    private const string _str_money_text = "MoneyColor/MoneyText";
    private const string _str_buttonRoute = "ButtonAjoutRoute";
    private const string _str_buttonDelete = "ButtonDelete";
    private const string _str_sonouverture = ("ButtonShop/Ouverture");
    private const string _str_bulldozerMouse = "BulldozerMouse";
    private const string _str_croix = "Croix";
    
    public override void _Ready()
    {
        _money_couleur = (Panel) GetNode(_str_money_couleur);
        _money_text = (Label) GetNode(_str_money_text);
        _button_shop = (Button) GetNode(_str_button_shop);
        _buttonRoute = (Button) GetNode(_str_buttonRoute);
        _buttonDelete = (Button) GetNode(_str_buttonDelete);
        _shop = (Boutique) GetNode(_str_shop);
        _bulldozerMouse = (Sprite) GetNode(_str_bulldozerMouse);
        _bulldozerMouse.Hide();
        _croix = (Sprite) GetNode(_str_croix);
        _croix.Hide();
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
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        _money_text.Text = Convert.ToString(_money);
        if (PlanInitial.Delete)
        {
            Vector2 mousePosition = GetViewport().GetMousePosition();
            _bulldozerMouse.Position = new Vector2(mousePosition.x+25, mousePosition.y+25);
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

        _delete = false;
        PlanInitial.Delete = _delete;
        DeleteVerif.Verif = false;
        
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

