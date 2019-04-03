using System;
using System.Collections.Generic;
using Garden.Project.Interfaces;

namespace Garden.Project.Models
{
  public class Room : IRoom
  {
    private string v1;
    private string v2;

    public Room(string v1, string v2)
    {
      this.v1 = v1;
      this.v2 = v2;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    internal void AddNearbyRoom(string direction, Room room)
    {
      Exits.Add(direction, room);
    }

  }
}