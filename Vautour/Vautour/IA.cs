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

        public Carte play(Carte P1,Carte Pot)
        {
            switch (this.difficulty)
            {
                case 0 :
                    return playrand();
                case 1 :
                    return playrandInt(abs(Pot.getValue()));
                case 2 :
                    return playSmart(Pot.getValue());
                case 3 :
                    return playChuck(P1,Pot);
                default: return playrand();
                    
            }
        }

        public Carte playrand()
        {
            Random r = new Random();
            int i = r.Next(0, this.getCartes().Count());
            Carte C = this.getCartes()[i];
            this.removeCarte(i);
            this.setLastCardPlayed(C);
            return C;
        }

        public Carte playChuck(Carte P1, Carte Pot)
        {
            foreach (Carte C in this.getCartes())
            {
                if (C.getValue() == P1.getValue()+1)
                {
                    this.removeCarte(C);
                    this.setLastCardPlayed(C);
                    return C;
                }
            }
            if (abs(Pot.getValue()) > 4)
            {
                foreach (Carte C in this.getCartes())
                {
                    if (C.getValue() == P1.getValue())
                    {
                        this.removeCarte(C);
                        this.setLastCardPlayed(C);
                        return C;
                    }
                }
            }
            Carte c = this.getCartes()[0];
            this.removeCarte(c);
            this.lastCardPlayed = c;
            return c;
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
                int minValue=-0, maxValue=15;
                switch (valCarte)
                {
                    case 1:
                    case 2:
                    case 3:
                        minValue = 0;
                        maxValue = (this.getCartes().Count/3);
                        while (maxValue <= minValue) { maxValue++; }
                        break;
                    case 4:
                    case 5:
                    case 6:
                        minValue = (this.getCartes().Count / 3) - 1;
                        maxValue = (2*(this.getCartes().Count) / 3);
                        while (maxValue <= minValue) { maxValue++; }
                        break;
                    case 7:
                    case 8:
                    case 9:
                    case 10 :
                        minValue = (2*(this.getCartes().Count) / 3);
                        maxValue = this.getCartes().Count;
                        while (maxValue <= minValue) { maxValue++; }
                        break;
                    default :
                        i = this.getCartes().Count();
                        break;
                }
                i=r.Next(minValue,maxValue);
                C = this.getCarte(i);
            }
            this.removeCarte(C);
            this.setLastCardPlayed(C);
            return C;
        }

        public Carte playSmart(int valCarte)
        {
            switch (valCarte)
            {
                //On joue les cartes de 1 à 4
                case -2:
                case -1:
                case 1:
                case 2:
                    return playCardInRank(1, 4);
                //On joue les cartes de 5 à 8
                case -4:
                case -3:
                case 3:
                case 4:
                    return playCardInRank(4, 9);
                //On joue les cartes de 8 à 12
                case -5:
                case 5:
                case 6:
                case 7:
                    return playCardInRank(9, 13);
                //On joue les cartes de 13 à 15
                case 8:
                case 9:
                case 10:
                    return playCardInRank(13, 15);
            }
            return null;
        }

        public Carte playCardByValue(int value)
        {
            foreach(Carte C in this.getCartes())
            {
                if (C.getValue() == value)
                {
                    this.removeCarte(C);
                    this.setLastCardPlayed(C);
                    return C;
                }
            }
            return null;
        }

        public Carte playCardInRank(int min, int max)
        {
            if (min > max) { int tmp = min; min = max; max = tmp; }
            while(!isInRank(min,max))
            {
                if (max <14) { max++; }
                if (min > 1) { min--; }
            }
            if (isInRank(min, max))
            {
                Random r = new Random();
                Carte c = null;
                do
                {
                    c = this.playCardByValue((int)r.Next(min, max+1));
                }
                while (c==null);
                return c;
            }
            else return null;
        }

        private bool isInRank(int min, int max)
        {
            foreach (Carte c in this.getCartes())
            {
                if (c.getValue() >= min && c.getValue() <= max) { return true; }
            }
            return false;
        }
    }
}
