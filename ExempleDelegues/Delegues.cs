using System;
using System.Collections.Generic;
using System.Threading;

namespace ExempleDelegues
{
    delegate void MettreAJour(OgreDelegue ogre);

    class OgreDelegue
    {
        static readonly Random r = new Random();

        private MettreAJour observers;

        public string[] Table { get; set; }
        public string Plat { get; set; }
        public string Nom { get; set; }

        public void Manger(string plat)
        {
            // Manger le plat
            Plat = plat;
            observers.Invoke(this);
            Thread.Sleep(r.Next(1000));

            Plat = "";
        }
        
        public void Manger()
        {
            for (int i = 0; i < 5; i++)
                Manger(Table[r.Next(Table.Length)]);
        }

        public void AddObserver(MettreAJour observer)
        {
            observers += observer;
        }
    }
    class Delegues
    {
        public void ExempleDelegues()
        {
            string[] plats = { "Cheval", "Jambon", "Cervelle", "Caviar", "Camembert", "Saindoux", "Beurre de pinotte", "Rhum", "Artichaut", "Mais", "Langouste", "Chataîgne" };

            OgreDelegue[] ogres = {
                new OgreDelegue { Nom = "Bleuzrog", Table = plats },
                new OgreDelegue { Nom = "Irok", Table = plats },
                new OgreDelegue { Nom = "Kaakur", Table = plats }};



            foreach (OgreDelegue o in ogres)
                o.AddObserver(Imprimer);

            // OU

            //foreach (OgreDelegue o in ogres)
            //    o.AddObserver(o => Console.WriteLine($"{o.Nom} mange {o.Plat}."));

            for (int j = 0; j < ogres.Length; j++)
                ogres[j].Manger();
        }

        public void Imprimer(OgreDelegue ogre)
        { 
            Console.WriteLine($"{ogre.Nom} mange {ogre.Plat}.");
        }
    }
}
