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

            for (int i = 0; i < difficulté.Length-1; i++)
            {
                cb_diffIA1.Items.Add(difficulté[i]);
                cb_diffIA2.Items.Add(difficulté[i]);
                cb_diffIA3.Items.Add(difficulté[i]);
                cb_diffIA4.Items.Add(difficulté[i]);
            }
            cb_diffIA1.Items.Add(difficulté[difficulté.Length-1]);

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
                case 2: cb_diffIA2.Enabled = false; tb_IA2.Enabled = false;
                        cb_diffIA3.Enabled = false; tb_IA3.Enabled = false;
                        cb_diffIA4.Enabled = false; tb_IA4.Enabled = false;
                        break;

                case 3: cb_diffIA2.Enabled = true; tb_IA2.Enabled = true;
                        cb_diffIA3.Enabled = false; tb_IA3.Enabled = false;
                        cb_diffIA4.Enabled = false; tb_IA4.Enabled = false;
                        break;

                case 4: cb_diffIA2.Enabled = true; tb_IA2.Enabled = true;
                        cb_diffIA3.Enabled = true; tb_IA3.Enabled = true;
                        cb_diffIA4.Enabled = false; tb_IA4.Enabled = false;
                        break;

                case 5: cb_diffIA2.Enabled = true; tb_IA2.Enabled = true;
                        cb_diffIA3.Enabled = true; tb_IA3.Enabled = true;
                        cb_diffIA4.Enabled = true; tb_IA4.Enabled = true;
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
                        cartesJ.Add(new Carte(i, i, "J",0));
                    }
                    if (tb_IA4.Text == "") { tb_IA4.Text = "BOT_Pipi"; }
                    IA IA4 = new IA(tb_IA4.Text, cartesJ,0, cb_diffIA4.SelectedIndex);
                    joueurs.Add(IA4);
                    goto case 1;
                case 1 :
                    cartesN = new List<Carte>();
                    for(int i = 1; i <= 15; i++)
                    {
                        cartesN.Add(new Carte(i, i, "N",0));
                    }
                    if (tb_IA3.Text == "") { tb_IA3.Text = "BOT_Titi"; }
                    IA IA3 = new IA(tb_IA3.Text,cartesN,0,cb_diffIA3.SelectedIndex);
                    joueurs.Add(IA3);
                    goto case 2;
                case 2 :
                    cartesV = new List<Carte>();
                    for(int i = 1; i <= 15; i++)
                    {
                        cartesV.Add(new Carte(i, i, "V",0));
                    }
                    if (tb_IA2.Text == "") { tb_IA2.Text = "BOT_Riri"; }
                    IA IA2 = new IA(tb_IA2.Text,cartesV,0,cb_diffIA2.SelectedIndex);
                    joueurs.Add(IA2);
                    goto case 3;
                case 3 :
                    cartesB = new List<Carte>();
                    for(int i = 1; i <= 15; i++)
                    {
                        cartesB.Add(new Carte(i, i, "B",0));
                    }
                    if (tb_IA1.Text == "") { tb_IA1.Text = "BOT_Zizi"; }
                    IA IA1 = new IA(tb_IA1.Text,cartesB,0,cb_diffIA1.SelectedIndex);
                    joueurs.Add(IA1);
                    goto case 4;
                case 4 : 
                    cartesR = new List<Carte>();
                    for(int i = 1; i <= 15; i++)
                    {
                        cartesR.Add(new Carte(i, i, "R",0));
                    }
                    if (tb_P1_name.Text == "") { tb_P1_name.Text = "Player One"; }
                    Human P1 = new Human(tb_P1_name.Text,cartesR,0);
                    joueurs.Add(P1);
                    break;
                default :
                    break;
            }
            plateauJeu = new plateau(joueurs);
            plateauJeu.Show();
        }

        private void règleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Règle du jeu\n\nLe but du jeu est de totaliser le maximum de points en remportant les cartes 'souris' (positive) et en évitant de ramasser les cartes 'vautours' (négative).\n\nLe jeu contient :\n\tdes cartes numérotées de 1 à 15 dans 5 couleurs différentes.\n\tdes cartes 'souris' numérotées de 1 à 10.\n\tdes cartes 'vautours' numérotées de -1 à -5.\n\nDéroulement\n\nChaque joueur prend toutes les cartes d'une couleur. Les cartes 'souris' et 'vautours' sont mélangées et forment un talon caché. Une carte du talon est retournée. Les joueurs choisissent en secret une carte de leur jeu et la posent face cachée sur la table. Toutes les cartes sont retournées en même temps. Deux cas se présentent :\n\tsi la carte retournée est une carte 'souris', le joueur qui a posé la carte la plus forte remporte la 'souris'.\n\tsi la carte retournée est une carte 'vautour', le joueur qui a posé la carte la plus faible remporte le 'vautour'.\n\nSi 2 joueurs jouent une carte de même valeur, ces cartes s'annulent.\n\nSi la carte retournée est une 'souris' et que les 2 cartes qui s'annulent sont les plus fortes, c'est le joueur qui a joué la carte la plus forte après les cartes annulées qui remporte la 'souris'. Si la carte retournée est un 'vautour' et que les 2 cartes qui s'annulent sont les plus faibles, c'est le joueur qui a joué la carte la plus faible après les cartes annulées qui remporte le 'vautour'.\n\nLes cartes des joueurs sont ensuite défaussées ; on retourne une nouvelle carte du talon et on recommence.\n\nFin de partie\n\nLa partie s'arrête quand il n'y a plus de carte dans le talon et que les joueurs ont posé toutes leurs cartes. Chaque joueur fait le compte des points des cartes positives et négatives qu'il a ramassées au cours du jeu. Le vainqueur est celui qui totalise le plus grand score.","Règles dans le Game");
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
