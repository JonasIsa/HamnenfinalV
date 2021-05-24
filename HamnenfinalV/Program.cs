using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hamnenfinal
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = 1;
            double Totalspots = 64;
            double ParkedBoats = 0;

            Harbor hamn = new Harbor();
            hamn.PSpots = new List<Slot>();

   
            List<Boat> BoatsCreated = new List<Boat>();
            List<Boat> IncomingBoats = new List<Boat>();
            List<Boat> BoatsNoSpots = new List<Boat>();
            List<Harbor> Parked = new List<Harbor>();

            Random rnd = new Random();
            int IncomingBoatsDay = 5;

            ReadTXT();
            Console.ReadLine();
        

            while (true)
            {

                Console.WriteLine($"Dagens dag {day}\n");

                for (int i = 0; i < IncomingBoatsDay; i++)
                {
                    int randomNum = rnd.Next(1, 5);
                    if (randomNum == 1)
                    {
                        Rowboat Rowboat = new Rowboat();
                        BoatsCreated.Add(Rowboat);
                    }
                    else if (randomNum == 2)
                    {
                        MotorBoat Motorboat = new MotorBoat();
                        BoatsCreated.Add(Motorboat);
                    }
                    else if (randomNum == 3)
                    {
                        SailBoat Sailboat = new SailBoat();
                        BoatsCreated.Add(Sailboat);
                    }
                    else if (randomNum == 4)
                    {
                        CargoShip Cargoship = new CargoShip();
                        BoatsCreated.Add(Cargoship);
                    }
                }

                foreach (var item in BoatsCreated)
                {
                    //   Console.WriteLine($"Boat {item.IdentityNumber} of type {item.BoatType} has arrived");



                    if ((ParkedBoats + item.SpotsTaken) <= Totalspots)
                    {
                        ParkedBoats += item.SpotsTaken;

                        string slotID = Guid.NewGuid().ToString();

                        item.CurrentSpotId = slotID;

                        IncomingBoats.Add(item);

                        hamn.PSpots.Add(new Slot { ID = slotID, PSize = item.SpotsTaken, Bokad = true });
                    }

                    else
                    {
                        BoatsNoSpots.Add(item);
                    }
                }


                // Visa vilka båtar som har skapats
                Console.WriteLine("Båtar som anländer idag:\n");
                foreach (var item in BoatsCreated)
                {

                    Console.WriteLine($"{item.Boattype} med nummer Id: {item.IdNr}");

                }
                Console.WriteLine();




                foreach (var item in hamn.PSpots)
                {
                    foreach (var i in IncomingBoats)
                    {
                        if (i.SpotsTaken == i.SpotsTaken) ;
                    }
                }
                
                double platsnummer = 1;
                int antalRoddbåtar = 0;
                int antalMotorbåtar = 0;
                int antalSegelbåtar = 0;
                int antalLastfartyg = 0;
                double maxhastighet = 0;
                int TotalHastighet = 0;
                int vikt = 0;

                Console.WriteLine("Plats\tBåttyp\t\tNummer\tVikt\tMaxhastighet\t\tUnik\n");

                foreach (Boat item in IncomingBoats.ToList())
                {


                    if (item != null)
                    {
                        if (item.SpotsTaken > 1)
                        {
                            Console.WriteLine($"{platsnummer}-{platsnummer + item.SpotsTaken - 1}.\t{item.Boattype}\t{item.IdNr}\t{item.Weight}\t{item.MaxSpeed} km/h\t\t{item.Unique} ");
                            platsnummer++;
                        }
                        else
                        {
                            Console.WriteLine($"{platsnummer}.\t{item.Boattype}\t{item.IdNr}\t{item.Weight}\t{item.MaxSpeed} km/h\t\t{item.Unique} ");

                        }

                        if (item is Rowboat)
                        {

                            antalRoddbåtar++;
                            platsnummer += item.SpotsTaken;



                        }
                        else if (item is MotorBoat)
                        {

                            antalMotorbåtar++;
                            platsnummer += item.SpotsTaken;


                        }
                        else if (item is SailBoat)
                        {

                            antalSegelbåtar++;
                            platsnummer += item.SpotsTaken - 1;


                        }
                        else if (item is CargoShip)
                        {

                            antalLastfartyg++;
                            platsnummer += item.SpotsTaken - 1;


                        }


                    }


                    else
                    {
                        Console.WriteLine(platsnummer + ". Tom Plats");
                        platsnummer++;

                    }


                }

                if (platsnummer < 65)
                {
                    double tommaPlatser = 65 - platsnummer;

                    for (int i = 0; i < tommaPlatser; i++)
                    {
                        Console.WriteLine(platsnummer + ". Tom Plats");
                        platsnummer++;
                    }

                }

                foreach (var item in IncomingBoats.ToList())
                {
                    if (item != null)
                    {
                        if (item.DaysInPort != 0)
                        {
                            vikt += item.Weight;
                            maxhastighet += item.MaxSpeed;
                            item.DaysInPort--;
                            TotalHastighet++;

                        }

                        else
                        {
                            Console.WriteLine($"Båten som lämnar hamnen: {item.IdNr}");

                            //   ledigaPlatser += item.Tarplatser;
                            vikt -= item.Weight;
                            maxhastighet -= item.MaxSpeed;
                            TotalHastighet--;
                            if (item is Rowboat)
                                antalRoddbåtar--;
                            else if (item is MotorBoat)
                                antalMotorbåtar--;
                            else if (item is SailBoat)
                                antalSegelbåtar--;
                            else if (item is CargoShip)
                                antalLastfartyg--;
                            ParkedBoats -= item.SpotsTaken;
                            IncomingBoats.Remove(item);








                        }
                    }
                }




               


                Console.WriteLine();
                Console.WriteLine($"Antalet av roddbåtar: {antalRoddbåtar} \tAntalet av motorbåtar: {antalMotorbåtar}\nAntalet av segelbåtar: {antalSegelbåtar}\tAntalet av lastfartyg: {antalLastfartyg}");


                double maxMedeltal = maxhastighet / TotalHastighet;
                Console.WriteLine("Medelhastigheten är: " + Math.Round(maxMedeltal, 1) + " km/h");
                Console.WriteLine("Total vikt är: " + vikt + " kg\n");

                // Visa vilka båtar fick inte plats
                Console.WriteLine("Båtar som inte får någon plats:");
                foreach (var item in BoatsNoSpots)
                {
                    Console.WriteLine($"{item.Boattype} med ID nummer: {item.IdNr}");
                }



                BoatsCreated.Clear();
                BoatsNoSpots.Clear();
                
                day++;
                Console.WriteLine();
                Console.WriteLine("Nästa dag, klicka enter");
                WriteTXT(IncomingBoats, antalRoddbåtar, antalMotorbåtar, antalSegelbåtar, antalLastfartyg, maxMedeltal, vikt);

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                   
                    Console.Clear();

                
            }

        }

        static void WriteTXT( List<Boat> incomingboats, int antalRoddbåtar, int antalMotorbåtar, int antalSegelbåtar, int antalLastfartyg, double maxMedeltal, int vikt)
        {
            double plats = 1;
            StreamWriter sw = new StreamWriter("Hamnen.txt");
            sw.WriteLine("Plats\tBåttyp\t\tNummer\tVikt\tMaxhastighet\t\tUnik\n");
            foreach (var item in incomingboats)
            {
                
                sw.WriteLine($"{plats}-{plats + item.SpotsTaken - 1}.\t{item.Boattype}\t{item.IdNr}\t{item.Weight}\t{item.MaxSpeed} km/h\t\t{item.Unique} ");
                plats++;


            }
            sw.WriteLine($"\nAntalet av roddbåtar: {antalRoddbåtar} \tAntalet av motorbåtar: {antalMotorbåtar}\nAntalet av segelbåtar: {antalSegelbåtar}\tAntalet av lastfartyg: {antalLastfartyg}");

            sw.WriteLine("Medelhastigheten är: " + Math.Round(maxMedeltal, 1) + " km/h");
            sw.WriteLine("Total vikt är: " + vikt + " kg\n");
            sw.WriteLine("Nästa dag, klicka enter");
            sw.Close();

        }

        static void ReadTXT()
        {
            StreamReader sr = new StreamReader(@"C:\Users\Muhammed Isa\Documents\HamnenfinalV\HamnenfinalV\bin\Debug\netcoreapp3.1\Hamnen.txt");
            string s;
            do
            {
                s = sr.ReadLine();
                Console.WriteLine(s);
            } while (s != null);
            sr.ReadToEnd();
            sr.Close();

        }
    }

}
