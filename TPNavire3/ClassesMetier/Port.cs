// <copyright file="Port.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using NavireHeritage.classesMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.ClassesMetier
{
    internal class Port
    {
        private string nom;
        private string latitude;
        private string longitude;
        private int nbPortique;
        private int nbQuaisTanker;
        private int nbQuaisSuperTanker;
        private int nbQuaisPassager;
        private Dictionary<string, Navire> navireAttendus = new Dictionary<string, Navire>();
        private Dictionary<string, Navire> navireArrives = new Dictionary<string, Navire>();
        private Dictionary<string, Navire> navirePartis= new Dictionary<string, Navire>();
        private Dictionary<string, Navire> navireenAttente = new Dictionary<string, Navire>();

        public Port(string nom, string latitude, string longitude, int nbPortique, int nbQuaisTanker, int nbQuaisSuperTanker, int nbQuaisPassager /*Dictionary<string, Navire> navireAttendus, Dictionary<string, Navire> navireArrives, Dictionary<string, Navire> navirePartis, Dictionary<string, Navire> navireenAttente*/)
        {
            this.nom = nom;
            this.latitude = latitude;
            this.longitude = longitude;
            this.nbPortique = nbPortique;
            this.nbQuaisTanker = nbQuaisTanker;
            this.nbQuaisSuperTanker = nbQuaisSuperTanker;
            this.nbQuaisPassager = nbQuaisPassager;
        }

        //public Port(string nom, string latitude, string longitude, int nbPortique, int nbQuaisTanker, int nbQuaisSuperTanker, int nbQuaisPassager) : this(nom, latitude, longitude, nbPortique, nbQuaisPassager, nbQuaisTanker, nbQuaisSuperTanker, nbQuaisPassager) { }


        public string Nom { get => nom; set => nom = value; }
        public string Latitude { get => latitude; set => latitude = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public int NbPortique { get => nbPortique; set => nbPortique = value; }
        public int NbQuaisTanker { get => nbQuaisTanker; set => nbQuaisTanker = value; }
        public int NbQuaisSuperTanker { get => nbQuaisSuperTanker; set => nbQuaisSuperTanker = value; }
        public int NbQuaisPassager { get => nbQuaisPassager; set => nbQuaisPassager = value; }
        internal Dictionary<string, Navire> NavireAttendus { get => navireAttendus; set => navireAttendus = value; }
        internal Dictionary<string, Navire> NavireArrives { get => navireArrives; set => navireArrives = value; }
        internal Dictionary<string, Navire> NavireenAttente { get => navireenAttente; set => navireenAttente = value; }
        internal Dictionary<string, Navire> NavirePartis { get => navirePartis; set => navirePartis = value; }

        public override string ToString()
        {
            return "port de" + this.nom + "\n\tCoordonnées GPS:" + this.latitude + " / " + this.longitude +
                "\n\tNb portiques: " + this.nbPortique +
                "\n\tNb quais croisière: " + this.nbQuaisPassager +
                "\n\tnb quais tankers: " + this.nbQuaisTanker +
                "\n\tnb quais super tankers: " + this.nbQuaisSuperTanker +
                "\n\tnb Navire à quais: " + navireArrives.Count +
                "\n\tNb Navires attendus: " + navireAttendus.Count +
                "\n\tNb Navires à partis: " + navireAttendus.Count +
                "\n\tNb Navires en attente: " + navireAttendus.Count; 

        }

        public int GetCargo(Navire navire)
        {
            int i= 0;
            foreach (Navire nav in navireArrives.Values)
            {
                if (navire is Cargo)
                {
                    i++;
                }
            }
            return i;
        }

        public int GetNbTanker(Navire navire)
        {
            int i = 0;
            foreach (Navire navire in navireArrives.Values)
            {
                if (navire is Tanker)
                {
                    i++;
                }
            }
            return i;
        }

        public int GetSuperTanker(Navire navire)
        {
            int i = 0;
            foreach (Navire navire in navireArrives.Values)
            {
                if (navire is superTanker)
                {
                    i++;
                }
            }
            return i;
        }

        public void EnregistrerArriveePrevue(Navire navire)
        {

        }
    }




}
