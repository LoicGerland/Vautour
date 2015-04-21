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

        private Player turnWinner;      //Gagnant du tour

        public plateau(List<Player> players)
        {
            InitializeComponent();
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
            //Création de la partie
            game = new Game(joueurs, pot, this);

            bt_jouer.Enabled = false;
            bt_jouer.Visible = false;
            lb_winner.Text = "Cliquer sur le cadre pour\nretourner la carte";
            //Remplissage de la listBox
            foreach (Carte c in joueurs.Last().getCartes())
            {
                lb_main.Items.Add(c.getValue());
            }
            //Activation ou désactivation des joueurs suivant le nombre
            pb_IA1.Enabled = false; lb_IA1.Enabled = false; lb_IA1.Visible = false; lb_Score_IA1.Visible = false;
            pb_IA2.Enabled = false; lb_IA2.Enabled = false; lb_IA2.Visible = false; lb_Score_IA2.Visible = false;
            pb_IA3.Enabled = false; lb_IA3.Enabled = false; lb_IA3.Visible = false; lb_Score_IA3.Visible = false;
            pb_IA4.Enabled = false; lb_IA4.Enabled = false; lb_IA4.Visible = false; lb_Score_IA4.Visible = false;
            lb_P1.Text = joueurs.Last().getNom();
            switch (joueurs.Count())
            {
                case 2:
                    pb_IA1.Enabled = true; lb_IA1.Enabled = true;
                    lb_IA1.Visible = true; lb_IA1.Text = joueurs[0].getNom(); lb_Score_IA1.Visible = true;
                    break;
                case 3:
                    pb_IA1.Enabled = true; lb_IA1.Enabled = true;
                    lb_IA1.Visible = true; lb_IA1.Text = joueurs[1].getNom(); lb_Score_IA1.Visible = true;
                    pb_IA2.Enabled = true; lb_IA2.Enabled = true;
                    lb_IA2.Visible = true; lb_IA2.Text = joueurs[0].getNom(); lb_Score_IA1.Visible = true;
                    break;
                case 4:
                    pb_IA1.Enabled = true; lb_IA1.Enabled = true;
                    lb_IA1.Visible = true; lb_IA1.Text = joueurs[2].getNom(); lb_Score_IA1.Visible = true;
                    pb_IA2.Enabled = true; lb_IA2.Enabled = true;
                    lb_IA2.Visible = true; lb_IA2.Text = joueurs[1].getNom(); lb_Score_IA2.Visible = true;
                    pb_IA3.Enabled = true; lb_IA3.Enabled = true;
                    lb_IA3.Visible = true; lb_IA3.Text = joueurs[0].getNom(); lb_Score_IA3.Visible = true;
                    break;
                case 5:
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
                //Suppression de la carte de la main
                int index = lb_main.SelectedIndex;
                Carte CP1 = joueurs.Last().getCarte(index);
                joueurs.Last().setLastCardPlayed(CP1);
                joueurs.Last().removeCarte(index);
                pb_P1.Image = sabotCartesJR.Images[CP1.getIndexImage() - 1];
                //Suppression de la carte de la listBox et regénération de celle-ci
                majLB();
                playIAs();
                turnWinner = game.checkTurn();
                if (turnWinner != null)
                {
                    for (int i = 0; i < joueurs.Count(); i++)
                    {
                        if (turnWinner.getNom() == joueurs[i].getNom())
                        {
                            joueurs[i].setScore(game.getCurrentCartes().getValue());
                            lb_winner.Text = joueurs[i].getNom() + " prend la carte,\n il a maintenant " + joueurs[i].getScore() + " points";
                            majDisplayScore();
                        }
                    }
                    if (pot.Count == 0)
                    {
                        Player playWinner = getWinner();
                        System.Windows.Forms.MessageBox.Show("La partie est fini, le joueur " + turnWinner.getNom() + " remporte la partie avec " + turnWinner.getScore().ToString() + " points. Bravo à lui");
                        Application.Restart();
                    }
                }
                else
                {
                    lb_winner.Text = "Aucun joueur ne prend cette carte,\nil y a surement égalité.";
                }
                //tirage de la nouvelle carte autorisé
                pb_Pot.Enabled = true;
            }
            else if(lb_main.SelectedIndex <0)
            {
                lbl_main.Text = "Choisi une carte gros malin !";
            }
            else if (joueurs.Count==0)
            {
                System.Windows.Forms.MessageBox.Show("Erreur : Il reste " + joueurs.Count +" joueur actuellement dans la partie");
            }
        }

        private Player getWinner()
        {
            Player winner = joueurs[0];
            for (int i = 1; i < joueurs.Count; i++)
            {
                if (joueurs[i].getScore() > winner.getScore())
                {
                    winner = joueurs[i];
                }
            }
            return winner;
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

        private void playIAs()
        {
            for (int i = 0; i < joueurs.Count() - 1; i++)
            {
                ((IA)joueurs[i]).play();
                System.Threading.Thread.Sleep(10);
            }
            switch (joueurs.Count() - 1)
            {
                case 1:
                    pb_IA1.Image = sabotCartesJB.Images[joueurs[0].getLastCardPlayed().getIndexImage() - 1];
                    break;
                case 2:
                    pb_IA1.Image = sabotCartesJB.Images[joueurs[1].getLastCardPlayed().getIndexImage() - 1];
                    pb_IA2.Image = sabotCartesJV.Images[joueurs[0].getLastCardPlayed().getIndexImage() - 1];
                    break;
                case 3:
                    pb_IA1.Image = sabotCartesJB.Images[joueurs[2].getLastCardPlayed().getIndexImage() - 1];
                    pb_IA2.Image = sabotCartesJV.Images[joueurs[1].getLastCardPlayed().getIndexImage() - 1];
                    pb_IA3.Image = sabotCartesJN.Images[joueurs[0].getLastCardPlayed().getIndexImage() - 1];
                    break;
                case 4:
                    pb_IA1.Image = sabotCartesJB.Images[joueurs[3].getLastCardPlayed().getIndexImage() - 1];
                    pb_IA2.Image = sabotCartesJV.Images[joueurs[2].getLastCardPlayed().getIndexImage() - 1];
                    pb_IA3.Image = sabotCartesJN.Images[joueurs[1].getLastCardPlayed().getIndexImage() - 1];
                    pb_IA4.Image = sabotCartesJJ.Images[joueurs[0].getLastCardPlayed().getIndexImage() - 1];
                    break;
            }

        }

        private void pb_Pot_Click(object sender, EventArgs e)
        {
            game.playTurn();
            bt_jouer.Enabled = true;
            bt_jouer.Visible = true;
            pb_Pot.Enabled = false;
        }

        private void majDisplayScore()
        {
            switch (joueurs.Count() - 1)
            {
                case 1:
                    lb_Score_IA1.Text = joueurs[0].getScore().ToString();
                    break;
                case 2:
                    lb_Score_IA2.Text = joueurs[1].getScore().ToString();
                    lb_Score_IA1.Text = joueurs[0].getScore().ToString();
                    break;
                case 3:
                    lb_Score_IA3.Text = joueurs[2].getScore().ToString();
                    lb_Score_IA2.Text = joueurs[1].getScore().ToString();
                    lb_Score_IA1.Text = joueurs[0].getScore().ToString();
                    break;
                case 4:
                    lb_Score_IA4.Text = joueurs[3].getScore().ToString();
                    lb_Score_IA3.Text = joueurs[2].getScore().ToString();
                    lb_Score_IA2.Text = joueurs[1].getScore().ToString();
                    lb_Score_IA1.Text = joueurs[0].getScore().ToString();
                    break;
            }
            lb_Score_P1.Text = joueurs.Last().getScore().ToString();
        }
    }
}
