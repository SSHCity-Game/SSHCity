using Godot;
using System;
using System.ComponentModel.Design;
using System.Threading.Tasks;
using SshCity.Scenes.Buildings;


public class Infos : Panel
{
    private Button _quitter;
    private Button _ameliorer;
    private Sprite _image;
    private Panel _cadre;
    private Label _titre;
    private Label _lvlActuel;
    private Label _argentActuel;
    private Label _energieActuel;
    private Label _eauActuel;
    private Panel _amelioPanel;
    private Panel _nivMax;

    private Label _argentAmelio;
    private Label _energieAmelio;
    private Label _eauAmelio;
    
    private bool buttonWork = false;
    private Vector2 position;
    private static bool _close = false;
    private static bool _isOpen = false;

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
    
    public override void _Ready()
    {
        _quitter = (Button) GetNode(_strQuitter);
        _ameliorer = (Button) GetNode(_strAmeliorer);
        _titre = (Label) GetNode(_strTitre);
        _image = (Sprite) GetNode(_strImage);
        _cadre = (Panel) GetNode(_strCadre);
        
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
    }
    public void CloseInfos()
    {
        this.Hide();
        _isOpen = false;
    }

    public bool config(Vector2 tile)
    {
        Batiments.Building batiment = Batiments.GetBuildingWithPosition(tile);
        if (batiment != null)
        {
            Batiments.ListBuildings.Add(batiment);
            _titre.Text = batiment.Titre;
            Texture texture = ResourceLoader.Load(batiment.Image) as Texture;
            _image.Texture = texture;
            position = tile;
            _lvlActuel.Text = "Lvl " + Convert.ToString(batiment.Lvl + 1);
            _argentActuel.Text = Convert.ToString(batiment.Earn);
            //_energieActuel.Text = Convert.ToString(batiment.Energie);
            //_eauActuel.Text = Convert.ToString(batiment.eau):
            if (batiment.Lvl != batiment.NbrAmelioration)
            {
                _argentAmelio.Text = Convert.ToString(batiment.EarnTab[batiment.Lvl+1]);
                //_argentAmelio.Text = Convert.ToString(batiment.EnergieTab[batiment.Lvl + 1]);
                //_eauAmelio.Text = Convert.ToString(batiment.EauTab[batiment.Lvl + 1]);
                _ameliorer.Text = "Ameliorer\n" + Convert.ToString(batiment.AmeliorationCost);
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
    }
}
