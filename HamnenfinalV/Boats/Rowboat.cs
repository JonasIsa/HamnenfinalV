using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnenfinal
{

    class Rowboat : Boat
    {
        public int MaxPassenger { get; set; }

        string IdPrefix = "R-";
        int minVikt = 100;
        int maxVikt = 300;
        int minSpeed = 0;
        int maxiSpeed = 3;


        public Rowboat()
        {
            Boattype = "RoddBåt ";
            IdNr = IdPrefix + GetNummerID();
            Unique = AddUnikEgenskap();
            Weight = AddVikt(minVikt, maxVikt);
            MaxSpeed = AddMaxSpeed(minSpeed, maxiSpeed);
            DaysInPort = 1;
            SpotsTaken = 1;
        }

        public override string AddUnikEgenskap()
        {
            Random rnd = new Random();
            int randomNummer = rnd.Next(1, 6 + 1);
            string unik = $"Maximal antal passangerare: {randomNummer}";
            return unik;
        }
    }
}