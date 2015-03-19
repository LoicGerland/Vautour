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
    public partial class Form1 : Form
    {
        List<int> CartesR; //Liste représentant la main du joueur et des IA
        List<int> CartesJ;
        List<int> CartesB;
        List<int> CartesV;
        List<int> CartesN;

        public Form1()
        {
            InitializeComponent();
            CartesR = new List<int>();
            CartesJ = new List<int>();
            CartesB = new List<int>();
            CartesV = new List<int>();
            CartesN = new List<int>();

            for(int i =1; i<=15; i++)
            {
                CartesR.Add(i);
                CartesJ.Add(i);
                CartesB.Add(i);
                CartesV.Add(i);
                CartesN.Add(i);
            }

            lb_main.DataSource = CartesR;
            lb_main.Refresh();
        }

        

    }
}
