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
        private Game game;
        private List<Carte> pot;
        private List<Player> joueurs;
        public plateau(List<Player> players)
        {
            InitializeComponent();
            this.joueurs = players;
            pot = new List<Carte>();
            for (int i =-5; i<= 10;i++)
            {
                pot.Add(new Carte(i,i+5,"P"));
            }
            game = new Game(joueurs, pot);

            //Remplissage de la listBox
            foreach(Carte c in joueurs.Last().getCarte())
            {
                lb_main.Items.Add(c.getValue());
            }

        }

        private void bt_jouer_Click(object sender, EventArgs e)
        {
            //Suppression de la carte de la main
            joueurs.Last().removeCarte(lb_main.SelectedIndex);

            //Suppression de la carte de la listBox et regénération de celle-ci
            lb_main.Items.Clear();
            foreach (Carte c in joueurs.Last().getCarte())
            {
                lb_main.Items.Add(c.getValue());
            }
        }

        

    }
}
