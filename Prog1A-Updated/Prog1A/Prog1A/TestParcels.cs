// Program 1B
// CIS 200-01
// Fall 2018
// Due: 10/3/2018
// By: D7184

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It creates several different Parcels and prints them.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("Nicholas Goodridge", "1234 1st Street", "Apt #207",
                "Louisville", "KY", 12345);
            Address a6 = new Address("Derrek Baxter", "5678 2nd Street",
                "Cinncinatti", "OH", 67890);
            Address a7 = new Address("Eric Hoeweler", "0987 3rd Street",
                "Chicago", "IL", 45678);
            Address a8 = new Address("Lynnzee Kazee", "6543 4th Street",
                "Apt #456", "Panama", "KY", 10293);


            Letter l1 = new Letter(a1, a3, 0.50M); // Test Letter 1
            Letter l2 = new Letter(a2, a4, 1.20M); // Test Letter 2
            Letter l3 = new Letter(a4, a1, 1.70M); // Test Letter 3

            GroundPackage g1 = new GroundPackage(a5, a6, 5, 5, 5, 10);
            GroundPackage g2 = new GroundPackage(a7, a8, 3.3, 4.4, 5.5, 6.6);
            GroundPackage g3 = new GroundPackage(a8, a5, 4, 5, 6, 1);

            NextDayAirPackage n1 = new NextDayAirPackage(a1, a8, 5, 5, 5, 10, 5);
            NextDayAirPackage n2 = new NextDayAirPackage(a2, a7, 40, 40, 40, 6, 10);
            NextDayAirPackage n3 = new NextDayAirPackage(a3, a6, 10, 10, 10, 75, 20);
            NextDayAirPackage n4 = new NextDayAirPackage(a4, a5, 40, 40, 40, 100, 30);

            TwoDayAirPackage t1 = new TwoDayAirPackage(a2, a5, 5, 5, 5, 10, TwoDayAirPackage.Delivery.Early);
            TwoDayAirPackage t2 = new TwoDayAirPackage(a4, a7, 40, 40, 40, 6, TwoDayAirPackage.Delivery.Saver);

            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();

            parcels.Add(l1); // Populate list
            parcels.Add(l2);
            parcels.Add(l3);
            parcels.Add(g1);
            parcels.Add(g2);
            parcels.Add(g3);
            parcels.Add(n1);
            parcels.Add(n2);
            parcels.Add(n3);
            parcels.Add(n4);
            parcels.Add(t1);
            parcels.Add(t2);


            Console.WriteLine("Select all Parcels and order by destination zip(descending)\n");
            var part1 =
                from p in parcels
                orderby p.DestinationAddress.Zip descending
                select p;

            foreach (Parcel p in part1)
            {
                Console.WriteLine($"{p.DestinationAddress.Zip:D5}");

            }

            Console.WriteLine("\n\nSelect all Parcels and order by cost (ascending)\n");
            var part2 =
                from p in parcels
                orderby p.CalcCost() ascending
                select p;

            foreach (Parcel p in part2)
            {
                Console.WriteLine($"{p.CalcCost():C}");

            }

            Console.WriteLine("\n\nSelect all Parcels and order by Parcel type (ascending) and then cost (descending)\n");
            var part3 =
                from p in parcels
                orderby p.GetType().ToString() ascending, p.CalcCost() descending
                select p;

            foreach (Parcel p in part3)
            {
                Console.WriteLine($"type: {p.GetType().ToString()} \tcost: {p.CalcCost():C}");

            }

            Console.WriteLine("Select all AirPackage objects that are heavy and order by weight (descending)\n");
            var part4 =
                from p in parcels
                let ap = p as AirPackage
                where ap != null && ap.IsHeavy()
                orderby ap.Weight descending
                select ap;

            foreach (Parcel p in part4)
            {
                Console.WriteLine(p);

            }
        }
    }
}
