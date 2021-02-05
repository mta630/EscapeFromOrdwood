using System;
using System.Collections.Generic;
using System.Threading;
using EscapeFromOrdwood.Project.Models;

namespace EscapeFromOrdwood.Project.Interfaces
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AltDescription { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, IRoom> Exits { get; set; }
        public Riddle Riddle { get; set; }

        public Room (string name, string description, string altDescription)
        {
            Name = name;
            Description = description;
            AltDescription = altDescription;
            Items = new List<Item>();
            Exits = new Dictionary<string, IRoom>();
        }

        public void Print(bool isItemTaken, bool isRiddleSolved) 
        {
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine($"You are now in {Name}");
            Thread.Sleep(1200);
            if (!isItemTaken && isRiddleSolved) 
            {
                Console.WriteLine(Description);
            }
            else if (isItemTaken && !isRiddleSolved)
            {
                Console.WriteLine(Description);
            }
            else
            {
                Console.WriteLine(AltDescription);
            }
        }
    }
}