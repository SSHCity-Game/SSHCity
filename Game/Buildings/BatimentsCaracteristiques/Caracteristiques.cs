using System.Collections.Generic;

namespace SshCity.Game.Buildings.BatimentsCaracteristiques
{
    public partial class Caracteristiques
    {
        public static List<BatimentsCaracteristiques> liste = new List<BatimentsCaracteristiques>();


        public static BatimentsCaracteristiques GiveCaracteristique(Batiments.Class _class)
        {
            foreach (BatimentsCaracteristiques caracteristique in liste)
            {
                if (caracteristique._Class == _class)
                {
                    return caracteristique;
                }
            }

            return null;
        }

        public class BatimentsCaracteristiques
        {
            private int[] _bloc;
            private Batiments.Class _class;
            private int[] _consomation_eau;
            private int[] _consomation_elec;
            private int[] _cost;
            private int[] _earn;
            private string[] _image;
            private int _nbrAmelioration;
            private string[] _titre;
            private int[] gain_xp;

            public BatimentsCaracteristiques(int nbrAmelioration, int[] _bloc, int[] _cost, int[] _earn,
                string[] _titre, int[] gain_xp, string[] _image, Batiments.Class _class, int[] _consomation_elec,
                int[] _consomation_eau)
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
                this._consomation_eau = _consomation_eau;

                liste.Add(this);
            }

            public Batiments.Class _Class => _class;

            public int[] Bloc => _bloc;

            public int[] Cost => _cost;

            public int[] Earn => _earn;

            public string[] Titre => _titre;

            public int[] GainXp => gain_xp;

            public string[] Image => _image;

            public int NbrAmelioration => _nbrAmelioration;

            public int[] ConsomationElec => _consomation_elec;
            public int[] ConsomationEau => _consomation_eau;
        }
    }
}