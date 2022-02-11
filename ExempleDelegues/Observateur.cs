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

        public string[] Table { get; set; }
        public string Plat { get; set; }
        public string Nom { get; set; }

        public void Manger(string plat)
        {
            // Manger le plat
            Plat = plat;

            foreach (IObservateurOgre observer in observers)
                observer.MettreAJour(this);

            Thread.Sleep(r.Next(1000));
            Plat = "";
        }

        public void Manger()
        {
            for (int i = 0; i < 5; i++)
                Manger(Table[r.Next(Table.Length)]);
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
            string[] plats = { "Cheval", "Jambon", "Cervelle", "Caviar", "Camembert", "Saindoux", "Beurre de pinotte", "Rhum", "Artichaut", "Mais", "Langouste", "Chataîgne" };

            OgreObservateur[] ogres = {
                new OgreObservateur { Nom = "Bleuzrog", Table = plats },
                new OgreObservateur { Nom = "Irok", Table = plats },
                new OgreObservateur { Nom = "Kaakur", Table = plats }};

            foreach (OgreObservateur o in ogres)
                o.AddObserver(this);

            foreach (OgreObservateur o in ogres)
                o.Manger();

        }

        public void MettreAJour(OgreObservateur ogre)
        { 
            Console.WriteLine($"{ogre.Nom} mange {ogre.Plat}.");
        }
    }
}
