using Godot;
using System;
using System.Threading.Tasks;


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
    
    public override void _Ready()
    {
        _quitter = (Button) GetNode(_strQuitter);
        _ameliorer = (Button) GetNode(_strAmeliorer);
        _detruire = (Button) GetNode(_strDetruire);
        _titre = (Label) GetNode(_strTitre);
        _image = (Sprite) GetNode(_strImage);
        _cadre = (Panel) GetNode(_strCadre);
        _quitter.Connect("pressed", this, nameof(CloseInfos));

    }

    public override void _Process(float delta)
    {
        base._Process(delta);
    }

    public void CloseInfos()
    {
        this.Hide();
    }

    public void config(int batiment, PlanInitial planInitial)
    {
        
        Action<(string titre, int earn, string pathTexture)> config = delegate((string titre, int earn, string pathTexture) tuple) {             
            _titre.Text = tuple.titre;
            Texture texture = ResourceLoader.Load(tuple.pathTexture) as Texture;
            _image.Texture = texture;
        };

        
        if (batiment == MaisonNode.Bloc)
        {
            config((MaisonNode.Titre, MaisonNode.Earn, MaisonNode.Image));
        }
        else if (batiment == CaserneNode.Bloc)
        {
            config((CaserneNode.Titre, CaserneNode.Earn, CaserneNode.Image));
        }
        else if (batiment == ImmeubleNode.Bloc)
        {
            config((ImmeubleNode.Titre, ImmeubleNode.Earn, ImmeubleNode.Image));

        }
        else if (batiment == PoliceNode.Bloc)
        {
            config((PoliceNode.Titre, PoliceNode.Earn, PoliceNode.Image));

        }
        else if (batiment == HospitalNode.Bloc)
        {
            config((HospitalNode.Titre, HospitalNode.Earn, HospitalNode.Image));

        }
        else if (batiment == CafeNode.Bloc)
        {
            config((CafeNode.Titre, CafeNode.Earn, CafeNode.Image));

        } 
        else if (batiment == EgliseNode.Bloc)
        {
            config((EgliseNode.Titre, EgliseNode.Earn, EgliseNode.Image));

        }
        else if (batiment == FermeNode.Bloc)
        {
            config((FermeNode.Titre, FermeNode.Earn, FermeNode.Image));

        }
        else if (batiment == HotelNode.Bloc)
        {
            config((HotelNode.Titre, HotelNode.Earn, HotelNode.Image));

        }
        else if (batiment == ImmeubleVertNode.Bloc)
        {
            config((ImmeubleVertNode.Titre, ImmeubleVertNode.Earn, ImmeubleVertNode.Image));

        }
        else if (batiment == Maison3Node.Bloc)
        {
            config((Maison3Node.Titre, Maison3Node.Earn, Maison3Node.Image));

        }
        else if (batiment == Maison4Node.Bloc)
        {
            config((Maison4Node.Titre, Maison4Node.Earn, Maison4Node.Image));

        }
        else if (batiment == Maison5Node.Bloc)
        {
            config((Maison5Node.Titre, Maison5Node.Earn, Maison5Node.Image));

        }
        else if (batiment == McAllyNode.Bloc)
        {
            config((McAllyNode.Titre, McAllyNode.Earn, McAllyNode.Image));

        }
        else if (batiment == ParcNode.Bloc)
        {
            config((ParcNode.Titre, ParcNode.Earn, ParcNode.Image));

        }
        else if (batiment == PiscineNode.Bloc)
        {
            config((PiscineNode.Titre, PiscineNode.Earn, PiscineNode.Image));

        }
        else if (batiment == RestaurantNode.Bloc)
        {
            config((RestaurantNode.Titre, RestaurantNode.Earn, RestaurantNode.Image));

        }
        else if (batiment == Restaurant2Node.Bloc)
        {
            config((Restaurant2Node.Titre, Restaurant2Node.Earn, Restaurant2Node.Image));

        }
        else if (batiment == CentraleElectriqueNode.Bloc)
        {
            config((CentraleElectriqueNode.Titre, CentraleElectriqueNode.Earn, CentraleElectriqueNode.Image));

        } 
    }
}
