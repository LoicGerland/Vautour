using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vautour
{
    public class Human : Player
    {
        public Human(String n,List<Carte> m, int score) : base(n,m,score)
        {

        }

        /// <summary>
        /// Methode qui joue le coup du joueur
        /// </summary>
        /// <param name="index">L'index de le carte selectionnée dans la listBox</param>
        public void play(int index)
        {
            Carte CP1 = getCarte(index); //Selectionne la carte a l'index
            setLastCardPlayed(CP1);      //Designe cette carte comme derniere carte jouée
            removeCarte(index);          //Retire la carte jouer de la main du joueur
        }
    }
}
