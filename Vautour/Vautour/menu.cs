using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vautour
{
    public partial class menu : Form
    {
        private plateau plateauJeu;
        private int[] nbJoueurs = {2,3,4,5};
        private String[] difficulté = { "Facile", "Intermédiaire", "Difficile", "Chuck Norris" };
        private List<Carte> cartesR; //Liste représentant la main du joueur et des IA
        private List<Carte> cartesJ;
        private List<Carte> cartesB;
        private List<Carte> cartesV;
        private List<Carte> cartesN;
        private List<Player> joueurs;

        //Replissage des combo-box avec les tableaux
        public menu()
        {
            InitializeComponent();

            cb_nbJ.DataSource = nbJoueurs;
            cb_diffIA1.Items.Clear();
            cb_diffIA2.Items.Clear();
            cb_diffIA3.Items.Clear();
            cb_diffIA4.Items.Clear();

            for (int i = 0; i < difficulté.Length; i++)
            {
                cb_diffIA1.Items.Add(difficulté[i]);
                cb_diffIA2.Items.Add(difficulté[i]);
                cb_diffIA3.Items.Add(difficulté[i]);
                cb_diffIA4.Items.Add(difficulté[i]);
            }

            cb_diffIA1.SelectedIndex = 0;
            cb_diffIA2.SelectedIndex = 0;
            cb_diffIA3.SelectedIndex = 0;
            cb_diffIA4.SelectedIndex = 0;
        }

        //Mise à jour des combo-box en fonction du nombre de joueurs
        private void cb_nbJ_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = cb_nbJ.SelectedIndex;
            switch(nbJoueurs[n])
            {
                case 2: cb_diffIA2.Enabled = false;
                        cb_diffIA3.Enabled = false;
                        cb_diffIA4.Enabled = false;
                        break;

                case 3: cb_diffIA2.Enabled = true;
                        cb_diffIA3.Enabled = false;
                        cb_diffIA4.Enabled = false;
                        break;

                case 4: cb_diffIA2.Enabled = true;
                        cb_diffIA3.Enabled = true;
                        cb_diffIA4.Enabled = false;
                        break;

                case 5: cb_diffIA2.Enabled = true; 
                        cb_diffIA3.Enabled = true; 
                        cb_diffIA4.Enabled = true; 
                        break;
            }
        }

        //Lancement de la partie avec les paramètres selectionnés
        private void bt_menuJouer_Click(object sender, EventArgs e)
        {
            this.Hide();
            joueurs = new List<Player>();
            switch ((5-(int)cb_nbJ.SelectedValue))
            {
                case 0: 
                    cartesJ = new List<Carte>();
                    for (int i = 1; i <= 15; i++)
                    {
                        cartesJ.Add(new Carte(i, i, "J"));
                    }
                    IA IA4 = new IA("Toto4", cartesJ, cb_diffIA4.SelectedIndex);
                    joueurs.Add(IA4);
                    goto case 1;
                case 1 :
                    cartesN = new List<Carte>();
                    for(int i =1; i<=15; i++)
                    {
                        cartesN.Add(new Carte(i, i, "N"));
                    }
                    IA IA3 = new IA("Toto3",cartesN,cb_diffIA3.SelectedIndex);
                    joueurs.Add(IA3);
                    goto case 2;
                case 2 :
                    cartesV = new List<Carte>();
                    for(int i =1; i<=15; i++)
                    {
                        cartesV.Add(new Carte(i, i, "V"));
                    }
                    IA IA2 = new IA("Toto2",cartesV,cb_diffIA2.SelectedIndex);
                    joueurs.Add(IA2);
                    goto case 3;
                case 3 :
                    cartesB = new List<Carte>();
                    for(int i =1; i<=15; i++)
                    {
                        cartesB.Add(new Carte(i, i, "B"));
                    }
                    IA IA1 = new IA("Toto1",cartesB,cb_diffIA1.SelectedIndex);
                    joueurs.Add(IA1);
                    goto case 4;
                case 4 : 
                    cartesR = new List<Carte>();
                    for(int i =1; i<=15; i++)
                    {
                        cartesR.Add(new Carte(i, i, "R"));
                    }
                    Human P1 = new Human("P1",cartesR);
                    joueurs.Add(P1);
                    break;
                default :
                    break;
            }
            plateauJeu = new plateau(joueurs);
            plateauJeu.Show();
        }
    }
}
