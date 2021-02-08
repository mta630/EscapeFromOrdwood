using System.Collections.Generic;
using EscapeFromOrdwood.Project.Models;

namespace EscapeFromOrdwood.Project.Interfaces
{
    public interface IItem
    {
        string Name { get; set; }
        string Description { get; set; }
        Room RoomEvent { get; set; }
        Room RoomUnlocked { get; set; }
        string RoomEventDescription { get; set; }
        double Damage { get; set; }
    }
}