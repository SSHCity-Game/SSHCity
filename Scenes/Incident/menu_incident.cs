using Godot;
using System;
using System.Net.Mime;
using SshCity.Scenes.Plan;

public class menu_incident : CanvasLayer
{
    /* VARIABLES */
    public Button Boutique;
    public Button Resoudre;
    public Button Quitter;
    public static Button Flamme;
    public TextureRect Background;
    public Label Texte;    
    //public TextureRect BackBoutiqueOk;
    //public Label TexteBoutiqueOk;

    public static int ExistFire = 0;
    public static bool openIncident = false;
    public static bool openShop = false;

    /* textes incident */
    private static string CaserneNon =
        "Attention, vous avez un incendie en cours. \n " +
        "Pour l'eteindre, dirigez vous vers la boutique afin d'acheter une caserne de pompiers. \n ";
    private static string CaserneOui =
        "Attention, vous avez un incendie en cours. \n " +
        "Vous possedez le materiel adequate pour mettre fin a cet incendie \n" +
        "Appuyez sur Eteindre pour venir a bout de l'incendie";
    
    public override void _Ready()
    
    {
        Boutique = (Button) GetNode("Boutique");
        Resoudre = (Button) GetNode("Resoudre");
        Quitter = (Button) GetNode("Quitter");
        Flamme = (Button) GetNode("Flamme");
        Background = (TextureRect) GetNode("Background");
        Texte = (Label) GetNode("Background/Texte");
        //BackBoutiqueOk = (TextureRect) GetNode("BoutiqueOk");
        //TexteBoutiqueOk = (Label) GetNode("BoutiqueOk/TexteBoutiqueOk");
        
        Boutique.Hide();
        Resoudre.Hide();
        Quitter.Hide();
        Flamme.Hide();
        Background.Hide();
        Texte.Hide();
        //BackBoutiqueOk.Hide();
        //TexteBoutiqueOk.Hide();

        Boutique.Connect("pressed", this, nameof(on_boutique_pressed));
        Resoudre.Connect("pressed", this, nameof(on_resoudre_pressed));
        Quitter.Connect("pressed", this, nameof(on_quitter_pressed));
        Flamme.Connect("pressed", this, nameof(Resolution));
    }


    private void HideAll()
    {
        Boutique.Hide();
        Resoudre.Hide();
        Quitter.Hide();
        Background.Hide();
        Texte.Hide();
        //BackBoutiqueOk.Hide();
        //TexteBoutiqueOk.Hide();
    }
    private void on_boutique_pressed()
    {
        HideAll();
        openShop = true;
    }

    public void Resolution()
    {
        Quitter.Show();
        Background.Show();
        if (MainPlan.ExistBatiment(Ref_donnees.caserne))
        {
            Texte.Text = CaserneOui;
            Resoudre.Show();
        }
        else
        {
            Texte.Text = CaserneNon;
            Boutique.Show();
        }
        Texte.Show();
        openIncident = true;
    }
    public static void AlerteIncendie()
    {
        Flamme.Show();
        ExistFire++;
    }


    private void on_resoudre_pressed()
    {   
        HideAll();
        ExistFire--;
        Incident.resoIncident = true;
        if (ExistFire == 0)
        {
            Flamme.Hide();
        }
    }

    private void on_quitter_pressed()
    {
        HideAll();
    }
}
