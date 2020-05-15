using System.Collections.Generic;
using Godot;

namespace SshCity.Scenes.Buildings.BatimentsCaracteristiques
{
    public partial class Caracteristiques
    {
        public class BatimentsCaracteristiques
        {
            private int _nbrAmelioration;
            private int[] _bloc;
            private  int[] _cost;
            private  int[] _earn;
            private  string[] _titre;
            private  int[] gain_xp;
            private string[] _image;
            private int[] _consomation_elec;
            private Batiments.Class _class;

            public Batiments.Class _Class => _class;
            
            public int[] Bloc => _bloc;

            public int[] Cost => _cost;

            public int[] Earn => _earn;

            public string[] Titre => _titre;

            public int[] GainXp => gain_xp;

            public string[] Image => _image;

            public int NbrAmelioration => _nbrAmelioration;

            public int[] ConsomationElec => _consomation_elec;

            public BatimentsCaracteristiques(int nbrAmelioration, int[] _bloc, int[] _cost, int[] _earn, string[] _titre, int[] gain_xp, string[] _image, Batiments.Class _class,int[] _consomation_elec)
            {
                this._nbrAmelioration = nbrAmelioration;
                this._bloc = _bloc;
                this._cost = _cost;
                this._earn = _earn;
                this._titre = _titre;
                this.gain_xp = gain_xp;
                this._image = _image;
                this._class = _class;
                this._consomation_elec = _consomation_elec;
                
                liste.Add(this);
            }
        }
        

        public static BatimentsCaracteristiques GiveCaracteristique(Batiments.Class _class)
        {
            GD.Print(_class);
            foreach (BatimentsCaracteristiques caracteristique in liste)
            {
                GD.Print(caracteristique);
                if (caracteristique._Class == _class)
                {
                    return caracteristique;
                }
            }

            return null;
        }

        public static List<BatimentsCaracteristiques> liste = new List<BatimentsCaracteristiques>();
        
        
    }
}