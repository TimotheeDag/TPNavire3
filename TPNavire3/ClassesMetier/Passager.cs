using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    internal class Passager
    {
        private int numPasseport;
        private readonly string nom;
        private string prenom;
        private string nationalite;

        public Passager(int numPasseport, string nom, string prenom, string nationalite)
        {
            this.numPasseport = numPasseport;
            this.nom = nom;
            this.prenom = prenom;
            this.nationalite = nationalite;
        }

        public int NumPasseport { get => numPasseport; }
        public string Nom { get => nom; }
        public string Prenom { get => prenom;}
        public string Nationalite { get => nationalite;}

    }
}
