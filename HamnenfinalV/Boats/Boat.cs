using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnenfinal
{
    class Boat
    {
        public string Boattype { get; set; }
        public string IdNr { get; set; }
        public int Weight { get; set; }
        public double MaxSpeed { get; set; }
        public string Unique { get; set; }
        public int DaysInPort { get; set; }
        public double SpotsTaken { get; set; }
        public string CurrentSpotId { get; set; }



        public static string GetNummerID()
        {

            string[] ar = new string[4];
            Random rnd = new Random();

            for (int i = 0; i < 3; i++)
            {
                int numm = rnd.Next(0, 26);
                char let = (char)('a' + numm);
                string svaret = let.ToString();
                ar[i] = svaret.ToUpper();

            }
            string toReturn = null;
            foreach (string item in ar)
            {
                toReturn += item;
            }

            return toReturn.ToUpper();
        }

        public static int AddVikt(int minWeight, int maxWeight)
        {
            Random rnd = new Random();
            int number = rnd.Next(minWeight, maxWeight + 1);
            int Totalvikt = number;
            return Totalvikt;
        }

        public static double AddMaxSpeed(int minSpeed, int maxSpeed) //Metod för att generera random på maximalhastighet och minimal
        {
            Random rnd = new Random();
            int randomNummer = rnd.Next(minSpeed, maxSpeed + 1);
            int finalMaxSpeed = randomNummer;
            double kmPerHour = finalMaxSpeed * 1.852; //Omvandlar knopp till km/h
            return Math.Round(kmPerHour);
        }

        public virtual string AddUnikEgenskap() //String för att skapa en unik string till våra båtar 
        {

            string unik = "";
            return unik;
        }

    }

}

