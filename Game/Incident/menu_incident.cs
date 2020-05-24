using System.Threading.Tasks;
using Godot;
using SshCity.Game.Buildings;
using SshCity.Game.Plan;

public class menu_incident : CanvasLayer
{
    /* Bouton signalisation incident */
    public static Button Flamme;
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
        "Dirigez vous vers la caserne afin de sortir et d'ammener le camion vers le lieu de l'incendie" +
        "Pour ce faire, cliquez sur la caserne, dans la carte info cliquez sur camion, le camion sort \n" +
        "Cliquez ensuite sur ce camion et dirigez le a l'aide des fleches du clavier \n" +
        "Une fois le camion arrive, l'incendie s'eteindra";
    
    private static string PoliceNonB =
        "Attention, vous avez un bracage en cours. \n " +
        "Pour le resoudre, dirigez vous vers la boutique afin d'acheter un commissariat. \n ";
    private static string PoliceOuiB =
        "Attention, vous avez un bracage en cours. \n " +
        "Vous possedez le materiel adequate pour mettre fin a cet incident \n" +
        "Dirigez vous vers le commissariat afin de sortir et d'ammener la voiture vers le lieu du bracage \n" +
        "Pour ce faire, cliquez sur le commissariat, dans la carte info cliquez sur police, la voiture sort \n" +
        "Cliquez ensuite sur cette voiture et dirigez la a l'aide des fleches du clavier \n" +
        "Une fois la voiture arrive, vous arreterez le voleur"; 
    private static string PoliceNonA =
        "Attention, vous avez un accident en cours. \n " +
        "Pour le resoudre, dirigez vous vers la boutique afin d'acheter un commissariat. \n ";
    private static string PoliceOuiA =
        "Attention, vous avez un accident en cours. \n " +
        "Vous possedez le materiel adequate pour mettre fin a cet incident \n" +
        "Dirigez vous vers l'hopital afin de sortir et d'ammener l'ambulance vers le lieu de l'accident \n" +
        "Pour ce faire, cliquez sur l'hopital, dans la carte info cliquez sur ambulance, elle sort \n" +
        "Cliquez ensuite sur celle ci et dirigez la a l'aide des fleches du clavier \n" +
        "Une fois l'ambulance arrive, vous prendrez en charge l'accident";
    
    private static string HopitalNon =
        "Attention, une personne de votre ville se noie. \n " +
        "Pour le sauver, dirigez vous vers la boutique afin d'acheter un hopital. \n ";
    private static string HopitalOui =
        "Attention, une personne de votre ville se noie. \n " +
        "Vous possedez le materiel adequate pour sauver cette personne \n" +
        "Dirigez vous vers l'hopital afin d'ammener l'helico vers le lac \n " +
        "Pour ce faire, cliquez sur l'helico en haut de l'hopital \n" +
        "Une fois l'helico arrive, il prendra en charge la personne";

    /* VARIABLES : boutons menu incident */
    public Button BoutiqueCaserne;
    public Button BoutiquePolice;
    public Button BoutiqueHopital;
    public Button Quitter;
    
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
        Quitter = (Button) GetNode("Quitter");
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
        Quitter.Connect("pressed", this, nameof(HideAll));
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
    
    
    private void ResolutionIncendie()
    {
        CloseAll(); // ferme tous les autres menu
        Background.Show();
        Quitter.Show();
        
        if (MainPlan.ExistBatiment(Ref_donnees.caserne)) // si la caserne est deja presente
            Texte.Text = CaserneOui;
        else {
            Texte.Text = CaserneNon;
            BoutiqueCaserne.Show(); // bouton pour aller vers la boutique
        }

        Texte.Show();
    }

    private void ResolutionAccident()
    {
        CloseAll(); // ferme tous les autres menu
        Background.Show();
        Quitter.Show();
        
        if (MainPlan.ExistBatiment(Ref_donnees.hopital)) // si l'hopital est deja present
            Texte.Text = PoliceOuiA;
        else {
            Texte.Text = PoliceNonA;
            BoutiqueHopital.Show(); // bouton pour aller vers la boutique
        }
        
        Texte.Show();
    }
    
    private void ResolutionBracage()
    { 
        CloseAll(); // ferme tous les autres menu
        Background.Show();
        Quitter.Show();
        
        if (MainPlan.ExistBatiment(Ref_donnees.police)) // si la police est deja presente
            Texte.Text = PoliceOuiB;
        else {
            Texte.Text = PoliceNonB;
            BoutiquePolice.Show(); // bouton pour aller vers la boutique
        }
        
        Texte.Show();
    }
    
    private void ResolutionNoyade()
    {
        CloseAll(); // ferme tous les autres menu
        Background.Show();
        Quitter.Show();
        
        if (MainPlan.ExistBatiment(Ref_donnees.hopital)) // si l'hopital est deja present
            Texte.Text = HopitalOui;
        else {
            Texte.Text = HopitalNon;
            BoutiqueHopital.Show(); // bouton pour aller vers la boutique
        }
        
        Texte.Show();
    }

    private void CloseAll() 
    { /* ferme tous les autres menu */
        OpenIncident = true;
        Infos.Close = true;
        PlanInitial.AchatRoute(false);
        PlanInitial.Delete = false;
        DeleteVerif.Verif = false;
    }
}