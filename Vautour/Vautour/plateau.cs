using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace Vautour
{
    public partial class plateau : Form
    {
        private Game game;              //Objet Game représente la partie en cours

        private List<Carte> pot;        //Le paquet de carte du milieu (Souris,Vautours)

        private List<Player> joueurs;   //Liste des joueurs de la partie

        public plateau(List<Player> players)
        {
            InitializeComponent();

            //Initialise les différents players (nombre, nom, difficulté)
            this.joueurs = players;

            //Remplissage du pot
            pot = new List<Carte>();
            for (int i = -5; i <= -1; i++)
            {
                pot.Add(new Carte(i, i + 5, "P", 2));
            }
            for (int i = 0; i < 10; i++)
            {
                pot.Add(new Carte(i + 1, i + 5, "P", 1));
            }

            //Création de la partie et partage de la variable joueurs entre le Plateau et Game
            game = new Game(joueurs, pot, this);

            //Affichage/masquage des différents éléments
            bt_jouer.Enabled = false;
            bt_jouer.Visible = false;
            lb_winner.Text = "Cliquer sur le cadre pour\nretourner la carte";

            //Remplissage de la listBox
            foreach (Carte c in joueurs.Last().getCartes())
            {
                lb_main.Items.Add(c.getValue());
            }

            //Activation ou désactivation des joueurs suivant le nombre
            highLight(6);
            pb_IA1.Enabled = false; lb_IA1.Enabled = false; lb_IA1.Visible = false; lb_Score_IA1.Visible = false;
            pb_IA2.Enabled = false; lb_IA2.Enabled = false; lb_IA2.Visible = false; lb_Score_IA2.Visible = false;
            pb_IA3.Enabled = false; lb_IA3.Enabled = false; lb_IA3.Visible = false; lb_Score_IA3.Visible = false;
            pb_IA4.Enabled = false; lb_IA4.Enabled = false; lb_IA4.Visible = false; lb_Score_IA4.Visible = false;
            lb_P1.Text = joueurs.Last().getNom();
            switch (joueurs.Count())
            {
                case 2: //Permet l'affichage de 2 joueurs
                    pb_IA1.Enabled = true; lb_IA1.Enabled = true;
                    lb_IA1.Visible = true; lb_IA1.Text = joueurs[0].getNom(); lb_Score_IA1.Visible = true;
                    break;
                case 3: //Permet l'affichage de 3 joueurs
                    pb_IA1.Enabled = true; lb_IA1.Enabled = true;
                    lb_IA1.Visible = true; lb_IA1.Text = joueurs[1].getNom(); lb_Score_IA1.Visible = true;
                    pb_IA2.Enabled = true; lb_IA2.Enabled = true;
                    lb_IA2.Visible = true; lb_IA2.Text = joueurs[0].getNom(); lb_Score_IA1.Visible = true;
                    break;
                case 4: //Permet l'affichage de 4 joueurs
                    pb_IA1.Enabled = true; lb_IA1.Enabled = true;
                    lb_IA1.Visible = true; lb_IA1.Text = joueurs[2].getNom(); lb_Score_IA1.Visible = true;
                    pb_IA2.Enabled = true; lb_IA2.Enabled = true;
                    lb_IA2.Visible = true; lb_IA2.Text = joueurs[1].getNom(); lb_Score_IA2.Visible = true;
                    pb_IA3.Enabled = true; lb_IA3.Enabled = true;
                    lb_IA3.Visible = true; lb_IA3.Text = joueurs[0].getNom(); lb_Score_IA3.Visible = true;
                    break;
                case 5: //Permet l'affichage de 5 joueurs
                    pb_IA1.Enabled = true; lb_IA1.Enabled = true;
                    lb_IA1.Visible = true; lb_IA1.Text = joueurs[3].getNom(); lb_Score_IA1.Visible = true;
                    pb_IA2.Enabled = true; lb_IA2.Enabled = true;
                    lb_IA2.Visible = true; lb_IA2.Text = joueurs[2].getNom(); lb_Score_IA2.Visible = true;
                    pb_IA3.Enabled = true; lb_IA3.Enabled = true;
                    lb_IA3.Visible = true; lb_IA3.Text = joueurs[1].getNom(); lb_Score_IA3.Visible = true;
                    pb_IA4.Enabled = true; lb_IA4.Enabled = true;
                    lb_IA4.Visible = true; lb_IA4.Text = joueurs[0].getNom(); lb_Score_IA4.Visible = true;
                    break;
            }
        }
        private void bt_jouer_Click(object sender, EventArgs e)
        {
            if (lb_main.SelectedIndex >= 0 && joueurs.Count!=0)
            {
                //Interdiction de rejouer instantannement
                bt_jouer.Enabled = false;
                bt_jouer.Visible = false;
                lbl_main.Text = "Main";

                //Selection de la carte de P1
                int index = lb_main.SelectedIndex;

                //Joue le tour
                game.playTurn(index);

                //Suppression de la carte de la listBox et regénération de celle-ci
                majLB();

                //tirage de la nouvelle carte autorisé
                pb_Pot.Enabled = true;
            }
            else if(lb_main.SelectedIndex <0)   //Si un imbécile oubliait de choisir une carte ... :/
            {
                lbl_main.Text = "Choisi une carte gros malin !";
            }
        }

        private void majLB()
        {
            //Régénération de la listBox
            lb_main.Items.Clear();
            foreach (Carte c in joueurs.Last().getCartes())
            {
                lb_main.Items.Add(c.getValue());
            }
        }

        private void pb_Pot_Click(object sender, EventArgs e)
        {
            game.playCarte();   //Joue une carte du pot au hasard

            //Permet au joueur de choisir et valider sa carte
            bt_jouer.Enabled = true;
            bt_jouer.Visible = true; 

            //Empeche de changer la carte du pot
            pb_Pot.Enabled = false;

            //Affichage en texte de la carte du pot
            lb_winner.Text = "Vous jouez pour une carte " + game.getCurrentCarte().getStringByType() + "\nde valeur " + game.getCurrentCarte().getValue().ToString();
        }

        public void majDisplayScore()
        {
            switch (joueurs.Count() - 1)
            {
                case 1:
                    lb_Score_IA1.Text = joueurs[0].getScore().ToString();
                    break;
                case 2:
                    lb_Score_IA1.Text = joueurs[1].getScore().ToString();
                    lb_Score_IA2.Text = joueurs[0].getScore().ToString();
                    break;
                case 3:
                    lb_Score_IA1.Text = joueurs[2].getScore().ToString();
                    lb_Score_IA2.Text = joueurs[1].getScore().ToString();
                    lb_Score_IA3.Text = joueurs[0].getScore().ToString();
                    break;
                case 4:
                    lb_Score_IA1.Text = joueurs[3].getScore().ToString();
                    lb_Score_IA2.Text = joueurs[2].getScore().ToString();
                    lb_Score_IA3.Text = joueurs[1].getScore().ToString();
                    lb_Score_IA4.Text = joueurs[0].getScore().ToString();
                    break;
            }
            lb_Score_P1.Text = joueurs.Last().getScore().ToString();
        }

        public void displayCards(int nbJoueurs)
        {
            switch (nbJoueurs)
            {
                case 2:
                    pb_IA1.Image = sabotCartesJB.Images[joueurs[0].getLastCardPlayed().getIndexImage() - 1];
                    break;
                case 3:
                    pb_IA1.Image = sabotCartesJB.Images[joueurs[1].getLastCardPlayed().getIndexImage() - 1];
                    pb_IA2.Image = sabotCartesJV.Images[joueurs[0].getLastCardPlayed().getIndexImage() - 1];
                    break;
                case 4:
                    pb_IA1.Image = sabotCartesJB.Images[joueurs[2].getLastCardPlayed().getIndexImage() - 1];
                    pb_IA2.Image = sabotCartesJV.Images[joueurs[1].getLastCardPlayed().getIndexImage() - 1];
                    pb_IA3.Image = sabotCartesJN.Images[joueurs[0].getLastCardPlayed().getIndexImage() - 1];
                    break;
                case 5:
                    pb_IA1.Image = sabotCartesJB.Images[joueurs[3].getLastCardPlayed().getIndexImage() - 1];
                    pb_IA2.Image = sabotCartesJV.Images[joueurs[2].getLastCardPlayed().getIndexImage() - 1];
                    pb_IA3.Image = sabotCartesJN.Images[joueurs[1].getLastCardPlayed().getIndexImage() - 1];
                    pb_IA4.Image = sabotCartesJJ.Images[joueurs[0].getLastCardPlayed().getIndexImage() - 1];
                    break;
            }
            pb_P1.Image = sabotCartesJR.Images[joueurs.Last().getLastCardPlayed().getIndexImage() - 1];

        }

        public void displayTextLbWinner(String s)
        {
            lb_winner.Text = s;
        }

        public void displayMessage(String s)
        {
            System.Windows.Forms.MessageBox.Show(s);
        }

        private void déroulementDuJeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("1_Cliquer sur le cadre au centre pour retourner une carte du pot\n2_Choisir dans la liste déroulante la valeur de la carte à jouer\n3_Cliquer sur jouer pour poser votre carte\n4_Goto 1_","Déroulement da la partie");
        }

        private void regleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Règle du jeu\n\nLe but du jeu est de totaliser le maximum de points en remportant les cartes 'souris' (positive) et en évitant de ramasser les cartes 'vautours' (négative).\n\nLe jeu contient :\n\tdes cartes numérotées de 1 à 15 dans 5 couleurs différentes.\n\tdes cartes 'souris' numérotées de 1 à 10.\n\tdes cartes 'vautours' numérotées de -1 à -5.\n\nDéroulement\n\nChaque joueur prend toutes les cartes d'une couleur. Les cartes 'souris' et 'vautours' sont mélangées et forment un talon caché. Une carte du talon est retournée. Les joueurs choisissent en secret une carte de leur jeu et la posent face cachée sur la table. Toutes les cartes sont retournées en même temps. Deux cas se présentent :\n\tsi la carte retournée est une carte 'souris', le joueur qui a posé la carte la plus forte remporte la 'souris'.\n\tsi la carte retournée est une carte 'vautour', le joueur qui a posé la carte la plus faible remporte le 'vautour'.\n\nSi 2 joueurs jouent une carte de même valeur, ces cartes s'annulent.\n\nSi la carte retournée est une 'souris' et que les 2 cartes qui s'annulent sont les plus fortes, c'est le joueur qui a joué la carte la plus forte après les cartes annulées qui remporte la 'souris'. Si la carte retournée est un 'vautour' et que les 2 cartes qui s'annulent sont les plus faibles, c'est le joueur qui a joué la carte la plus faible après les cartes annulées qui remporte le 'vautour'.\n\nLes cartes des joueurs sont ensuite défaussées ; on retourne une nouvelle carte du talon et on recommence.\n\nFin de partie\n\nLa partie s'arrête quand il n'y a plus de carte dans le talon et que les joueurs ont posé toutes leurs cartes. Chaque joueur fait le compte des points des cartes positives et négatives qu'il a ramassées au cours du jeu. Le vainqueur est celui qui totalise le plus grand score.", "Règles dans le Game");

        }


        private void recommencerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void quitterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void highLight(int numJoueur)
        {
            switch (numJoueur)
            {
                case 1:
                    pb_IA1.BorderStyle = BorderStyle.None; lb_IA1.BackColor = Color.Transparent;
                    pb_IA2.BorderStyle = BorderStyle.None; lb_IA2.BackColor = Color.Transparent;
                    pb_IA3.BorderStyle = BorderStyle.None; lb_IA3.BackColor = Color.Transparent;
                    pb_IA4.BorderStyle = BorderStyle.None; lb_IA4.BackColor = Color.Transparent;
                    pb_P1.BorderStyle = BorderStyle.Fixed3D; lb_P1.BackColor = Color.Cyan;
                    break;
                case 2:
                    pb_IA1.BorderStyle = BorderStyle.Fixed3D; lb_IA1.BackColor = Color.Cyan;
                    pb_IA2.BorderStyle = BorderStyle.None; lb_IA2.BackColor = Color.Transparent;
                    pb_IA3.BorderStyle = BorderStyle.None; lb_IA3.BackColor = Color.Transparent;
                    pb_IA4.BorderStyle = BorderStyle.None; lb_IA4.BackColor = Color.Transparent;
                    pb_P1.BorderStyle = BorderStyle.None; lb_P1.BackColor = Color.Transparent;
                    break;
                case 3:
                    pb_IA1.BorderStyle = BorderStyle.None; lb_IA1.BackColor = Color.Transparent;
                    pb_IA2.BorderStyle = BorderStyle.Fixed3D; lb_IA2.BackColor = Color.Cyan;
                    pb_IA3.BorderStyle = BorderStyle.None; lb_IA3.BackColor = Color.Transparent;
                    pb_IA4.BorderStyle = BorderStyle.None; lb_IA4.BackColor = Color.Transparent;
                    pb_P1.BorderStyle = BorderStyle.None; lb_P1.BackColor = Color.Transparent;
                    break;
                case 4:
                    pb_IA1.BorderStyle = BorderStyle.None; lb_IA1.BackColor = Color.Transparent;
                    pb_IA2.BorderStyle = BorderStyle.None; lb_IA2.BackColor = Color.Transparent;
                    pb_IA3.BorderStyle = BorderStyle.Fixed3D; lb_IA3.BackColor = Color.Cyan;
                    pb_IA4.BorderStyle = BorderStyle.None; lb_IA4.BackColor = Color.Transparent;
                    pb_P1.BorderStyle = BorderStyle.None; lb_P1.BackColor = Color.Transparent;
                    break;
                case 5:
                    pb_IA1.BorderStyle = BorderStyle.None; lb_IA1.BackColor = Color.Transparent;
                    pb_IA2.BorderStyle = BorderStyle.None; lb_IA2.BackColor = Color.Transparent;
                    pb_IA3.BorderStyle = BorderStyle.None; lb_IA3.BackColor = Color.Transparent;
                    pb_IA4.BorderStyle = BorderStyle.Fixed3D; lb_IA4.BackColor = Color.Cyan;
                    pb_P1.BorderStyle = BorderStyle.None; lb_P1.BackColor = Color.Transparent;
                    break;
                default :
                    pb_IA1.BorderStyle = BorderStyle.None; lb_IA1.BackColor = Color.Transparent;
                    pb_IA2.BorderStyle = BorderStyle.None; lb_IA2.BackColor = Color.Transparent;
                    pb_IA3.BorderStyle = BorderStyle.None; lb_IA3.BackColor = Color.Transparent;
                    pb_IA4.BorderStyle = BorderStyle.None; lb_IA4.BackColor = Color.Transparent;
                    pb_P1.BorderStyle = BorderStyle.None; lb_P1.BackColor = Color.Transparent;
                    break;

            }
        }
    }
}
