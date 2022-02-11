using System;
using System.Collections.Generic;
using System.Threading;

namespace ExempleDelegues
{
    class OgreDelegueAction
    {
        static readonly Random r = new Random();

        private Action<OgreDelegueAction> observers;
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

        public void AddObserver(Action<OgreDelegueAction> observer)
        {
            observers += observer;
        }
    }
    class DeleguesAction
    {
        public void ExempleDeleguesAction()
        {
            string[] plats = { "Cheval", "Jambon", "Cervelle", "Caviar", "Camembert", "Saindoux", "Beurre de pinotte", "Rhum", "Artichaut", "Mais", "Langouste", "Chataîgne" };

            OgreDelegueAction[] ogres = {
                new OgreDelegueAction { Nom = "Bleuzrog", Table = plats },
                new OgreDelegueAction { Nom = "Irok", Table = plats },
                new OgreDelegueAction { Nom = "Kaakur", Table = plats }};

            foreach (OgreDelegueAction o in ogres)
                o.AddObserver(Imprimer);

            // OU

            //foreach (OgreDelegueAction o in ogres)
            //    o.AddObserver(o => Console.WriteLine($"{o.Nom} mange {o.Plat}."));


            for (int j = 0; j < ogres.Length; j++)
                ogres[j].Manger();
        }

        public void Imprimer(OgreDelegueAction ogre)
        {
            Console.WriteLine($"{ogre.Nom} mange {ogre.Plat}.");
        }
    }
}
