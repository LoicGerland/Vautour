using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vautour
{
    class Player
    {
        private String nom; //Nom du joueur

        private List<Carte> main; //Main du joueur

        public Player(String n,List<Carte> m)
        {
            this.nom = n;
            this.main = m;
        }

        public String getNom()
        {
            return this.nom;
        }
    }
}
