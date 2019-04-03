using System.Collections.Generic;
using Garden.Project.Models;

namespace Garden.Project.Interfaces
{
  public interface IPlayer
  {
    string PlayerName { get; set; }
    List<Item> Inventory { get; set; }
  }
}
