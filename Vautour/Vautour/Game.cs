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

        public Carte currentCarte; //Carte actuellement en jeu

        public Game(List<Player> p,List<Carte> s,plateau plat)
        {
            this.players = p;
            this.sabot = s;
            this.plateau = plat;
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

        public Player checkTurn()
        {
            List<Player> p = new List<Player>();
            Player currentPlayer = null;
            Player winner = null;
            bool _double = false;

            for (int i = 0; i < players.Count; i++)
            {
                currentPlayer = players[i];

                for (int j = i+1; j < players.Count; j++)
                {
                    if (currentPlayer.getLastCardPlayed().getValue() == players[j].getLastCardPlayed().getValue())
                    {
                        players.RemoveAt(j);
                        _double = true;
                    }
                }
                if(_double)
                {
                    players.RemoveAt(i);
                    i = i - 1;
                    _double = false;
                }
                else
                {
                    p.Add(currentPlayer);
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
    }
}
