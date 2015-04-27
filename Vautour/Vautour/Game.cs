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

        private int[] cartePlayed;

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

        public void playTurn()
        {
            Random r = new Random();
            int rang = r.Next(sabot.Count);
            currentCarte = sabot[rang];
            plateau.pb_Pot.Image = plateau.sabotDeCartesP.Images[sabot[rang].getIndexImage()];
            sabot.RemoveAt(rang);
        }

        public void playIAs()
        {
            for (int i = 0; i < players.Count() - 1; i++)
            {
                ((IA)players[i]).play(this);
                System.Threading.Thread.Sleep(10);
            }
            plateau.displayCards(players.Count - 1);
        }

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
                    p.Add(tmp[i]);
                }
            }
            if (p.Count != 0)
            {
                if (currentCarte.getType() == 1)
                {
                    winner = p[0];
                    for (int i = 1; i < p.Count; i++)
                    {
                        if (p[i].getLastCardPlayed().getValue() > winner.getLastCardPlayed().getValue())
                        {
                            winner = p[i];
                        }
                    }
                    return winner;
                }
                else
                {
                    winner = p[0];
                    for (int i = 1; i < p.Count; i++)
                    {
                        if (p[i].getLastCardPlayed().getValue() < winner.getLastCardPlayed().getValue())
                        {
                            winner = p[i];
                        }
                    }
                    return winner;
                }
            }
            else return null;
        }

        public void addScore(Player turnWinner)
        {
            if (turnWinner != null)
            {
                for (int i = 0; i < players.Count(); i++)
                {
                    if (turnWinner.Equals(players[i]))
                    {
                        players[i].setScore(currentCarte.getValue());
                        plateau.displayTextLbWinner(players[i].getNom() + " prend la carte,\nil a maintenant " + players[i].getScore() + " points");
                        plateau.majDisplayScore();
                    }
                }
                if (sabot.Count == 0)
                {
                    Player playWinner = getWinner();
                    plateau.displayMessage("La partie est fini, le joueur " + playWinner.getNom() + " remporte la partie avec " + playWinner.getScore().ToString() + " points. Bravo à lui");
                    Application.Restart();
                }
            }
            else
            {
                plateau.displayTextLbWinner("Aucun joueur ne prend cette carte,\nil y a surement égalité.");
            }
        }

        private Player getWinner()
        {
            Player winner = players[0];
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].getScore() > winner.getScore())
                {
                    winner = players[i];
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
    }
}
