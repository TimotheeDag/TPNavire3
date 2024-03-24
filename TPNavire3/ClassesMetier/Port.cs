// <copyright file="Port.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using GestionNavire.Exceptions;
using NavireHeritage.classesMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private Dictionary<string, Navire> navireEnAttente = new Dictionary<string, Navire>();

        public Port(string nom, string latitude, string longitude, int nbPortique, int nbQuaisTanker, int nbQuaisSuperTanker, int nbQuaisPassager /*Dictionary<string, Navire> navireAttendus, Dictionary<string, Navire> navireArrives, Dictionary<string, Navire> navirePartis, Dictionary<string, Navire> navireEnAttente*/)
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
        internal Dictionary<string, Navire> NavireEnAttente { get => navireEnAttente; set => navireEnAttente = value; }
        internal Dictionary<string, Navire> NavirePartis { get => navirePartis; set => navirePartis = value; }

        public override string ToString()
        {
            return "\nport de " + this.nom + "\n\tCoordonnées GPS:" + this.latitude + " / " + this.longitude +
                "\n\tNb portiques restant: " + this.nbPortique +
                "\n\tNb quais croisière restant: " + this.nbQuaisPassager +
                "\n\tnb quais tankers restant: " + this.nbQuaisTanker +
                "\n\tnb quais super tankers restant: " + this.nbQuaisSuperTanker +
                "\n\tnb Navire à quais: " + navireArrives.Count +
                "\n\tNb Navires attendus: " + navireAttendus.Count +
                "\n\tNb Navires en attente: " + navireEnAttente.Count +
                "\n\nNb cargos dans le port: " + GetCargo() +
                "\nNb tanker dans le port: " + GetNbTanker() +
                "\nNb super tanker dans le port: " + GetSuperTanker() +
                "\nNb croisère dans le port: " + GetCroisière();



        }

        public int GetCargo()
        {
            int i= 0;
            foreach (Navire nav in navireArrives.Values)
            {
                if (nav is Cargo)
                {
                    i++;
                }
            }
            return i;
        }

        public int GetNbTanker()
        {
            int i = 0;
            foreach (Navire nav in navireArrives.Values)
            {
                if (nav is Tanker && nav.TonnageGT <= 130000)
                {
                    i++;
                }
            }
            return i;
        }

        public int GetSuperTanker()
        {
            int i = 0;
            foreach (Navire nav in navireArrives.Values)
            {
                if (nav.TonnageGT > 130000 && nav is Tanker )
                {
                    i++;
                }
            }
            return i;
        }
        public int GetCroisière()
        {
            int i = 0;
            foreach (Navire nav in navireArrives.Values)
            {
                if (nav is Croisiere)
                {
                    i++;
                }
            }
            return i;
        }


        public void EnregistrerArriveePrevue(Navire navire)
        {
            navireAttendus.Add(navire.Imo, navire);
        }


        public void EnregistrerArrivee(Navire navire)
        {
            if (navireAttendus.ContainsKey(navire.Imo)){
                foreach (Navire nav in navireAttendus.Values)
                {
                    if (navire is Croisiere)
                    {
                        navireArrives.Add(navire.Imo, navire);
                        navireAttendus.Remove(navire.Imo);
                        break;

                    }
                    else if (navire is Tanker && NbQuaisTanker > 0 && navire.TonnageGT < 130000)
                    {
                        navireArrives.Add(navire.Imo, navire);
                        navireAttendus.Remove(navire.Imo);
                        NbQuaisTanker--;
                        break;

                    }
                    else if (navire is Cargo && NbPortique > 0)
                    {
                        navireArrives.Add(navire.Imo, navire);
                        navireAttendus.Remove(navire.Imo);
                        NbPortique -- ;
                        break;
                        

                    }
                    else if (NbQuaisSuperTanker > 0)
                    {
                        navireArrives.Add(navire.Imo, navire);
                        navireAttendus.Remove(navire.Imo);
                        NbQuaisSuperTanker--;
                        break;

                    }
                    else
                    {
                        throw new Exception("plus de place dans le port !");
                    }
                }
            }
            else
            {
                navireEnAttente.Add(navire.Imo, navire);
                throw new GestionPortException("Navire non prévu part le port, mise en attente du navire " + navire.Imo);

            }
        }

        public void EnregistrerDepart(Navire navire)
        {
            if (navireArrives.ContainsKey(navire.Imo))
            {
                if (navire is Croisiere)
                {
                    navirePartis.Add(navire.Imo, navire);
                    navireArrives.Remove(navire.Imo);
                }
                else if (navire is Tanker && navire.TonnageGT < 130000)
                {
                    navirePartis.Add(navire.Imo, navire);
                    navireArrives.Remove(navire.Imo);
                    NbQuaisTanker ++ ;
                }
                else if (navire is Cargo )
                {
                    navirePartis.Add(navire.Imo, navire);
                    navireArrives.Remove(navire.Imo);
                    NbPortique ++ ;
                }
                else
                {
                    navirePartis.Add(navire.Imo, navire);
                    navireArrives.Remove(navire.Imo);
                    NbQuaisSuperTanker ++ ;
                }

                foreach (Navire nav in navireEnAttente.Values)
                {
                    if (nav.TonnageGT > 130000 && navire is Tanker && NbQuaisSuperTanker > 0)
                    {
                        navireArrives.Add(nav.Imo, navire);
                        navireEnAttente.Remove(nav.Imo);
                        NbQuaisSuperTanker--;
                        Console.WriteLine("le super Tanker: " + nav.Imo +" en attente a été admis au port car le navire " + navire.Imo + " est parti");
                        break;
                    }
                    else if (nav is Cargo && NbPortique > 0)
                    {
                        navireArrives.Add(nav.Imo, navire);
                        navireEnAttente.Remove(nav.Imo);
                        NbPortique --;
                        Console.WriteLine("le Cargo: " + nav.Imo + " en attente a été admis au port car le navire " + navire.Imo + " est parti");
                        break;

                    }
                    else if (nav is Tanker && NbQuaisTanker != 0 && navire.TonnageGT < 130000)
                    {
                        navireArrives.Add(nav.Imo, navire);
                        navireEnAttente.Remove(nav.Imo);
                        NbQuaisTanker --;
                        Console.WriteLine("le tanker: " + nav.Imo + " en attente a été admis au port car le navire " + navire.Imo + " est parti");
                        break;

                    }
                }
            }
            else
            {
                throw new GestionPortException("La navire "+ navire.Imo +" n'est pas dans le port !");
            }
        }
    }
}

