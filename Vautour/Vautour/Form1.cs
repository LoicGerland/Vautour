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
    public partial class Form1 : Form
    {
        ObservableCollection<Carte> CartesR; //Liste représentant la main du joueur et des IA
        List<Carte> CartesJ;
        List<Carte> CartesB;
        List<Carte> CartesV;
        List<Carte> CartesN;

        public Form1()
        {
            InitializeComponent();
            CartesR = new ObservableCollection<Carte>();
            CartesJ = new List<Carte>();
            CartesB = new List<Carte>();
            CartesV = new List<Carte>();
            CartesN = new List<Carte>();

            for(int i =1; i<=15; i++)
            {
                CartesR.Add(new Carte(i, i, "R"));
                CartesJ.Add(new Carte(i, i, "J"));
                CartesB.Add(new Carte(i, i, "B"));
                CartesV.Add(new Carte(i, i, "V"));
                CartesN.Add(new Carte(i, i, "N"));
            }

            foreach(Carte c in CartesR)
            {
                lb_main.Items.Add(c.getValue());
            }

        }

        private void bt_jouer_Click(object sender, EventArgs e)
        {
            CartesR.RemoveAt(lb_main.SelectedIndex);
            lb_main.Items.Clear();
            foreach (Carte c in CartesR)
            {
                lb_main.Items.Add(c.getValue());
            }
        }

        

    }
}
