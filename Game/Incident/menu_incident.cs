using System.Threading.Tasks;
using Godot;
using SshCity.Game.Plan;

public class menu_incident : CanvasLayer
{
    public static Button Flamme;
    public static Button Accident;

    public static bool OpenIncident = false;
    public static bool CaserneopenShop = false;

    /* textes incident */
    private static string CaserneNon =
        "Attention, vous avez un incendie en cours. \n " +
        "Pour l'eteindre, dirigez vous vers la boutique afin d'acheter une caserne de pompiers. \n ";
    private static string CaserneOui =
        "Attention, vous avez un incendie en cours. \n " +
        "Vous possedez le materiel adequate pour mettre fin a cet incindent \n" +
        "Appuyez sur Eteindre pour venir a bout de l'incendie";
    
    private static string PoliceNon =
        "Attention, vous avez un accident en cours. \n " +
        "Pour le resoudre, dirigez vous vers la boutique afin d'acheter un commissariat. \n ";
    private static string PoliceOui =
        "Attention, vous avez un accident en cours. \n " +
        "Vous possedez le materiel adequate pour mettre fin a cet incident \n" +
        "Appuyez sur Resoudre pour venir a bout de l'accident";

    public TextureRect Background;

    /* VARIABLES */
    public Button Boutique;
    public Button Quitter;
    public Button Resoudre;
    public Button Eteindre;
    
    public Label Texte;

    public override void _Ready()

    {
        Boutique = (Button) GetNode("Boutique");
        Resoudre = (Button) GetNode("Resoudre");
        Eteindre = (Button) GetNode("Eteindre");
        Quitter = (Button) GetNode("Quitter");
        Flamme = (Button) GetNode("Flamme");
        Accident = (Button) GetNode("Accident");
        Background = (TextureRect) GetNode("Background");
        Texte = (Label) GetNode("Background/Texte");

        HideAll();
        Flamme.Hide();
        Accident.Hide();

        Boutique.Connect("pressed", this, nameof(on_boutique_pressed));
        Resoudre.Connect("pressed", this, nameof(on_resoudre_pressed));
        Eteindre.Connect("pressed", this, nameof(on_eteindre_pressed));
        Quitter.Connect("pressed", this, nameof(on_quitter_pressed));
        Flamme.Connect("pressed", this, nameof(ResolutionIncendie));
        Accident.Connect("pressed", this, nameof(ResolutionAccident));
    }
    

    private void HideAll()
    {
        Boutique.Hide();
        Resoudre.Hide();
        Eteindre.Hide();
        Quitter.Hide();
        Background.Hide();
        Texte.Hide();
    }

    private void on_boutique_pressed()
    {
        HideAll();
        CaserneopenShop = true;
    }

    private void on_quitter_pressed()
    {
        HideAll();
    }
    
    private async void on_eteindre_pressed()
    {
        HideAll();
        await Task.Delay(3000);
        incidents.ResoIncident = true;
        Interface.Xp += 50;
    }
    
    private async void on_resoudre_pressed()
    {
        HideAll();
        await Task.Delay(3000);
        //incidents.ResoAccident = true;
        Interface.Xp += 50;
    }

    private void ResolutionIncendie()
    {
        Background.Show();
        Quitter.Show();
        
        if (MainPlan.ExistBatiment(Ref_donnees.caserne))
        {
            Texte.Text = CaserneOui;
            Eteindre.Show();
        }
        else
        {
            Texte.Text = CaserneNon;
            Boutique.Show();
        }

        Texte.Show();
        OpenIncident = true;
    }

    private void ResolutionAccident()
    {
        Background.Show();
        Quitter.Show();
        
        if (MainPlan.ExistBatiment(Ref_donnees.police))
        {
            Texte.Text = PoliceOui;
            Resoudre.Show();
        }
        else
        {
            Texte.Text = PoliceNon;
            Boutique.Show();
        }
        
        Texte.Show();
        OpenIncident = true;
    }
}