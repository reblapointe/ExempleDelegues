using System;
using System.Threading;

namespace ExempleDelegues
{
    class OgreFaibleCohesion
    {
        static readonly Random r = new Random();
        public string Nom { get; set; }

        public void Manger(string plat)
        {
            // Manger le plat
            Thread.Sleep(r.Next(2000));
            Console.WriteLine($"{Nom} mange {plat}.");
        }
    }
    class FaibleCohesion
    {
        public void ExempleFaibleCohesion()
        {
            OgreFaibleCohesion[] ogres = {
                new OgreFaibleCohesion { Nom = "Bleuzrog" },
                new OgreFaibleCohesion { Nom = "Irok" },
                new OgreFaibleCohesion { Nom = "Kaakur" }};

            string[] plats = { "Cheval", "Jambon", "Cervelle", "Caviar", "Camembert", "Saindoux", "Beurre de pinotte", "Rhum", "Artichaut", "Mais", "Langouste", "Chataîgne"};
            for (int i = 0; i < plats.Length / ogres.Length; i++)
                for(int j = 0; j < ogres.Length; j++)
                    ogres[j].Manger(plats[ogres­.Length * i + j]);

        }
    }
}
