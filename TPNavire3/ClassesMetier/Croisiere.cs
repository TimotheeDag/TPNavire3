using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    internal class Croisiere : Navire
    {
        private char typeNavireCroisiere;
        private int nbPassagersMaxi;

        public Croisiere(string nom, string imo,  string latitude, string longitude, int tonnageDT, int tonnageDWT, int tonnageActuel, char typeNavireCroisiere, int nbPassagersMaxi) : base(imo, nom, latitude, longitude, tonnageDT, tonnageDWT, tonnageActuel)
        {
            this.TypeNavireCroisiere = typeNavireCroisiere;
            this.NbPassagersMaxi = nbPassagersMaxi;
        }

        public char TypeNavireCroisiere { get => typeNavireCroisiere; set => typeNavireCroisiere = value; }
        public int NbPassagersMaxi { get => nbPassagersMaxi; set => nbPassagersMaxi = value; }
    }
}
