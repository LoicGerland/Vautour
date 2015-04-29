using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vautour
{
    public class Common
    {
        /// <summary>
        /// Difficulté de l'IA
        /// </summary>
        public enum Difficulty { Facile,Intermédiaire,Difficile,ChuckNorris};

        /// <summary>
        /// Type de carte
        /// </summary>
        public enum TypeCarte {Standard,Souris,Vautour};

        /// <summary>
        /// Couleur des cartes
        /// </summary>
        public enum ColorCarte { Rouge, Bleu, Jaune, Vert, Noir,Pot };
    }
}
