﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineDelays
{
    class FlightInfo
    {
        public string Airline { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int DepartureDelay { get; set; }
        public int ArrivalDelay { get; set; }
        public bool Cancelled { get; set; }
        public int Distance { get; set; }

        public FlightInfo(string[] fields)
        {
            Airline = fields[0];
            Origin = fields[1];
            Destination = fields[2];
            DepartureDelay = int.Parse(fields[3]);
            ArrivalDelay = int.Parse(fields[4]);
            Cancelled = int.Parse(fields[5]) == 1;
            Distance = int.Parse(fields[6]);
        }

        public override string ToString()
        {
            return String.Format("{0} flight from {1} to {2} ({3} miles) departure delay {4} arrival delay {5}",
                Airline, Origin, Destination, Distance, DepartureDelay, ArrivalDelay);
        }

        public static List<FlightInfo> ReadFlightsFromFile(string fileName)
        {
            List<FlightInfo> flights = new List<FlightInfo>();
            string[] lines = File.ReadAllLines(fileName);
            for (int i = 1; i < lines.Length; ++i)
            {
                string line = lines[i];

                string[] parts = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 7)
                    continue;

                flights.Add(new FlightInfo(parts));
            }
            return flights;
        }
    }
}
