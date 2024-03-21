//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NavireHeritage.classesMetier
//{
//    internal class Croisiere : Navire
//    {
//        private string typeNavireCroisiere;
//        private int nbPassagersMaxi;
//        private Dictionary<String, Passager> passagers;

//        public Croisiere(string typeNavireCroisiere, int nbPassagersMaxi, Dictionary<string, Passager> passagers, string imo, string nom, string latitude, string longitude, int tonnageGT, int tonnageDWT, int tonnageActuel) : base(imo, nom, latitude, longitude, tonnageGT, tonnageDWT, tonnageActuel)
//        {
//            this.TypeNavireCroisiere = typeNavireCroisiere;
//            this.NbPassagersMaxi = nbPassagersMaxi;
//            this.Passagers = passagers;
//        }

//        public string TypeNavireCroisiere { get => typeNavireCroisiere; set => typeNavireCroisiere = value; }
//        public int NbPassagersMaxi { get => nbPassagersMaxi; set => nbPassagersMaxi = value; }
//        internal Dictionary<string, Passager> Passagers { get => passagers; set => passagers = value; }

//        public Croisiere(string typeNavireCroisiere, int nbPassagersMaxi,
//        public void Embarquer(List<Object> list)
//        {

//        }

//        public void debarquer(List<Object> list) 
//        {
            
//        }
//    }
//}

