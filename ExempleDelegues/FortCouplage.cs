using System;
using System.Threading;

namespace ExempleDelegues
{
    class OgreFortCouplage
    {
        static readonly Random r = new Random();

        public FortCouplage imprimeur { get; set; }


        public string[] Table { get; set; }
        public string Plat { get; set; }
        public string Nom { get; set; }


        public void Manger(string plat)
        {
            // Manger le plat
            Plat = plat;

            imprimeur.Imprimer($"{Nom} mange {plat}.");

            Thread.Sleep(r.Next(1000));
            Plat = "";
        }

        public void Manger()
        {
            for (int i = 0; i < 5; i++)
                Manger(Table[r.Next(Table.Length)]);
        }
    }
    class FortCouplage
    {
        public void ExempleFortCouplage()
        {
            string[] plats = { "Cheval", "Jambon", "Cervelle", "Caviar", "Camembert", "Saindoux", "Rhum", "Artichaut", "Langouste", "Chataîgne" };

            OgreFortCouplage[] ogres = {
                new OgreFortCouplage { Nom = "Bleuzrog", imprimeur = this, Table = plats },
                new OgreFortCouplage { Nom = "Irok", imprimeur = this, Table = plats },
                new OgreFortCouplage { Nom = "Kaakur", imprimeur = this, Table = plats } };

            for (int j = 0; j < ogres.Length; j++)
                ogres[j].Manger();

        }

        public void Imprimer(string s)
        {
            Console.WriteLine(s);
        }
    }
}
