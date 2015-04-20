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
            for (int i =-5; i<= -1;i++)
            {
                pot.Add(new Carte(i, i + 5,"P", 2));
            }
            for (int i = 0; i < 10; i++)
            {
                pot.Add(new Carte(i + 1, i + 5, "P", 1));
            }
            //Création de la partie
            game = new Game(joueurs, pot,this);

            bt_jouer.Enabled = false;
            //Remplissage de la listBox
            foreach(Carte c in joueurs.Last().getCarte())
            {
                lb_main.Items.Add(c.getValue());
            }
            //Activation ou désactivation des joueurs suivant le nombre
            pb_IA1.Enabled = false; lb_IA1.Enabled = false; lb_IA1.Visible = false;
            pb_IA2.Enabled = false; lb_IA2.Enabled = false; lb_IA2.Visible = false;
            pb_IA3.Enabled = false; lb_IA3.Enabled = false; lb_IA3.Visible = false;
            pb_IA4.Enabled = false; lb_IA4.Enabled = false; lb_IA4.Visible = false;
            lb_P1.Text = joueurs.Last().getNom();
            switch (joueurs.Count())
            {
                case 2 :
                    pb_IA1.Enabled = true;  lb_IA1.Enabled = true;
                    lb_IA1.Visible = true;  lb_IA1.Text = joueurs[0].getNom();
                    break;
                case 3 :
                    pb_IA1.Enabled = true;  lb_IA1.Enabled = true;
                    lb_IA1.Visible = true;  lb_IA1.Text = joueurs[1].getNom();
                    pb_IA2.Enabled = true; lb_IA2.Enabled = true;
                    lb_IA2.Visible = true;  lb_IA2.Text = joueurs[0].getNom();
                    break;
                case 4 :
                    pb_IA1.Enabled = true; lb_IA1.Enabled = true;
                    lb_IA1.Visible = true;  lb_IA1.Text = joueurs[2].getNom();
                    pb_IA2.Enabled = true; lb_IA2.Enabled = true;
                    lb_IA2.Visible = true;  lb_IA2.Text = joueurs[1].getNom();
                    pb_IA3.Enabled = true; lb_IA3.Enabled = true;
                    lb_IA3.Visible = true;  lb_IA3.Text = joueurs[0].getNom();
                    break;
                case 5 :
                    pb_IA1.Enabled = true; lb_IA1.Enabled = true;
                    lb_IA1.Visible = true;  lb_IA1.Text = joueurs[3].getNom();
                    pb_IA2.Enabled = true; lb_IA2.Enabled = true;
                    lb_IA2.Visible = true;  lb_IA2.Text = joueurs[2].getNom();
                    pb_IA3.Enabled = true; lb_IA3.Enabled = true;
                    lb_IA3.Visible = true;  lb_IA3.Text = joueurs[1].getNom();
                    pb_IA4.Enabled = true; lb_IA4.Enabled = true;
                    lb_IA4.Visible = true;  lb_IA4.Text = joueurs[0].getNom();
                    break;
            }
        }
        private void bt_jouer_Click(object sender, EventArgs e)
        {
            if (lb_main.SelectedIndex >= 0)
            {
                //Suppression de la carte de la main
                Carte CP1 = joueurs.Last().getCarte().ElementAt(lb_main.SelectedIndex);
                joueurs.Last().setLastCardPlayed(CP1);
                joueurs.Last().removeCarte(lb_main.SelectedIndex);
                pb_P1.Image = sabotCartesJR.Images[CP1.getIndexImage() - 1];
                //Suppression de la carte de la listBox et regénération de celle-ci
                majLB();
                playIAs();
                turnWinner = game.checkTurn();
                lb_winner.Text = turnWinner.getNom() + " gagne le tour";
            }
        }


        private void majLB()
        {
            //Régénération de la listBox
            lb_main.Items.Clear();
            foreach (Carte c in joueurs.Last().getCarte())
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
                case 1 :
                    pb_IA1.Image = sabotCartesJB.Images[joueurs[0].getLastCardPlayed().getIndexImage() - 1];
                    break;
                case 2 :
                    pb_IA1.Image = sabotCartesJB.Images[joueurs[1].getLastCardPlayed().getIndexImage() - 1];
                    pb_IA2.Image = sabotCartesJV.Images[joueurs[0].getLastCardPlayed().getIndexImage() - 1];
                    break;
                case 3 :
                    pb_IA1.Image = sabotCartesJB.Images[joueurs[2].getLastCardPlayed().getIndexImage() - 1];
                    pb_IA2.Image = sabotCartesJV.Images[joueurs[1].getLastCardPlayed().getIndexImage() - 1];
                    pb_IA3.Image = sabotCartesJN.Images[joueurs[0].getLastCardPlayed().getIndexImage() - 1];
                    break;
                case 4 :
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
            pb_Pot.Enabled = false;
        }

    }
}
