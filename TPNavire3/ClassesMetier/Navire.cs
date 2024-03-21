using GestionNavire.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    internal class Navire
    {
        private readonly string imo;
        private readonly string nom;
        private string latitude;
        private string longitute;
        private readonly int tonnageGT;
        private readonly int tonnageDWT;
        private int tonnageActuel;

        public Navire(string imo, string nom, string latitude, string longitude, int tonnageDWT, int tonnageActuel, int tonnageGT)
        {
            this.imo = imo;
            this.nom = nom;
            this.Latitude = latitude;
            this.Longitute = longitude;
            this.tonnageDWT = tonnageDWT;
            this.TonnageActuel = tonnageActuel;
            this.tonnageGT = tonnageGT;

        }

        public string Imo{ get => imo; }
        public string Nom { get => nom; }
        public int TonnageGT { get => tonnageGT; }
        public int TonnageDWT { get => tonnageDWT; }
        public int TonnageActuel { get => tonnageActuel; set => tonnageActuel = value; }
        public string Longitute { get => longitute; set => longitute = value; }
        public string Latitude { get => latitude; set => latitude = value; }

        public string Affiche(Navire navire)
        {
            return ($" Identification : {navire.imo.ToString()}\n" +
                $" Nom : {navire.nom.ToString()}\n" +
                $" tonnageDT : {navire.tonnageGT.ToString()}\n" +
                $" TonnageActuel : {navire.tonnageActuel.ToString()}\n" +
                $" tonnageDWT : {navire.tonnageDWT.ToString()}\n" +
                $" latitude : {navire.latitude.ToString()}\n" +
                $" longitute : {navire.longitute.ToString()}\n" +
                $"----------------------------------");
        }

    }
}
