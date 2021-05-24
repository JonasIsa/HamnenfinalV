using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnenfinal
{

    class MotorBoat : Boat
    {
        public int Hästkrafter { get; set; }

        string IdPrefix = "M-";
        int minVikt = 200;
        int maxVikt = 3000;
        int minSpeed = 0;
        int maxiSpeed = 60;


        public MotorBoat()
        {
            Boattype = "Motorbåt";
            IdNr = IdPrefix + GetNummerID();
            Unique = AddUnikEgenskap();
            Weight = AddVikt(minVikt, maxVikt);
            MaxSpeed = AddMaxSpeed(minSpeed, maxiSpeed);
            DaysInPort = 3;
            SpotsTaken = 1.0;
        }

        public override string AddUnikEgenskap()
        {
            Random rnd = new Random();
            int randomNummer = rnd.Next(10, 1000 + 1);
            string unik = $"Antal hästkrafter: {randomNummer}";
            return unik;
        }

    }
}