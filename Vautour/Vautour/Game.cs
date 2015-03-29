using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vautour
{
    class Game
    {
        private List<Player> players; //Joueurs de la partie

        private List<Carte> sabot; //Cartes du sabot (Souries ou vautour)

        public Game(List<Player> p,List<Carte> s)
        {
            this.players = p;
            this.sabot = s;
        }

        public List<Player> getPlayers()
        {
            return this.players;
        }

        public List<Carte> getCartes()
        {
            return this.sabot;
        }
    }
}
