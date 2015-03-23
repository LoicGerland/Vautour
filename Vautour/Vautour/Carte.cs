using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vautour
{
    class Carte
    {
        private int value; //Valeur de la carte

        private int indexImage; //Valeur de l'index dans le sabot pour récupérer l'image

        private String couleur; //Couleur de la carte

        public Carte(int v, int index, String c)
        {
            this.value = v;
            this.indexImage = index;
            this.couleur = c;
        }

        public int getValue()
        {
            return this.value;
        }

        public int getIndexImage()
        {
            return this.indexImage;
        }

        public String getCouleur()
        {
            return this.couleur;
        }
    }
}
