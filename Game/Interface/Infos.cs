using System;
using Godot;
using SshCity.Game.Buildings;
using SshCity.Game.Vehicules;

public class Infos : Panel
{
    private const string _strQuitter = "Quitter";
    private const string _strAmeliorer = "Ameliorer";
    private const string _strCadre = "Cadre";
    private const string _strImage = _strCadre + "/Image";
    private const string _strTitre = "Titre";
    private const string _strLvlActuel = "Lvl/LvlActuel";
    private const string _strArgentActuel = "Lvl/Gains/Argent/ArgentValue";
    private const string _strEnergieActuel = "Lvl/Couts/Energie/EnergieValue";
    private const string _strEauActuel = "Lvl/Couts/Eau/EauValue";
    private const string _strArgentAmelio = "Amelioration/Gains/Argent/ArgentValue";
    private const string _strEnergieAmelio = "Amelioration/Couts/Energie/EnergieValue";
    private const string _strEauAmelio = "Amelioration/Couts/Eau/EauValue";
    private const string _strAmelioPanel = "Amelioration";
    private const string _strNivMax = "LvlMax";
    private const string _strVehicule = "Camion";
    private static bool _close = false;
    private static bool _isOpen = false;
    private Panel _amelioPanel;
    private Button _ameliorer;
    private Label _argentActuel;

    private Label _argentAmelio;
    private Panel _cadre;
    private BuildingType _class;
    private Label _eauActuel;
    private Label _eauAmelio;
    private Label _energieActuel;
    private Label _energieAmelio;
    private Sprite _image;
    private Label _lvlActuel;
    private Panel _nivMax;
    private Button _quitter;
    private Label _titre;
    private Vehicules.Type _type;
    private Button _vehicule;
    private bool buttonWork = false;
    private Vector2 position;

    public static bool IsOpen
    {
        get => _isOpen;
        set => _isOpen = value;
    }

    public static bool Close
    {
        get => _close;
        set => _close = value;
    }

    public override void _Ready()
    {
        _quitter = (Button) GetNode(_strQuitter);
        _ameliorer = (Button) GetNode(_strAmeliorer);
        _titre = (Label) GetNode(_strTitre);
        _image = (Sprite) GetNode(_strImage);
        _cadre = (Panel) GetNode(_strCadre);

        _vehicule = (Button) GetNode(_strVehicule);

        // Infos/Ameliorations
        _lvlActuel = (Label) GetNode(_strLvlActuel);
        _argentActuel = (Label) GetNode(_strArgentActuel);
        _energieActuel = (Label) GetNode(_strEnergieActuel);
        _eauActuel = (Label) GetNode(_strEauActuel);
        _argentAmelio = (Label) GetNode(_strArgentAmelio);
        _energieAmelio = (Label) GetNode(_strEnergieAmelio);
        _eauAmelio = (Label) GetNode(_strEauAmelio);
        _amelioPanel = (Panel) GetNode(_strAmelioPanel);
        _nivMax = (Panel) GetNode(_strNivMax);
        _nivMax.Hide();


        _quitter.Connect("pressed", this, nameof(CloseInfos));
        _ameliorer.Connect("pressed", this, nameof(AmeliorerInfos));
        _vehicule.Connect("pressed", this, nameof(EnvoieVehicule));
    }

    public void CloseInfos()
    {
        this.Hide();
        _isOpen = false;
    }

    public void EnvoieVehicule()
    {
        CloseInfos();
        PlanInitial.AddVehicule(_type, position);
    }

    public bool config(Vector2 tile)
    {
        Building batiment = Building.Delete(tile);
        if (batiment != null)
        {
            Building.ListBuildings.Add(batiment);
            _titre.Text = batiment.Characteristics.Titre[batiment.Characteristics.Lvl];
            Texture texture = ResourceLoader.Load(batiment.Characteristics.Image[0]) as Texture;
            _image.Texture = texture;
            position = tile;
            _lvlActuel.Text = "Lvl " + Convert.ToString(batiment.Characteristics.Lvl + 1);
            _argentActuel.Text = Convert.ToString(batiment.Characteristics.Earn[0]);
            _class = batiment.Type;
            _energieActuel.Text = Convert.ToString(batiment.Characteristics.Consomationeau[0]);
            _eauActuel.Text = Convert.ToString(batiment.Characteristics.Consomationelec[0]);
            if (batiment.Characteristics.Lvl != batiment.Characteristics.NbrAmeliorations)
            {
                _argentAmelio.Text = Convert.ToString(batiment.Characteristics.Earn[batiment.Characteristics.Lvl + 1]);
                _argentAmelio.Text = Convert.ToString(batiment.Characteristics.Consomationelec[batiment.Characteristics.Lvl + 1]);
                _eauAmelio.Text = Convert.ToString(batiment.Characteristics.Consomationeau[batiment.Characteristics.Lvl + 1]);
                _ameliorer.Text = "Ameliorer\n" + Convert.ToString(batiment.Characteristics.Cost[1]);
            }
            else
            {
                _amelioPanel.Hide();
                _nivMax.Show();
                _ameliorer.Text = "LVL MAX";
            }

            return true;
        }

        return false;
    }

    public void AmeliorerInfos()
    {
        PlanInitial.Amelioration(position);
        config(position);
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        if (_close)
        {
            CloseInfos();
            _close = false;
        }

        if (this.Visible)
        {
            _isOpen = true;
        }

        if (_class == BuildingType.CASERNE)
        {
            _vehicule.Text = "Camion";
            _vehicule.Show();
            _type = Vehicules.Type.CAMION;
        }
        else if (_class == BuildingType.HOSPITAL)
        {
            _vehicule.Text = "Ambulance";
            _vehicule.Show();
            _type = Vehicules.Type.AMBULANCE;
        }
        else if (_class == BuildingType.POLICE)
        {
            _vehicule.Text = "Police";
            _vehicule.Show();
            _type = Vehicules.Type.POLICE;
        }
        else
        {
            _vehicule.Hide();
        }
    }
}