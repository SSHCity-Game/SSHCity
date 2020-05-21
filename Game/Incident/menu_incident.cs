using System.Threading.Tasks;
using Godot;
using SshCity.Game.Buildings;
using SshCity.Game.Plan;

public class menu_incident : CanvasLayer
{
    /* Bouton signalisation incident */
    public static Button Flamme; // en cours
    public static Button Accident;
    public static Button Bracage;
    public static Button Noyade;

    public static bool OpenIncident = false;
    public static bool CaserneopenShop = false;
    public static bool PoliceopenShop = false;
    public static bool HopitalopenShop = false;

    /* Textes incident */
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
    
    private static string HopitalNon =
        "Attention, une personne de votre ville se noie. \n " +
        "Pour le sauver, dirigez vous vers la boutique afin d'acheter un hopital. \n ";
    private static string HopitalOui =
        "Attention, une personne de votre ville se noie. \n " +
        "Vous possedez le materiel adequate pour sauver cette personne \n" +
        "Appuyez sur Sauver le noye pour l'aider";

    /* VARIABLES : boutons menu incident */
    public Button BoutiqueCaserne;
    public Button BoutiquePolice;
    public Button BoutiqueHopital;
    public Button Quitter;
    public Button Eteindre;
    public Button FinAccident;
    public Button FinBracage;
    public Button FinNoyade;
    
    /* Timer incidents */
    public static Timer TimerIncendie;
    public static Timer TimerAccident;
    public static Timer TimerBracage;
    public static Timer TimerNoyade;
    
    public TextureRect Background;
    public Label Texte;

    public override void _Ready()

    { /* Definitions et connections des boutons */
        BoutiqueCaserne = (Button) GetNode("BoutiqueCaserne");
        BoutiqueHopital = (Button) GetNode("BoutiqueHopital");
        BoutiquePolice = (Button) GetNode("BoutiquePolice");
        Quitter = (Button) GetNode("Quitter");;
        Eteindre = (Button) GetNode("Eteindre");
        FinAccident = (Button) GetNode("FinAccident");
        FinBracage = (Button) GetNode("FinBracage");
        FinNoyade = (Button) GetNode("FinNoyade");
        Flamme = (Button) GetNode("Flamme");
        Accident = (Button) GetNode("Accident");
        Bracage = (Button) GetNode("Bracage");
        Noyade = (Button) GetNode("Noyade");
        TimerIncendie = (Timer) GetNode("Flamme/TimerFlamme");
        TimerAccident = (Timer) GetNode("Accident/TimerAccident");
        TimerBracage = (Timer) GetNode("Bracage/TimerBracage");
        TimerNoyade = (Timer) GetNode("Noyade/TimerNoyade");
        Background = (TextureRect) GetNode("Background");
        Texte = (Label) GetNode("Background/Texte");

        HideAll(); // cache tous les boutons d'incidents en cours au debut du jeu
        Flamme.Hide();
        Accident.Hide();
        Bracage.Hide();
        Noyade.Hide();

        BoutiqueCaserne.Connect("pressed", this, nameof(on_boutique_caserne_pressed));
        BoutiquePolice.Connect("pressed", this, nameof(on_boutique_police_pressed));
        BoutiqueHopital.Connect("pressed", this, nameof(on_boutique_hopital_pressed));
        Quitter.Connect("pressed", this, nameof(on_quitter_pressed));
        Eteindre.Connect("pressed", this, nameof(on_eteindre_pressed));
        FinAccident.Connect("pressed", this, nameof(on_fin_accident_pressed));
        FinBracage.Connect("pressed", this, nameof(on_fin_bracage_pressed));
        FinNoyade.Connect("pressed", this, nameof(on_fin_noyade_pressed));
        Flamme.Connect("pressed", this, nameof(ResolutionIncendie));
        Accident.Connect("pressed", this, nameof(ResolutionAccident));
        Bracage.Connect("pressed", this, nameof(ResolutionBracage));
        Noyade.Connect("pressed", this, nameof(ResolutionNoyade));
    }
    

    private void HideAll()
    { /* Cache le menu incident */
        BoutiqueCaserne.Hide();
        BoutiquePolice.Hide();
        BoutiqueHopital.Hide();
        Quitter.Hide();
        Eteindre.Hide();
        FinAccident.Hide();
        FinBracage.Hide();
        FinNoyade.Hide();
        Background.Hide();
        Texte.Hide();
    }

    private void on_boutique_caserne_pressed()
    { /* Appui sur le bouton boutique => ouverture boutique fond cligno caserne */
        HideAll();
        CaserneopenShop = true;
    }
    
    private void on_boutique_police_pressed()
    { /* Appui sur le bouton boutique => ouverture boutique fond cligno police */
        HideAll();
        PoliceopenShop = true;
    }
    
    private void on_boutique_hopital_pressed()
    { /* Appui sur le bouton boutique => ouverture boutique fond cligno hopital */
        HideAll();
        HopitalopenShop = true;
    }

    private void on_quitter_pressed()
    { /* Ferme le menu */
        HideAll();
    }
    
    private async void on_eteindre_pressed()
    { 
        HideAll();
        await Task.Delay(2000);
        incidents.ResoIncident = true;
        TimerIncendie.Start();
        Interface.Xp += 50;
    }
    
    private async void on_fin_accident_pressed()
    {
        HideAll();
        await Task.Delay(2000);
        incidents.ResoAccident = true;
        TimerAccident.Start();
        Interface.Xp += 50;
    }
    private async void on_fin_bracage_pressed()
    {
        HideAll();
        await Task.Delay(2000);
        incidents.ResoBracage = true;
        TimerBracage.Start();
        Interface.Xp += 50;
    }
    
    private async void on_fin_noyade_pressed()
    {
        HideAll();
        await Task.Delay(2000);
        incidents.ResoNoyade = true;
        TimerNoyade.Start();
        Interface.Xp += 50;
    }
    

    private void ResolutionIncendie()
    {
        Background.Show();
        Quitter.Show();
        
        if (MainPlan.ExistBatiment(Ref_donnees.caserne)) // si caserne deja presente
        {
            Texte.Text = CaserneOui;
            Eteindre.Show();
        }
        else
        {
            Texte.Text = CaserneNon;
            BoutiqueCaserne.Show();
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
            FinAccident.Show();
        }
        else
        {
            Texte.Text = PoliceNon;
            BoutiquePolice.Show();
        }
        
        Texte.Show();
        OpenIncident = true;
    }
    
    private void ResolutionBracage()
    {
        Background.Show();
        Quitter.Show();
        
        if (MainPlan.ExistBatiment(Ref_donnees.police))
        {
            Texte.Text = PoliceOui;
            FinBracage.Show();
        }
        else
        {
            Texte.Text = PoliceNon;
            BoutiquePolice.Show();
        }
        
        Texte.Show();
        OpenIncident = true;
    }
    
    private void ResolutionNoyade()
    {
        Background.Show();
        Quitter.Show();
        
        if (MainPlan.ExistBatiment(Ref_donnees.hopital))
        {
            Texte.Text = HopitalOui;
            FinNoyade.Show();
        }
        else
        {
            Texte.Text = HopitalNon;
            BoutiqueHopital.Show();
        }
        
        Texte.Show();
        OpenIncident = true;
    }
}