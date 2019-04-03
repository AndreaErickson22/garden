using System.Collections.Generic;
using Garden.Project.Interfaces;

namespace Garden.Project.Models
{
  public class Item : IItem
  {
    private string v1;
    private string v2;

    public Item(string v1, string v2)
    {
      this.v1 = v1;
      this.v2 = v2;
    }

    public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public string Description { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
  }
}