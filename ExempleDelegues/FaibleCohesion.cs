using System;
using System.Threading;

namespace ExempleDelegues
{
    class OgreFaibleCohesion
    {
        static readonly Random r = new Random();

        public string[] Table { get; set; }
        public string Plat { get; set; }
        public string Nom { get; set; }


        public void Manger(string plat)
        {
            // Manger le plat
            Plat = plat;

            Console.WriteLine($"{Nom} mange {plat}.");

            Thread.Sleep(r.Next(1000));
            Plat = "";
        }

        public void Manger()
        {
            for (int i = 0; i < 5; i++)
                Manger(Table[r.Next(Table.Length)]);

        }
    }

    class FaibleCohesion
    {
        public void ExempleFaibleCohesion()
        {
            string[] plats = { "Cheval", "Jambon", "Cervelle", "Caviar", "Camembert", "Saindoux", "Beurre de pinotte", "Rhum", "Artichaut", "Mais", "Langouste", "Chataîgne" };

            OgreFaibleCohesion[] ogres = {
                new OgreFaibleCohesion { Nom = "Bleuzrog", Table = plats },
                new OgreFaibleCohesion { Nom = "Irok", Table = plats },
                new OgreFaibleCohesion { Nom = "Kaakur", Table = plats }};

            for (int j = 0; j < ogres.Length; j++)
                ogres[j].Manger();

        }
    }
}
