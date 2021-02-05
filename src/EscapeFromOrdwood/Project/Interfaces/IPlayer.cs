using System.Collections.Generic;
using EscapeFromOrdwood.Project.Models;

namespace EscapeFromOrdwood.Project.Interfaces
{
    public interface IPlayer
    {
        string PlayerName { get; set; }
        List<Item> Inventory { get; set; }
    }
}