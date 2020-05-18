using Godot;
using System;
using SshCity.Game.Plan;

public class MairieMenu : Panel
{
    private Button _quitter;
    private Button _collecte;
    private Button _ouiVehicule;
    private Button _nonVehicule;
    private Button _collecteAutomatique;
    private Button _collecteManuel;
    private Label _nomVille;
    private Label _argentValue;
    private Label _eauValue;
    private Label _electriciteValue;
    private Label _stockageArgent;
    private Label _stockageEau;
    private Label _stockageElectricite;
    

    private const string _strQuitter = "Quitter";
    private const string _strCollecter = "CollecteArgent";
    private const string _strOuiVehicule = "AutorisationVehicules/Oui";
    private const string _strNonVehicule = "AutorisationVehicules/Non";
    private const string _strCollecteAutomatique = "ModeRecolteArgent/Automatique";
    private const string _strCollecteManuel = "ModeRecolteArgent/Manuel";
    private const string _strNomVille = "NomVille";
    private const string _strArgentValue = "ArgentTitre/ArgentValue";
    private const string _strEauValue = "EauTitre/EauValue";
    private const string _strElectriciteValue = "ElectriciteTitre/ElectriciteValue";
    private const string _strStockageArgent = "CapaciteStockageArgentTitre/CapaciteStockageArgentValue";
    private const string _strStockageEau = "CapaciteStockageEauTitre/CapaciteStockageEauValue";
    private const string _strStockageElectricite = "CapaciteStockageEauTitre2/CapaciteStockageEauValue";

    private static bool _openMairieMenu = false;
    private static int _moneyWinManuel = 0;

    public static int MoneyWinManuel
    {
        get => _moneyWinManuel;
        set => _moneyWinManuel = value;
    }

    public static bool OpenMairieMenu
    {
        get => _openMairieMenu;
        set => _openMairieMenu = value;
    }
    
    public override void _Ready()
    {
        _quitter = (Button) GetNode(_strQuitter);
        _collecte = (Button) GetNode(_strCollecter);
        _ouiVehicule = (Button) GetNode(_strOuiVehicule);
        _nonVehicule = (Button) GetNode(_strNonVehicule);
        _collecteAutomatique = (Button) GetNode(_strCollecteAutomatique);
        _collecteManuel = (Button) GetNode(_strCollecteManuel);
        _nomVille = (Label) GetNode(_strNomVille);
        _argentValue = (Label) GetNode(_strArgentValue);
        _eauValue = (Label) GetNode(_strEauValue);
        _electriciteValue = (Label) GetNode(_strElectriciteValue);
        _stockageArgent = (Label) GetNode(_strStockageArgent);
        _stockageEau = (Label) GetNode(_strStockageEau);
        _stockageElectricite = (Label) GetNode(_strStockageElectricite);
        
        _collecte.Hide();
        _collecteAutomatique.Pressed = true;
        _ouiVehicule.Pressed = true;

        _collecte.Connect("pressed", this, nameof(Collecte));
        _collecteManuel.Connect("pressed", this, nameof(CollecteManuel));
        _collecteAutomatique.Connect("pressed", this, nameof(CollecteAutomatique));
        _ouiVehicule.Connect("pressed", this, nameof(OuiVehicule));
        _nonVehicule.Connect("pressed", this, nameof(NonVehicule));
        _quitter.Connect("pressed", this, nameof(QuitterMairieMenu));
    }

    public void Collecte()
    {
        Interface.Money += MoneyWinManuel;
        MoneyWinManuel = 0;
    }

    public void CollecteManuel()
    {
        Interface.MoneyAutomatique = false;
        _collecte.Show();
        _collecteAutomatique.Pressed = false;
        _collecteManuel.Pressed = true;
    }

    public void CollecteAutomatique()
    {
        Interface.MoneyAutomatique = true;
        _collecte.Hide();
        _collecteAutomatique.Pressed = true;
        _collecteManuel.Pressed = false;
        Interface.Money += _moneyWinManuel;
        MoneyWinManuel = 0;
    }

    public void OuiVehicule()
    {
        _nonVehicule.Pressed = false;
        PlanInitial.AddVehicule1 = true;
    }

    public void NonVehicule()
    {
        _ouiVehicule.Pressed = false;
        PlanInitial.AddVehicule1 = false;
    }

    public void QuitterMairieMenu()
    {
        this.Hide();
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        if (_openMairieMenu)
        {
            this.Show();
            _openMairieMenu = false;
        }

        _argentValue.Text = "" + Interface.MoneyWin;
        _electriciteValue.Text = "" + Interface.Energyused;
        _eauValue.Text = "" + Interface.Waterused;

    }
}
