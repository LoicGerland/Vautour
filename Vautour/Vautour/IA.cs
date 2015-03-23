using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vautour
{
    class IA : Player
    {
        private int difficulty; //Difficulté de l'IA (1: facile, 2: Intermédiaire, 3: Difficile)

        public IA(String n,List<Carte> m,int d) : base(n, m)
        {
            this.difficulty = d;
        }
    }
}
