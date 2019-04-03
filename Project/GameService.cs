using System.Collections.Generic;
using System;
using Garden.Project.Interfaces;
using Garden.Project.Models;
namespace Garden.Project
{
  public class GameService : IGameService
  {
    public bool Playing { get; set; }
    private void Initialize()
    {


      //MY ROOMS
      Room yard = new Room("Backyard", "Watch out for the landmines from the dog. Head North towrard the garden");

      Room garden = new Room("Garden", "Welcome into the garden would you like to collect some seeds to plant, grab a hoe to do some weeding or get a bucket for collecting fruit. If you go West to the grape vinyard or you may head East to the apple orchard.");

      Room vinyard = new Room("Vinyard", "Welcome into the vinyard. We grow some of the tastiest grapes around would you like some grapes to eat?");

      Room orchard = new Room("Orchard", "Welcome to the orchard. We grow some of the sweetest apples in the country, would you like to try an apple?");

      //MY ITEMS
      Item apple = new Item("apple", "You chose the apple this is sudden death");
      Item grape = new Item("grape", "You chose the grape this makes you immortal! You Win!");
      Item basket = new Item("basket", "Use this basket to pick your produce");
      Item hoe = new Item("hoe", "You must do some weeding before you leave the garden.");

      //ESTABLISH THE RELATIONSHIPS TO THE 
      yard.AddNearbyRoom("", garden);
      garden.AddNearbyRoom("", vinyard);
      garden.AddNearbyRoom("", orchard);

      CurrentRoom = yard;
      Playing = true;
    }

    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    public void GetUserInput()
    {
      while (Playing)
      {
        System.Console.WriteLine("What do you want to do?");
        string input = System.Console.ReadLine().ToUpper();
        RunCommand(input);
      }
    }
    private void RunCommand(string input)
    {
      switch (input)
      {
        case "GO":
        case "go":
          break;
        case "HELP":
        case "H":
          Help();
          break;
        case "INVENTORY":
        case "I":
          Inventory();
          break;
        case "LOOK":
        case "L":
          Look();
          break;
        case "QUIT":
        case "Q":
          Quit();
          break;
        case "RESET":
        case "reset":
          Reset();
          break;
        case "SETUP":
          Setup();
          break;
        case "START GAME":
        case "SG":
          StartGame();
          break;
        case "USE ITEM":
        case "UI":
          UseItem("");
          break;
        case "TAKE ITEM":
        case "TI":
          TakeItem("");
          break;



      }
      System.Console.WriteLine("press any key to continue");
      System.Console.ReadLine();
    }

    public void Go(string direction)
    {
      throw new System.NotImplementedException();
    }

    public void Help()
    {
      throw new System.NotImplementedException();
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      throw new System.NotImplementedException();
    }

    public void Quit()
    {
      throw new System.NotImplementedException();
    }

    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void Setup()
    {
      throw new System.NotImplementedException();
    }

    public void StartGame()
    {
      throw new System.NotImplementedException();
    }

    public void TakeItem(string itemName)
    {
      throw new System.NotImplementedException();
    }

    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
  }
}
