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

        public String getNom()      //Renvoie le nom d'un joueurs
        {
            return this.nom;
        }

        public List<Carte> getCartes()  //Renvoie la liste des cartes restante d'un joueur
        {
            return this.main;
        }

        public Carte getCarte(int index)    //retourne la carte a la position de l'index dans la liste de carte
        {
            return this.main[index];
        }

        public Carte getLastCardPlayed()    //Renvoie la derniere carte jouer par le joueur
        {
            return lastCardPlayed;
        }

        public void setLastCardPlayed(Carte carte)  //Initialise la carte C comme derniere carte jouer par le joueur
        {
            this.lastCardPlayed = carte;
        }

        public int getScore()   //Renvoie le score du joueur
        {
            return this.score;
        }

        public void setScore(int s) //Ajouter s au score du joueur
        {
            this.score += s; 
        }

        public void resetScore()    //Reset le score du joueur
        {
            this.score = 0;
        }

        public void removeCarte(int index)  //Supprime la carte a la position Index de la liste des cartes
        {
            this.main.RemoveAt(index);
        }

        public void removeCarte(Carte C)    //Supprime la carte C de la liste des cartes
        {
            this.main.Remove(C);
        }

        public Carte playCard(Carte C)
        {
            setLastCardPlayed(C);      //Designe cette carte comme derniere carte jouée
            removeCarte(C);          //Retire la carte jouer de la main du joueur
            return C;               //Retourne la carte jouée
        }
    }
}
