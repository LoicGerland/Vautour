using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vautour
{
    public class Carte
    {
        private int value;   //Valeur de la carte

        private int indexImage; //Valeur de l'index dans le sabot pour récupérer l'image

        private Common.ColorCarte color; //Couleur de la carte

        private Common.TypeCarte type; //Type de la carte

        public Carte(int v, int index, Common.ColorCarte c,Common.TypeCarte t)
        {
            this.value = v;
            this.indexImage = index;
            this.color = c;
            this.type = t;
        }

        public int getValue()
        {
            return this.value;
        }

        public int getIndexImage()
        {
            return this.indexImage;
        }

        public Common.ColorCarte getCouleur()
        {
            return this.color;
        }

        public Common.TypeCarte getType()
        {
            return this.type;
        }
    }
}
