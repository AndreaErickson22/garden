using System;
using Garden.Project;
using Garden.Project.Models;

namespace Garden
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.Clear();
      System.Console.WriteLine("Get ready for an adventure into the garden.");
      bool validName = false;
      string user = "";
      while (!validName)
      {
        System.Console.WriteLine("Tell me your name?");
        string userName = Console.ReadLine().Trim();
        if (userName.Length < 1)
        {
          System.Console.WriteLine("Please enter your name.");

        }
        else
        {
          user = userName;
          validName = true;
        }
      }
      Player player = new Player(user);
      GameService gameService = new GameService();
      gameService.CurrentPlayer = player;
      gameService.Setup();



    }
  }
}
