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

        private String couleur; //Couleur de la carte

        private int type; //Type de la carte (0 : classique, 1 : souris, 2 : vautour)

        public Carte(int v, int index, String c,int t)
        {
            this.value = v;
            this.indexImage = index;
            this.couleur = c;
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

        public String getCouleur()
        {
            return this.couleur;
        }

        public int getType()
        {
            return this.type;
        }

        public String getStringByType()
        {
            switch (this.type)
            {
                case 0:
                    return "Classique";
                case 1:
                    return "Souris";
                case 2:
                    return "Vautour";
            }
            return null;
        }
    }
}
