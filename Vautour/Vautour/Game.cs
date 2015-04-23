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

        public void playIAs()
        {
            for (int i = 0; i < players.Count() - 1; i++)
            {
                ((IA)players[i]).play();
                System.Threading.Thread.Sleep(10);
            }
            plateau.displayCards(players.Count - 1);
        }

        public Player checkTurn()
        {
            List<Player> p = new List<Player>();
            List<Player> tmp = this.players;
            Player winner = null;
            bool _double = false;

            for (int i = 0; i < tmp.Count; i++)
            {
                _double = false;
                for (int j = i + 1; j < tmp.Count; j++)
                {
                    if (tmp[i].getLastCardPlayed().getValue() == tmp[j].getLastCardPlayed().getValue())
                    {
                        _double = true;
                        tmp.RemoveAt(j);                        
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
                    p.Add(players[i]);
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
