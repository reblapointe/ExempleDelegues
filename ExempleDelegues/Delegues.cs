﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace ExempleDelegues
{
    delegate void MettreAJour(OgreDelegue ogre);

    class OgreDelegue
    {
        static readonly Random r = new Random();

        private MettreAJour observers;

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

        public void AddObserver(MettreAJour observer)
        {
            observers += observer;
        }
    }
    class Delegues
    {
        public void ExempleDelegues()
        {
            OgreDelegue[] ogres = {
                new OgreDelegue { Nom = "Bleuzrog" },
                new OgreDelegue { Nom = "Irok" },
                new OgreDelegue { Nom = "Kaakur" }};

            foreach (OgreDelegue o in ogres)
                o.AddObserver(Imprimer);

            // OU

            //foreach (OgreDelegue o in ogres)
            //s    o.AddObserver(o => Console.WriteLine($"{o.Nom} mange {o.Plat}."));

            string[] plats = { "Cheval", "Jambon", "Cervelle", "Caviar", "Camembert", "Saindoux", "Beurre de pinotte", "Rhum", "Artichaut", "Mais", "Langouste", "Chataîgne"};
            for (int i = 0; i < plats.Length / ogres.Length; i++)
                for(int j = 0; j < ogres.Length; j++)
                    ogres[j].Manger(plats[ogres­.Length * i + j]);

        }

        public void Imprimer(OgreDelegue ogre)
        { 
            Console.WriteLine($"{ogre.Nom} mange {ogre.Plat}.");
        }
    }
}
