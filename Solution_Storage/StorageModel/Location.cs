using System;
using System.Collections.Generic;
using System.Text;

namespace StorageModel
{
    public class Location
    {
        public string Zone { get; set; }
        public int Rack { get; set; }
        public string Section { get; set; }
        public int Shelf { get; set; }
        public int Count { get; set; }

        public Location(string zone, int rack, string section, int shelf,  int count)
        {
            Zone = zone;
            Rack = rack;
            Section = section;
            Shelf = shelf;
            Count = count; 
        }
    }
}
