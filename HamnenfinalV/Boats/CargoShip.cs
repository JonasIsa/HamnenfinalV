using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnenfinal
{
    class CargoShip : Boat
    {
        public int Containers { get; set; }

        string IdPrefix = "L-";
        int minVikt = 3000;
        int maxVikt = 20000;
        int minSpeed = 0;
        int maxiSpeed = 20;

        public CargoShip()
        {
            Boattype = "Lastfartyg";
            IdNr = IdPrefix + GetNummerID();
            Unique = AddUnikEgenskap();
            Weight = AddVikt(minVikt, maxVikt);
            MaxSpeed = AddMaxSpeed(minSpeed, maxiSpeed);
            DaysInPort = 6;
            SpotsTaken = 4.0;
        }

        public override string AddUnikEgenskap()
        {
            Random rnd = new Random();
            int randomNummer = rnd.Next(500 + 1);
            string unik = $"Containers totalt på fartyget: {randomNummer}";
            return unik;
        }
    }
}