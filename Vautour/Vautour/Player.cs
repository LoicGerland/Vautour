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

        /// <summary>
        /// Retourne le nom d'un joueur
        /// </summary>
        /// <returns></returns>
        public String getNom()
        {
            return this.nom;
        }

        /// <summary>
        /// Renvoie la liste des cartes d'un joueur
        /// </summary>
        /// <returns></returns>
        public List<Carte> getCartes()
        {
            return this.main;
        }

        /// <summary>
        /// Retourne la carte a la position de l'index dans la liste de carte
        /// </summary>
        /// <param name="index"> Index de la carte </param>
        /// <returns></returns>
        public Carte getCarte(int index)
        {
            return this.main[index];
        }

        /// <summary>
        /// Renvoie la derniere carte jouer par le joueur
        /// </summary>
        /// <returns></returns>
        public Carte getLastCardPlayed()    
        {
            return lastCardPlayed;
        }

        /// <summary>
        /// Initialise la carte C comme derniere carte jouer par le joueur
        /// </summary>
        /// <param name="carte"> Dernière carte jouée </param>
        public void setLastCardPlayed(Carte carte)
        {
            this.lastCardPlayed = carte;
        }

        /// <summary>
        /// Renvoie le score du joueur
        /// </summary>
        /// <returns></returns>
        public int getScore()
        {
            return this.score;
        }

        /// <summary>
        /// Modifie le score du joueur
        /// </summary>
        /// <param name="s"> Valeur du score à ajouter </param>
        public void setScore(int s)
        {
            this.score += s; 
        }

        /// <summary>
        /// Reset le score du joueur
        /// </summary>
        public void resetScore()
        {
            this.score = 0;
        }

        /// <summary>
        /// Supprime la carte à la position Index de la liste des cartes
        /// </summary>
        /// <param name="index"></param>
        public void removeCarte(int index)
        {
            this.main.RemoveAt(index);
        }

        /// <summary>
        /// Supprime la carte C de la liste des cartes
        /// </summary>
        /// <param name="C"> Carte à supprimer </param>
        public void removeCarte(Carte C)
        {
            this.main.Remove(C);
        }

        /// <summary>
        /// Joue la carte C
        /// </summary>
        /// <param name="C"> Carte à jouer </param>
        /// <returns></returns>
        public Carte playCard(Carte C)
        {
            setLastCardPlayed(C);     //Designe cette carte comme derniere carte jouée
            removeCarte(C);          //Retire la carte jouer de la main du joueur
            return C;               //Retourne la carte jouée
        }
    }
}
