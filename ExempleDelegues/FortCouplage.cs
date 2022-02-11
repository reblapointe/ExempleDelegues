using System;
using System.Threading;

namespace ExempleDelegues
{
    class OgreFortCouplage
    {
        static readonly Random r = new Random();
        public FortCouplage imprimeur { get; set; }
        public string Nom { get; set; }

        public void Manger(string plat)
        {
            // Manger le plat
            Thread.Sleep(r.Next(2000));
            imprimeur.Imprimer($"{Nom} mange {plat}.");
        }
    }
    class FortCouplage
    {
        public void ExempleFortCouplage()
        {
            OgreFortCouplage[] ogres = {
                new OgreFortCouplage { Nom = "Bleuzrog", imprimeur = this },
                new OgreFortCouplage { Nom = "Irok", imprimeur = this },
                new OgreFortCouplage { Nom = "Kaakur", imprimeur = this } };

            string[] plats = { "Cheval", "Jambon", "Cervelle", "Caviar", "Camembert", "Saindoux", "Beurre de pinotte", "Rhum", "Artichaut", "Mais", "Langouste", "Chataîgne" };
            for (int i = 0; i < plats.Length / ogres.Length; i++)
                for (int j = 0; j < ogres.Length; j++)
                    ogres[j].Manger(plats[ogres­.Length * i + j]);

        }

        public void Imprimer(string s)
        {
            Console.WriteLine(s);
        }
    }
}
