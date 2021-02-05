using System.Collections.Generic;
using EscapeFromOrdwood.Project.Models;

namespace EscapeFromOrdwood.Project.Interfaces
{
    public interface IRoom
    {
        string Name { get; set; }
        string Description { get; set; }
        string AltDescription { get; set; }
        List<Item> Items { get; set; }
        Dictionary<string,IRoom> Exits { get; set; }
    }
}