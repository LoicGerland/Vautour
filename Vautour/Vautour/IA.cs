using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vautour
{
    class IA : Player
    {
        private int difficulty; //Difficulté de l'IA (0: facile, 1: Intermédiaire, 2: Difficile, 3: Chuck Norris)

        public IA(String n,List<Carte> m,int score,int d) : base(n, m, score)
        {
            this.difficulty = d;
        }

        public Carte play()
        {
            switch (this.difficulty)
            {
                case 0 :
                case 1 :
                case 2 :
                case 3 :
                    return playrand();
                default: return playrand();
                    
            }
        }

        public Carte playrand()
        {
            Random r = new Random();
            int i = r.Next(0, this.getCarte().Count() - 1);
            Carte C = this.getCarte()[i];
            this.removeCarte(i);
            this.lastCardPlayed = C;
            return C;
        }
    }
}
