using System;

namespace ExempleDelegues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\nFaible cohesion :(");
           // new FaibleCohesion().ExempleFaibleCohesion();

            Console.WriteLine("\n\nFort couplage :(");
           // new FortCouplage().ExempleFortCouplage();

            Console.WriteLine("\n\nObservateur :)");
            new Observateur().ExempleObservateur();

            Console.WriteLine("\n\nDélégués :)");
            new Delegues().ExempleDelegues();

            Console.WriteLine("\n\nDélégués Action :)");
            new DeleguesAction().ExempleDeleguesAction();
        }
    }
}
