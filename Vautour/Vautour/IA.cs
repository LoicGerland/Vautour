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

        public Carte play(Carte c)
        {
            switch (this.difficulty)
            {
                case 0 :
                    return playrand();
                case 1 :
                    return playrandInt(abs(c.getValue()));
                case 2 :
                case 3 :
                    return playrand();
                default: return playrand();
                    
            }
        }

        public Carte playrand()
        {
            Random r = new Random();
            int i = r.Next(0, this.getCartes().Count() - 1);
            Carte C = this.getCartes()[i];
            this.removeCarte(i);
            this.lastCardPlayed = C;
            return C;
        }

        public int abs(int i)
        {
            if (i < 0) { return -i; }
            else return i;
        }

        public Carte playrandInt(int valCarte)
        {
            Random r = new Random();
            int i=-1;
            Carte C = null;
            while(C==null)
            {
                switch (valCarte)
                {
                    case 1:
                    case 2:
                    case 3:
                        i = r.Next(0,((this.getCartes().Count())/3)-1);
                        break;
                    case 4:
                    case 5:
                    case 6:
                        i = r.Next(((this.getCartes().Count()) / 3) - 1 , (2*(this.getCartes().Count()) / 3) - 1);
                        break;
                    case 7:
                    case 8:
                    case 9:
                    case 10 :
                        i = r.Next((2*(this.getCartes().Count()) / 3) - 1,(this.getCartes().Count()) - 1);
                        break;
                    default :
                        i = this.getCartes().Count() - 1;
                        break;
                }
                C = this.getCarte(i);
            }
            this.removeCarte(i);
            this.lastCardPlayed = C;
            return C;
        }
    }
}
