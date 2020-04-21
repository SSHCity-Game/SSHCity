using Godot;
using System;

public class Menu_Achat : Panel
{
    private Button _button_flecheG;
    private Button _button_flecheD;
    private Carte[][] _menus;
    private Label _Page;
    
    private int _whichMenu = 0;
    private static bool _achat = false;

    public Carte[][] Menus
    {
        get => _menus;
        set => _menus = value;
    }

    public static bool Achat
    {
        get => _achat;
        set => _achat = value;
    }
    
    private const string _str_button_flecheG = "FlecheG/ButtonFlecheG";
    private const string _str_button_flecheD = "FlecheD/ButtonFlecheD";
    private const string _str_Page = "Page";
    private string _pageText;

    public override void _Process(float delta)
    {
        base._Process(delta);
        _pageText = _whichMenu+1 + "/" + _menus.Length;
        _Page.Text = _pageText;
    }

    public override void _Ready()
    {
        _button_flecheD = (Button) GetNode(_str_button_flecheD);
        _button_flecheG = (Button) GetNode(_str_button_flecheG);
        _button_flecheD.Connect("pressed", this, nameof(ClickFlecheD));
        _button_flecheG.Connect("pressed", this, nameof(ClickFlecheG));
        _Page = (Label) GetNode(_str_Page);
        AddUserSignal("CloseShop");
    }

    public void ClickFlecheD()
    {
        if (_whichMenu + 1 < _menus.Length)
        {
            foreach (var carte in _menus[_whichMenu])
            {
                carte.Hide();
            }
            _whichMenu++;
            foreach (var carte in _menus[_whichMenu])
            {
                carte.Show();
            }
        }
    }
    public void ClickFlecheG()
    {
        if (_whichMenu - 1 >= 0)
        {
            foreach (var carte in _menus[_whichMenu])
            {
                carte.Hide();
            }
            _whichMenu--;
            foreach (var carte in _menus[_whichMenu])
            {
                carte.Show();
            }
        }
    }
    
    public void AchatBatiment(int bloc, int prix)
    {

        if (Interface.Money - prix < 0)
        {
            
        }
        else
        {
            EmitSignal("CloseShop");
            PlanInitial.Achat = true;
            PlanInitial.Batiment = bloc;
            PlanInitial.Prix = prix;
        }
    }

}
