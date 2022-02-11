using System;
using System.Collections.Generic;
using System.Threading;

namespace ExempleDelegues
{
    interface IObservateurOgre
    {
        void MettreAJour(OgreObservateur ogre);
    }
    class OgreObservateur
    {
        static readonly Random r = new Random();

        private List<IObservateurOgre> observers = new List<IObservateurOgre>();

        public string Plat { get; set; }
        public string Nom { get; set; }

        public void Manger(string plat)
        {
            // Manger le plat
            Plat = plat;

            foreach (IObservateurOgre observer in observers)
                observer.MettreAJour(this);

            Thread.Sleep(r.Next(2000));
            Plat = "";
        }

        public void AddObserver(IObservateurOgre observateur)
        {
            observers.Add(observateur);
        }
    }
    class Observateur : IObservateurOgre
    {
        public void ExempleObservateur()
        {
            OgreObservateur[] ogres = {
                new OgreObservateur { Nom = "Bleuzrog" },
                new OgreObservateur { Nom = "Irok" },
                new OgreObservateur { Nom = "Kaakur" }};

            foreach (OgreObservateur o in ogres)
                o.AddObserver(this);

            string[] plats = { "Cheval", "Jambon", "Cervelle", "Caviar", "Camembert", "Saindoux", "Beurre de pinotte", "Rhum", "Artichaut", "Mais", "Langouste", "Chataîgne"};
            for (int i = 0; i < plats.Length / ogres.Length; i++)
                for(int j = 0; j < ogres.Length; j++)
                    ogres[j].Manger(plats[ogres­.Length * i + j]);

        }

        public void MettreAJour(OgreObservateur ogre)
        { 
            Console.WriteLine($"{ogre.Nom} mange {ogre.Plat}.");
        }
    }
}
