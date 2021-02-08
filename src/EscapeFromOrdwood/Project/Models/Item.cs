using System.Collections.Generic;
using EscapeFromOrdwood.Project.Interfaces;

namespace EscapeFromOrdwood.Project.Models
{
    public class Item : IItem
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public Room RoomEvent {get; set;}
        public Room RoomUnlocked { get; set;}
        public string RoomEventDescription {get; set;}
        public double Damage { get; set; }
    
    public Item(string name, string description, Room roomEvent, Room roomUnlocked, string roomEventDescription)
    {

        Name = name;
        Description = description;
        RoomEvent = roomEvent;
        RoomEventDescription = roomEventDescription;
        RoomUnlocked = roomUnlocked;

    }

    public Item(string name, string description, double damage)
    {
        Name = name;
        Description = description;
        Damage = damage;
    }

    }
}