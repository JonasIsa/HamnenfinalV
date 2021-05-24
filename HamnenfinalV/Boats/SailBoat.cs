using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnenfinal
{
    class SailBoat : Boat
    {
        public int BåtLength { get; set; }

        string IdPrefix = "S-";
        int minVikt = 800;
        int maxVikt = 6000;
        int minSpeed = 0;
        int maxiSpeed = 12;


        public SailBoat()
        {
            Boattype = "SegelBåt";
            IdNr = IdPrefix + GetNummerID();
            Unique = AddUnikEgenskap();
            Weight = AddVikt(minVikt, maxVikt);
            MaxSpeed = AddMaxSpeed(minSpeed, maxiSpeed);
            DaysInPort = 4;
            SpotsTaken = 2.0;
        }

        public override string AddUnikEgenskap()
        {
            Random rnd = new Random();
            int randomNummer = rnd.Next(10, 60 + 1);
            string unik = $"Båtens längd: {randomNummer} ";
            return unik;
        }
    }
}