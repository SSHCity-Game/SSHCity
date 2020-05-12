using Godot;
using System;
using System.ComponentModel.Design;
using System.Threading.Tasks;
using SshCity.Scenes.Buildings;


public class Infos : Panel
{
    private Button _quitter;
    private Button _ameliorer;
    private Button _detruire;
    private Sprite _image;
    private Panel _cadre;
    private Label _titre;
    


    private bool buttonWork = false;

    private const string _strQuitter = "Quitter";
    private const string _strAmeliorer = "Ameliorer";
    private const string _strCadre = "Cadre";
    private const string _strDetruire = "Détruire";
    private const string _strImage = _strCadre + "/Image";
    private const string _strTitre = "Titre";
    private Vector2 position;
    
    public override void _Ready()
    {
        _quitter = (Button) GetNode(_strQuitter);
        _ameliorer = (Button) GetNode(_strAmeliorer);
        _detruire = (Button) GetNode(_strDetruire);
        _titre = (Label) GetNode(_strTitre);
        _image = (Sprite) GetNode(_strImage);
        _cadre = (Panel) GetNode(_strCadre);
        _quitter.Connect("pressed", this, nameof(CloseInfos));
        _ameliorer.Connect("pressed", this, nameof(AmeliorerInfos));
    }
    public void CloseInfos()
    {
        this.Hide();
    }

    public void config(Vector2 tile)
    {
        Batiments.Building batiment = Batiments.GetBuildingWithPosition(tile);
        GD.Print(tile);
        Batiments.ListBuildings.Add(batiment);
        _titre.Text = batiment.Titre;
        Texture texture = ResourceLoader.Load(batiment.Image) as Texture;
        _image.Texture = texture;
        position = tile;
    }

    public void AmeliorerInfos()
    {
        GD.Print(position);
        PlanInitial.Amelioration(position);
        config(position);
    }
}
