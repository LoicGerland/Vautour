using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vautour
{
    class IA : Player
    {
        private Common.Difficulty difficulty; //Difficulté de l'IA

        public IA(String n,List<Carte> m,int score,Common.Difficulty d) : base(n, m, score)
        {
            this.difficulty = d;
        }

        /// <summary>
        /// Selectionne la méthode de jeu de l'IA en fonction de sa difficulté
        /// </summary>
        /// <param name="game">Partie en cours</param>
        /// <returns></returns>
        public Carte play(Game game)
        {
            if (this.difficulty == Common.Difficulty.Facile)   
            {
                return playEasy(game.getCurrentCarte(), game.getCartPlayed(), game.getPlayers().Count);
            }
            if (this.difficulty == Common.Difficulty.Intermédiaire)
            {
                    return playrandInt(Math.Abs(game.getCurrentCarte().getValue()));
            }
            if (this.difficulty == Common.Difficulty.Difficile)
            {
                    return playSmart(game.getCurrentCarte(), game.getCartPlayed(),game.getPlayers().Count);
            }
            if (this.difficulty == Common.Difficulty.ChuckNorris)
            {
                    return playChuck(game.getPlayers().Last().getLastCardPlayed(),game.getCurrentCarte());
            }
            return playrand();
        }

        /// <summary>
        /// Joue une carte de façon aléatoire parmis toutes les cartes de sa main
        /// </summary>
        /// <returns> La carte jouée</returns>
        public Carte playrand()
        {
            Random r = new Random();
            int i = r.Next(0, this.getCartes().Count());
            Carte C = this.getCartes()[i];
            this.removeCarte(i);
            this.setLastCardPlayed(C);
            return C;
        }

        /// <summary>
        /// Joue la carte juste au dessus de celle du joueur
        /// S'il ne possède pas la carte au dessus, joue la meme si la valeur absolu de la carteen jeu est > 4
        /// Sinon il joue sa plus faible carte
        /// </summary>
        /// <param name="P1"> Le joueur </param>
        /// <param name="Pot"> La carte en jeu </param>
        /// <returns> La carte jouée </returns>
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
            if (Math.Abs(Pot.getValue()) > 4)    
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

            return playCard(c);
        }

        /// <summary>
        /// Joue de maniere aléatoire parmis des intervalles de valeurs selon la carte en jeu
        /// </summary>
        /// <param name="valCarte">Valeur de la carte en jeu</param>
        /// <returns> La carte jouée </returns>
        public Carte playrandInt(int valCarte)  //
        {
            Random r = new Random();
            int i=-1;
            int minValue = 0, maxValue = 16;
            switch (valCarte)
            {
                case 1:     //Valeur de -3 a 3
                case 2:
                case 3:
                    minValue = 0;
                    maxValue = (this.getCartes().Count / 3);  //Joue dans le premier tier de sa main
                    break;
                case 4:    //Valeur -4,-5 et de 4 à 6
                case 5:
                case 6:
                    minValue = (this.getCartes().Count / 3);    //Joue dans le tier du milieu de sa main
                    maxValue = (2 * (this.getCartes().Count) / 3);
                    break;
                case 7:     //Valeur de 7 à 10
                case 8:
                case 9:
                case 10:
                    minValue = (2 * (this.getCartes().Count) / 3);    //Joue dans le dernier tier de sa main
                    maxValue = this.getCartes().Count;
                    break;
                default:
                    i = this.getCartes().Count-1;
                    break;
            }
            if (minValue < 0) { minValue = 0; } //Empeche d'avoir un index hors de la liste de carte
            if (maxValue > this.getCartes().Count) { maxValue = this.getCartes().Count; } //Empeche d'avoir un index hors de la liste de carte
            while (maxValue <= minValue) { maxValue++; }    //S'assure des bornes min et max de l'intervalle
            Carte C = null;
            while(C==null)
            {
                i=r.Next(minValue,maxValue);    //Choisi une carte aléatoirement dans l'intervalle défini
                C = this.getCarte(i);
            }
            return playCard(C); //Dès que C != null, on joue la carte
        }

        /// <summary>
        /// Joue une carte en fonction de la valeur la carte en jeu
        /// </summary>
        /// <param name="currentCarte"> Carte en jeu </param>
        /// <param name="cartPlayed"> Tableau des cartes déjà jouées par les joueurs </param>
        /// <param name="nbJoueur"> Nombre de joueur dans la partie </param>
        /// <returns> La carte à jouée </returns>
        public Carte playSmart(Carte currentCarte, int[] cartPlayed, int nbJoueur)
        {
            switch (currentCarte.getValue())
            {
                //Pour une carte de -2 à 2, on joue les cartes de 1 à 5
                case -2:
                case -1:
                case 1:
                case 2:
                    return playCardInRank(1, 5, cartPlayed, nbJoueur);
                //Pour une carte de -4, -3 ou 3, 4, on joue les cartes de 6 à 9
                case -4:
                case -3:
                case 3:
                case 4:
                    return playCardInRank(6, 9, cartPlayed, nbJoueur);
                //Pour une carte de -5 ou 5 à 7, on joue les cartes de 9 à 13
                case -5:
                case 5:
                case 6:
                case 7:
                    return playCardInRank(9, 13, cartPlayed, nbJoueur);
                //Pour une carte de 8 à 10, on joue les cartes de 13 à 15
                case 8:
                case 9:
                case 10:
                    return playCardInRank(13, 15, cartPlayed, nbJoueur);
            }
            return null;
        }

        /// <summary>
        /// Joue une carte en fonction de la valeur la carte en jeu
        /// </summary>
        /// <param name="currentCarte"> Carte en jeu </param>
        /// <param name="cartPlayed"> Tableau des cartes déjà jouées par les joueurs </param>
        /// <param name="nbJoueur"> Nombre de joueur dans la partie </param>
        /// <returns> La carte à jouée </returns>
        public Carte playEasy(Carte currentCarte, int[] cartPlayed, int nbJoueur)
        {
            switch (currentCarte.getValue())
            {
                //Pour une carte de -2 à 2, on joue les cartes de 9 à 15
                case -2:
                case -1:
                case 1:
                case 2:
                    return playCardInRank(9, 15, cartPlayed, nbJoueur);
                //Pour une carte de -4, -3 ou 3, 4, on joue les cartes de 9 à 13
                case -4:
                case -3:
                case 3:
                case 4:
                    return playCardInRank(7, 13, cartPlayed, nbJoueur);
                //Pour une carte de -5 ou 5 à 7, on joue les cartes de 4 à 9
                case -5:
                case 5:
                case 6:
                case 7:
                    return playCardInRank(3, 7, cartPlayed, nbJoueur);
                //Pour une carte de 8 à 10, on joue les cartes de 1 à 4
                case 8:
                case 9:
                case 10:
                    return playCardInRank(1, 4, cartPlayed, nbJoueur);
            }
            return null;
        }

        
        /// <summary>
        /// Joue une carte en fonction d'un intervalle donnée
        /// Le choix de la carte se fait en fonction des cartes déjà jouées
        /// </summary>
        /// <param name="min"> valeur minimal de la carte </param>
        /// <param name="max"> valeur maximal de la carte </param>
        /// <param name="CartPlayed"> Tableau des cartes déjà jouées </param>
        /// <param name="nbJoueur"> Nombre de joueur de la partie </param>
        /// <returns> La carte jouée </returns>
        public Carte playCardInRank(int min, int max, int[] CartPlayed, int nbJoueur)
        {
            //Verification des bornes sup et inf
            if (min > max) { int tmp = min; min = max; max = tmp; }

            //Verification qu'il y a au moins une carte dans l'intervalle
            while(!isInRank(min,max))
            {
                if (max <14) { max++; } //Sinon on grandi l'intervalle
                else if (min > 1) { min--; }
            }

            int c = min;
            for (int i = min+1; i <= max; i++)
            {
                if (CartPlayed[i] > CartPlayed[c] ) { c = i ; } //Recherche de la carte la plus jouer parmis l'intervalle
            }

            Carte carteAJouer;
            Random rand = new Random();
            int r = rand.Next(100);     //Modifie la valeur de la carte choisi de facon aléatoire
            if (r < 10 && nbJoueur == 5) { c -= 2; }    // 10% des cas : -2 (seulement a 5 joueurs)
            else if (r >= 10 && r < 30) { c -= 1; }                // 20% des cas : -1
            else if (r >= 30 && r < 70) { }                         // 40% des cas : +0
            else if (r >= 70 && r < 90) { c += 1; }                // 20% des cas : +1
            else if (r >= 90 && nbJoueur == 5) { c += 2; }         // 10% des cas : +2 (seulement à 5 joueurs)
            if (c < 1) { c = 1; }   //Plus basse carte jouable
            else if (c > 15) { c = 15; }    //Plus grande carte jouable

            do
            {
                carteAJouer = this.playCardByValue(c);  //Joue la valeur defini precedement
                if (c < max) { c++; }   //Joue la carte au dessus si celle choisi n'est pas disponible
                else c = min;           //Retourne au debut de l'intervalle si la fin a été atteinte
            }
            while (carteAJouer == null);    //Permet de s'assurer de trouver une carte

            return carteAJouer;  
        }

        /// <summary>
        /// Joue la carte de valeur value si dispo dans la main
        /// Si elle n'est pas disponible on renvoi null
        /// </summary>
        /// <param name="value">Valeur de la carte à jouer</param>
        /// <returns> La carte à jouée </returns>
        public Carte playCardByValue(int value)
        {
            foreach (Carte C in this.getCartes())
            {
                if (C.getValue() == value)
                {
                    return playCard(C);
                }
            }
            return null;
        }

        private bool isInRank(int min, int max) //Verifie qu'il existe bien au moins une carte dont la valeur est comprise entre les bornes min et max
        {
            foreach (Carte c in this.getCartes())
            {
                if (c.getValue() >= min && c.getValue() <= max) { return true; } //If present, return true
            }
            return false; //if no card present, return false
        }

        public Common.Difficulty getDifficulty()
        {
            return this.difficulty;
        }
    }
}
