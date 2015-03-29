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
        private String[] cartes = { "Rouge", "Bleue", "Jaune", "Vert", "Noir" };
        private String[] difficulté = { "Facile", "Intermédiaire", "Difficile", "Chuck Norris" };

        //Replissage des combo-box avec les tableaux
        public menu()
        {
            InitializeComponent();
            cb_nbJ.DataSource = nbJoueurs;
            cb_carteJoueur.DataSource = cartes;
            cb_carteIA1.DataSource = cartes;
            cb_carteIA2.DataSource = cartes;
            cb_carteIA3.DataSource = cartes;
            cb_carteIA4.DataSource = cartes;
            cb_diffIA1.DataSource = difficulté;
            cb_diffIA2.DataSource = difficulté;
            cb_diffIA3.DataSource = difficulté;
            cb_diffIA4.DataSource = difficulté;
        }

        //Mise à jour des combo-box en fonction du nombre de joueurs
        private void cb_nbJ_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = cb_nbJ.SelectedIndex;
            switch(nbJoueurs[n])
            {
                case 2: cb_diffIA2.Enabled = false; cb_carteIA2.Enabled = false;
                        cb_diffIA3.Enabled = false; cb_carteIA3.Enabled = false;
                        cb_diffIA4.Enabled = false; cb_carteIA4.Enabled = false;
                        break;

                case 3: cb_diffIA2.Enabled = true; cb_carteIA2.Enabled = true;
                        cb_diffIA3.Enabled = false; cb_carteIA3.Enabled = false;
                        cb_diffIA4.Enabled = false; cb_carteIA4.Enabled = false;
                        break;

                case 4: cb_diffIA2.Enabled = true; cb_carteIA2.Enabled = true;
                        cb_diffIA3.Enabled = true; cb_carteIA3.Enabled = true;
                        cb_diffIA4.Enabled = false; cb_carteIA4.Enabled = false;
                        break;

                case 5: cb_diffIA2.Enabled = true; cb_carteIA2.Enabled = true;
                        cb_diffIA3.Enabled = true; cb_carteIA3.Enabled = true;
                        cb_diffIA4.Enabled = true; cb_carteIA4.Enabled = true;
                        break;
            }
        }

        //Lancement de la partie avec les paramètres selectionnés
        private void bt_menuJouer_Click(object sender, EventArgs e)
        {
            this.Hide();
            plateauJeu = new plateau();
            plateauJeu.Show();
        }
    }
}
