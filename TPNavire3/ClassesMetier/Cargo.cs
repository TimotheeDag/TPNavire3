using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    internal class Cargo : Navire
    {
        private string typeFret;

        public Cargo(string typeFret, string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel) : base (imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel)
        {
            this.TypeFret = typeFret;
        }

        public string TypeFret { get => typeFret; set => typeFret = value; }

        public string Charger(int newValeur)
        {
            TonnageActuel += newValeur;
            return "tonnage actualisé";
        }

        public string Decharger(int newValeur)
        {
            TonnageActuel -= newValeur;
            return "tonnage actualisé";
        }
    }



    
}
