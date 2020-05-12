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
    
    private bool buttonWork = false;
    private Vector2 position;


    private const string _strQuitter = "Quitter";
    private const string _strAmeliorer = "Ameliorer";
    private const string _strCadre = "Cadre";
    private const string _strImage = _strCadre + "/Image";
    private const string _strTitre = "Titre";
    private const string _strLvlActuel = "Lvl/LvlActuel";
    private const string _strArgentActuel = "Lvl/Gains/Argent/ArgentValue";
    private const string _strEnergieActuel = "Lvl/Couts/Energie/EnergieValue";
    private const string _strEauActuel = "Lvl/Couts/Eau/EauValue";
    
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
        
        _quitter.Connect("pressed", this, nameof(CloseInfos));
        _ameliorer.Connect("pressed", this, nameof(AmeliorerInfos));
    }
    public void CloseInfos()
    {
        this.Hide();
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
            return true;
        }

        return false;
    }

    public void AmeliorerInfos()
    {
        PlanInitial.Amelioration(position);
        config(position);
    }
}
