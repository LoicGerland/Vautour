using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Vautour
{
    class Game
    {
        private List<Player> players; //Joueurs de la partie

        private List<Carte> sabot; //Cartes du sabot (Souries ou vautour)

        private plateau plateau; //Plateau de jeu

        private Carte currentCarte; //Carte actuellement en jeu

        private int[] cartePlayed;  //Tableau contenant le nombre de carte jouer de chaque valeur

        public Game(List<Player> p,List<Carte> s,plateau plat)
        {
            this.players = p;
            this.sabot = s;
            this.plateau = plat;
            this.cartePlayed = new int[16];
        }

        public List<Player> getPlayers()
        {
            return this.players;
        }

        public List<Carte> getCartes()
        {
            return this.sabot;
        }

        public Carte getCurrentCartes()
        {
            return this.currentCarte;
        }

        /// <summary>
        /// Joue une carte du pot de maniere aléatoire
        /// </summary>
        public void playCarte()
        {
            Random r = new Random();
            int rang = r.Next(sabot.Count);
            currentCarte = sabot[rang];
            plateau.pb_Pot.Image = plateau.sabotDeCartesP.Images[sabot[rang].getIndexImage()];
            sabot.RemoveAt(rang);
        }

        /// <summary>
        /// Fait jouer les IAs chacuns à leur tour
        /// </summary>
        public void playIAs()
        {
            for (int i = 0; i < players.Count() - 1; i++)
            {
                ((IA)players[i]).play(this);
                System.Threading.Thread.Sleep(10);
            }
        }

        /// <summary>
        /// Retourne le joueur remportant la main ou null si égalité
        /// </summary>
        /// <returns> Joueur gagnant </returns>
        public Player checkTurn() 
        {
            List<Player> p = new List<Player>();
            List<Player> tmp = new List<Player>(this.players);
            Player winner = null;
            bool _double = false;

            for (int i = 0; i < tmp.Count; i++)
            {

                cartePlayed[tmp[i].getLastCardPlayed().getValue()]++;
                _double = false;
                for (int j = i + 1; j < tmp.Count; j++)
                {
                    if (tmp[i].getLastCardPlayed().getValue() == tmp[j].getLastCardPlayed().getValue())
                    {
                        _double = true;
                        tmp.RemoveAt(j);    
                        j--;
                    }
                }
                if(_double)
                {
                    tmp.RemoveAt(i);
                    _double = false;
                    i = i - 1;
                }
                else
                {
                    p.Add(tmp[i]);  //Creer une liste des joueurs ayant joué une carte unique
                }
            }
            if (p.Count != 0)
            {
                if (currentCarte.getType() == Common.TypeCarte.Souris)    //Cherche la carte la plus élevé pour choisir le gagnant de la carte souris
                {
                    winner = p[0];
                    for (int i = 1; i < p.Count; i++)
                    {
                        if (p[i].getLastCardPlayed().getValue() > winner.getLastCardPlayed().getValue())
                        {
                            winner = p[i];
                        }
                    }
                    return winner;  //retourne le gagne de la carte souris
                }
                else //Cherche la carte la plus faible pour choisir le gagnant de la carte vautour
                {
                    winner = p[0];
                    for (int i = 1; i < p.Count; i++)
                    {
                        if (p[i].getLastCardPlayed().getValue() < winner.getLastCardPlayed().getValue())
                        {
                            winner = p[i];
                        }
                    }
                    return winner;  //retourne le gagnant de la carte vautour
                }
            }
            else return null;   //retourne null en cas d'égalité
        }

        /// <summary>
        /// Ajoute le score au gagnant du tour
        /// </summary>
        /// <param name="turnWinner"> Gagnant du tour</param>
        public void addScore(Player turnWinner)
        {
            if (turnWinner != null)
            {
                for (int i = 0; i < players.Count(); i++)
                {
                    if (turnWinner.Equals(players[i])) //retrouve le gagnant dans la liste de joueur
                    {
                        players[i].setScore(currentCarte.getValue());   //Ajoute la valeur de la carte remporté a son score
                        plateau.displayTextLbWinner(players[i].getNom() + " prend la carte,\nil a maintenant " + players[i].getScore() + " points"); //Affiche en texte le gagnant et son nouveau score
                        plateau.majDisplayScore();  //MaJ des scores des joueurs
                        plateau.highLightPlayer(players.Count()-i); //Met en avant le gagnant de la main
                    }
                }
            }
            else
            {
                plateau.highLightPlayer(6);
                plateau.displayTextLbWinner("Aucun joueur ne prend cette carte,\nil y a surement égalité.");
            }
            if (sabot.Count == 0)   //Signifie que la partie est fini
            {
                Player playWinner = getWinner();    //Trouve le gagnant de la partie
                plateau.displayMessage("La partie est fini, le joueur " + playWinner.getNom() + " remporte la partie avec " + playWinner.getScore().ToString() + " points. Bravo à lui"); //Affiche dans un pop-up la fin de la partie et son vainqueur
                Application.Restart();  //Relance le menu une fois la partie fini
            }
        }

        /// <summary>
        /// Renvoie le joueur avec le score le plus élevé
        /// </summary>
        /// <returns> Gagnant de la partie</returns>
        private Player getWinner()
        {
            Player winner = players[0];
            for (int i = 1; i < players.Count; i++)
            {
                if (players[i].getScore() > winner.getScore())
                {
                    winner = players[i];
                    plateau.highLightPlayer(players.Count() - i); //Met en avant le vainqueur de la partie
                }
            }
            return winner;
        }

        public int[] getCartPlayed()
        {
            return this.cartePlayed;
        }

        public Carte getCurrentCarte()
        {
            return this.currentCarte;
        }

        /// <summary>
        /// Joue un tour
        /// </summary>
        /// <param name="indexP1"> Carte selectionner par le joueur</param>
        public void playTurn(int indexP1)
        {
            ((Human)players.Last()).play(indexP1); // Joue la carte de P1
            playIAs();  //Fait jouer les differents IA
            plateau.displayCards(players.Count);    //Affiche les cartes des joueurs
            addScore(checkTurn());  //Cherche le vainqueur de la main et affiche les nouveaux scores

        }
    }


}
