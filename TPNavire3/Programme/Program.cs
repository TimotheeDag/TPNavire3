using NavireHeritage.classesMetier;
using NavireHeritage.ClassesMetier;
using NavireHeritage.ClassesTechniques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage
{
    class Program
    {
        static void Main()
        {
            try
            {




                Port Marseille = new Port("Marseille", "43.2976N", "5.3471E", 1, 3, 2, 4);
                //Test.ChargementIinitial(Marseille);
                Console.WriteLine(Marseille);
                Cargo cargo = new Cargo("IMO9780859", "cargo", "43.43279 N", "134.76258 W", "marchandises diverses",140872, 148992, 12300);
                Cargo cargo1 = new Cargo("IMO9250098", "cargo1", "54.35412 N", "5.3644 E", "Matériel de loisirs",10499, 13965, 11000);
                Cargo cargo2= new Cargo("IMO9502910", "cargo2", "54.72202 N", "170.54304 W", "marchandises diverses", 141754, 141189, 13700);
                Tanker Tanker = new Tanker("IMO9755932", "Tanker", "39.74224 N", "5.99304 E", "Matériel industriel", 193489, 202036, 13000);
                Tanker superTanker = new Tanker("IMO9755933", "superTanker", "39.74224 N", "5.99304 E", "Matériel industriel", 193489, 202036, 176000 );
                Tanker superTanker2 = new Tanker("IMO9755934", "superTanker2", "39.74224 N", "5.99304 E", "Matériel industriel", 193489, 202036, 176000);
                Tanker superTanker3 = new Tanker("IMO9755935", "superTanker3", "39.74224 N", "5.99304 E", "Matériel industriel", 193489, 202036, 176000);
                Croisiere croisiere = new Croisiere("IMO9305893", "croisiere", "41.50706 N", "11.41972 E",17665, 22033, 7500, 'V' , 10000);

                //Test.AfficheAttendus(Marseille);

                Test.TestEnregistrerArriveePrevue(Marseille, croisiere);
                Test.TestEnregistrerArriveePrevue(Marseille, cargo1);
                Test.TestEnregistrerArriveePrevue(Marseille, cargo2);
                Test.TestEnregistrerArriveePrevue(Marseille, Tanker);
                Test.TestEnregistrerArriveePrevue(Marseille, superTanker);
                Test.TestEnregistrerArriveePrevue(Marseille, superTanker2);


                Console.WriteLine("\n-------------------------Arrivé--------------------------");

                /*		 
                 * enregistrement de l'arrivée d'un Navire de la classe Croisiere
                 * Il y a toujours de la place.
                 */
                Test.TestEnregistrerArrivee(Marseille, croisiere);

                /*
                 *  Dans ce test, on essaie d'enregistrer l'arrivée d'un navire
                 *  qui n'est pas attendu dans le Marseille 
                 *  */
                Test.TestEnregistrerArrivee(Marseille, cargo);

                /**
                 * Dans ce test, on essaie d'enregistrer l'arrivée d'un navire 
                 * qui est déjà dans le Marseille 
                 */
                Test.TestEnregistrerArrivee(Marseille, cargo2);
                /**
                 * Dans ce test, on enregistre l'arrivée d'un petit tanker attendu
                 * et il y a de la place. 
                 */
                Test.TestEnregistrerArrivee(Marseille, Tanker);
                /*
                 * On rajoute 2 super tankers qui sont attendus, 
                 */
                Test.TestEnregistrerArrivee(Marseille, superTanker);
                Test.TestEnregistrerArrivee(Marseille, superTanker2);

                /*
                * Arrivée d'un super tanker attendu , il doit être mis en attente
                */
                Test.TestEnregistrerArrivee(Marseille, superTanker3);

                Console.WriteLine(Marseille);


                Console.WriteLine("\n-------------------------Départ--------------------------");

                /*
                 * On essaie de faire partir un navire qui n'est pas arrivé
                 */
                Test.TestEnregistrerDepart(Marseille, cargo);

                /*
                 * On fait partir le navire de croisière, 
                 * il y a toujours ls super tanker en attente
                 */
                Test.TestEnregistrerDepart(Marseille, croisiere);

                /*
                 * On fait partir le tanker, 
                 * le super tanker doit rester en attente
                 */
                Test.TestEnregistrerDepart(Marseille, Tanker);

                /*
                 * On fait partir le super tanker, celui en attente doit arriver
                 */
                Test.TestEnregistrerDepart(Marseille, superTanker2);

                Console.WriteLine(Marseille);

                Test.TestEnregistrerDepart(Marseille, cargo2);

                Console.WriteLine(Marseille);



            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur " + ex.Message);
            }
            Console.ReadKey();
        }
    }

}
