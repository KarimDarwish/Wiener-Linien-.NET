﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WienerLinienApi.Information;
using WienerLinienApi.Model;
using WienerLinienApi.RealtimeData.Monitor;

namespace WienerLinienApi.Samples.WPF_Proper.Model
{
    static class NewFavoriteStop
    {
        public static string StopName { get; set; }
        public static string Line { get; set; }
        public static string StopType { get; set; }
        public static int Platforms { get; set; }
        public static int[] TimesToWait { get; set; }
        public static List<string> BusStops { get; set; }
        public static WienerLinienContext Context = new WienerLinienContext("O56IE8eH7Kf5R5aQ");
        private static List<Station> stations;
        private static MonitorData Data { get; set; }
        private static Entities1 dbEntities = new Entities1();

        public static async Task<List<string>> GetStaionNames(MeansOfTransport type)
        {
            if (stations == null)
            {
                stations = await Stations.GetAllStationsAsync();
            }
            var mot = type;
            var listOfStations = (from v in stations
                                  from p in v.Platforms
                                  where p.MeansOfTransport == type
                                  select v.Name).Distinct().ToList();
            return listOfStations;
        }
        public static Haltestellen GetStationFromId(int id)
        {
            
            var a = dbEntities.Haltestellens.First(i => i.Haltestellen_ID== id);
            return a;
        }

        public static int GetStationIdFromName(string name)
        {
            return stations.First(i => i.Name == name).StationId;
        }

        public static async Task<List<string>> GetLinesFromStation(string station, MeansOfTransport type)
        {
            if (stations == null)
            {
                stations = await Stations.GetAllStationsAsync();
            }
            var lines = (from v in stations
                         where v.Name.Equals(station)
                         from p in v.Platforms
                         where p.MeansOfTransport == type
                         group p by p.Name
                         into linesList
                         select linesList.Key).ToList();
            return lines;

        }

        internal static string GetTimeForNextBus(object text1, string text2, object text3)
        {
            throw new NotImplementedException();
        }

        public static async Task<Dictionary<string, string>> GetDirections(string station, string line)
        {
            if (stations == null)
            {
                stations = await Stations.GetAllStationsAsync();
            }
            Console.WriteLine("Station=" + station + "&line=" + line + "&type=");
            var directions = (from v in stations
                              where v.Name == station
                              from p in v.Platforms
                              where p.Name == line
                              select p.RblNumber.ToString()).ToList();

            var rbls = directions.Select(int.Parse).ToList();

            var rtd = new RealtimeData.RealtimeData(Context);

            var parameters = new Parameters.MonitorParameters() { Rbls = rbls };
            var monitorInfo = await rtd.GetMonitorDataAsync(parameters);
            Data = monitorInfo;
            var strings = new Dictionary<string, string>();
            var b =
                monitorInfo.Data.Monitors.Where(i => i.Lines[0].Direction == "R" && i.Lines[0].Name == line).ToList();
            if (b.Count > 0)
            {
                strings.Add("R", ReplaceString(b.Select(i => i.Lines[0].Towards)
                    .ToList()
                    .First() + " "));
            }
            var c =
                monitorInfo.Data.Monitors.Where(i => i.Lines[0].Direction == "H" && i.Lines[0].Name == line).ToList();
            if (c.Count > 0)
            {
                strings.Add("H", ReplaceString(c.Select(i => i.Lines[0].Towards)
                    .ToList()
                    .First() + " "));
            }
            return strings;
        }

        public static string GetTimeForNextBus(string station, string line, string direction)
        {
            var time = Data.Data.Monitors.Where(i => i.Lines[0].Direction == direction && i.Lines[0].Name == line).ToList();
            foreach (var v in time)
            {
                Console.WriteLine(v.ToString());
            }
            return "";
        }

        private static string ReplaceString(string towards)
        {
            var a = Regex.Replace(towards, "([A-Z]+ )", i => "(" + i.Value.Trim() + ") ");
            return a;
        }
    }
}
