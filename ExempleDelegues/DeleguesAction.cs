using System;
using System.Collections.Generic;
using System.Threading;

namespace ExempleDelegues
{
    class OgreDelegueAction
    {
        static readonly Random r = new Random();

        private Action<OgreDelegueAction> observers;

        public string Plat { get; set; }
        public string Nom { get; set; }

        public void Manger(string plat)
        {
            // Manger le plat
            Plat = plat;
            observers.Invoke(this);
            Thread.Sleep(r.Next(2000));

            Plat = "";
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
            OgreDelegueAction[] ogres = {
                new OgreDelegueAction { Nom = "Bleuzrog" },
                new OgreDelegueAction { Nom = "Irok" },
                new OgreDelegueAction { Nom = "Kaakur" }};

            foreach (OgreDelegueAction o in ogres)
                o.AddObserver(Imprimer);

            // OU

            //foreach (OgreDelegueAction o in ogres)
            //    o.AddObserver(o => Console.WriteLine($"{o.Nom} mange {o.Plat}."));

            string[] plats = { "Cheval", "Jambon", "Cervelle", "Caviar", "Camembert", "Saindoux", "Beurre de pinotte", "Rhum", "Artichaut", "Mais", "Langouste", "Chataîgne"};
            for (int i = 0; i < plats.Length / ogres.Length; i++)
                for(int j = 0; j < ogres.Length; j++)
                    ogres[j].Manger(plats[ogres­.Length * i + j]);

        }

        public void Imprimer(OgreDelegueAction ogre)
        { 
            Console.WriteLine($"{ogre.Nom} mange {ogre.Plat}.");
        }
    }
}
