using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    internal class Tanker : Navire
    {
        private string typeFluide;

        public Tanker(string typeFluide, string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel) : base(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel)
        {
            this.TypeFluide = typeFluide;
        }

        protected string TypeFluide { get => typeFluide; set => typeFluide = value; }

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
