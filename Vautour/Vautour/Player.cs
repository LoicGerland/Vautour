using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vautour
{
    public class Player
    {
        private String nom; //Nom du joueur

        private List<Carte> main; //Main du joueur

        protected Carte lastCardPlayed; //Dernière carte jouée par le joueur 

        protected int score; //Score du joueur

        public Player(String n,List<Carte> m, int s)
        {
            this.nom = n;
            this.main = m;
            this.score = s;
        }

        public String getNom()
        {
            return this.nom;
        }

        public List<Carte> getCarte()
        {
            return this.main;
        }

        public Carte getLastCardPlayed()
        {
            return lastCardPlayed;
        }

        public void setLastCardPlayed(Carte carte)
        {
            this.lastCardPlayed = carte;
        }

        public int getScore()
        {
            return this.score;
        }

        public void setScore(int s)
        {
            this.score += s; 
        }

        public void removeCarte(int index)
        {
            this.main.RemoveAt(index);
        }
    }
}
