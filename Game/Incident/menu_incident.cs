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
        "Pour l'éteindre, dirigez-vous vers la boutique afin d'acheter une caserne de pompiers. \n ";
    private static string CaserneOui =
        "Attention, vous avez un incendie en cours. \n " +
        "Vous possédez le matériel adéquate pour mettre fin à cet incident \n" +
        "Dirigez-vous vers la caserne afin de sortir et d'ammener le camion vers le lieu de l'incendie" +
        "Pour ce faire, cliquez sur la caserne puis cliquez sur camion \n" +
        "Cliquez ensuite sur ce camion et dirigez-le à l'aide des flèches du clavier \n" +
        "Une fois le camion arrivé, l'incendie s'éteindra";
    
    private static string PoliceNonB =
        "Attention, vous avez un bracage en cours. \n " +
        "Pour le résoudre, dirigez-vous vers la boutique afin d'acheter un commissariat. \n ";
    private static string PoliceOuiB =
        "Attention, vous avez un bracage en cours. \n " +
        "Vous possédez le matériel adéquate pour mettre fin à cet incident \n" +
        "Dirigez-vous vers le commissariat afin de sortir et d'ammener la voiture vers le lieu du bracage \n" +
        "Pour ce faire, cliquez sur le commissariat puis sur police \n" +
        "Cliquez ensuite sur cette voiture et dirigez-la à l'aide des flèches du clavier \n" +
        "Une fois la voiture arrivée, vous arrêterez le voleur"; 
    private static string PoliceNonA =
        "Attention, vous avez un accident en cours. \n " +
        "Pour le résoudre, dirigez-vous vers la boutique afin d'acheter un commissariat. \n ";
    private static string PoliceOuiA =
        "Attention, vous avez un accident en cours. \n " +
        "Vous possédez le matériel adéquate pour mettre fin à cet incident \n" +
        "Dirigez-vous vers l'hôpital afin de sortir et d'ammener l'ambulance vers le lieu de l'accident \n" +
        "Pour ce faire, cliquez sur l'hôpital puis sur ambulance\n" +
        "Cliquez ensuite sur celle-ci et dirigez-la à l'aide des flèches du clavier \n" +
        "Une fois l'ambulance arrivée, vous prendrez en charge l'accident";
    
    private static string HopitalNon =
        "Attention, une personne de votre ville se noie. \n " +
        "Pour la sauver, dirigez-vous vers la boutique afin d'acheter un hôpital. \n ";
    private static string HopitalOui =
        "Attention, une personne de votre ville se noie. \n " +
        "Vous possédez le matériel adéquate pour sauver cette personne \n" +
        "Dirigez-vous vers l'hôpital afin d'ammener l'hélicoptère vers le lac \n " +
        "Pour ce faire, cliquez sur l'hôpital puis sur hélicoptère\n" +
        "Une fois l'hélicoptère arrivé, il prendra en charge la personne";

    /* VARIABLES : boutons menu incident */
    public Button BoutiqueCaserne;
    public Button BoutiquePolice;
    public Button BoutiqueHopital;
    public Button Quitter;
    public Sprite Croix;
    
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
        Quitter = (Button) GetNode("Background/Quitter");
        Croix = (Sprite) GetNode("Background/Quitter/Sprite");
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
        Croix.Hide();
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
        Croix.Show();
        
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
        Croix.Show();
        
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
        Croix.Show();
        
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
        Croix.Show();
        
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