﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vautour
{
    public class Human : Player
    {
        public Human(String n,List<Carte> m, int score) : base(n,m,score)
        {

        }

        public void play(int index)
        {
            Carte CP1 = getCarte(index);
            setLastCardPlayed(CP1);
            removeCarte(index);
        }
    }
}
