using System.Collections.Generic;
using System;
using Garden.Project.Interfaces;
using Garden.Project.Models;
namespace Garden.Project
{
  public class GameService : IGameService
  {
    public IRoom CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public bool playing = true;


    public GameService()
    {
    }

    public void GetUserInput()
    {
      string input = Console.ReadLine().ToLower();
      string[] arrChoice = input.Split(" ");
      string command = arrChoice[0];
      string option = "";
      if (arrChoice.Length > 1)
      {
        option = arrChoice[1];
      }
      switch (command)
      {
        case "go":
          Go(option);
          break;
        case "help":
          Help();
          break;
        case "inventory":
        case "i":
          Inventory();
          break;
        case "look":
          Look();
          break;
        case "quit":
        case "q":
          Quit();
          break;
        case "reset":
          Reset();
          break;
        case "setup":
          Setup();
          break;
        case "start":
          StartGame();
          break;
        case "pick":
          Pick();
          break;
        case "use":
          UseItem(option);
          break;
        case "take":
          TakeItem(option);
          break;
        default:
          System.Console.WriteLine("Not a recognized command.");
          break;
      }
    }

    public void Go(string direction)
    {
      System.Console.Clear();
      const string V = "";
      if (direction == V && CurrentRoom.Name.ToString() == "yard" && (CurrentPlayer.Inventory[0].ToString() != "gnome" || CurrentPlayer.Inventory[1].ToString() != "gnome"))
      {
        System.Console.WriteLine("You must take the gnome and use it before you may enter the garden.");

      }
      else if (CurrentRoom.Exits.ContainsKey(direction))
      {
        CurrentRoom = CurrentRoom.Exits[direction];
      }
      else
      {
        System.Console.WriteLine("You cannot go that way");
      }
      System.Console.WriteLine(CurrentRoom.Name.ToString());
    }
    public void Pick()
    {
      if (CurrentRoom.Name.ToString() == "orchard")
      {
        System.Console.WriteLine("You have picked the poisoned apples. You are now going to die at least it was quick!");
        Quit();
      }
      else
      {
        System.Console.WriteLine("You should head over to the orchard if you want to pick something!");
        Look();
      }

    }

    public void Help()
    {
      System.Console.WriteLine("----GOAL OF THIS GARDEN GAME----");
      System.Console.WriteLine("You must go to the vinyard to eat a grape to win this game with eternal life. Exploring and harvesting other fruits and vegetables is recommeneded.");
      System.Console.WriteLine("");
      System.Console.WriteLine("You begin this game in the yard, to your north is the garden, once in the garden there is a vinyard to the west, and a creek further west down the trail. There is also an apple orchard to the east from the garden.");
      System.Console.WriteLine("");
      System.Console.WriteLine("----How to use the commands----");
      System.Console.WriteLine("To do something in the game you must type a command followed by a space and an option.");
      System.Console.WriteLine("");
      System.Console.WriteLine("Some example commands are: 'go north', 'take grape', 'use gnome', 'inventory','help', 'pick' and 'quit'.");
      System.Console.WriteLine("");
      System.Console.WriteLine("----How to Navigate----");
      System.Console.WriteLine("Type 'look' to look around the space you are in this will give a description of the area and where you might go next.");
      System.Console.WriteLine("");
      System.Console.WriteLine("----How to get back to the game----");
      System.Console.WriteLine("Push the enter button on your keyboard to continue the game.");
      GetUserInput();
    }

    public void Inventory()
    {
      System.Console.WriteLine("You currently have the following items in your inventory: ");
      CurrentPlayer.Inventory.ForEach(i =>
      {
        System.Console.WriteLine($"• {i.Name}");


      });

    }

    public void Look()
    {
      System.Console.WriteLine(CurrentRoom.Description.ToString());

    }

    public void Quit()
    {
      playing = false;
    }
    //RESET
    public void Reset()
    {
      Setup();
    }
    public void Setup()
    {
      //MY ROOMS
      Room yard = new Room("yard", "Walk carefully along the brick path and across the bridge. You should 'take gnome' and 'use gnome' before you leave the yard as the gnome will give you special powers as you head north into the garden.");

      Room garden = new Room("garden", "Welcome into the garden if you would like a basket to collect some produce enter: 'take basket' From here in the garden you may go West to the grape vinyard and about a mile farther to the west there is a creek. If you head East from here, down the path to the apple orchard there will be shade and a variety of delcious apples to pick.");

      Room vinyard = new Room("vinyard", "Welcome to the vinyard. We grow some of the finest grapes around, would you like some grapes to eat? Enter 'take grape' to pick one and 'use grape' to eat one.");

      Room creek = new Room("creek", "Welcome to the creek you might wanna kick back and soak your feet in the crisp water for a bit. You may collect some pebbles while you are here 'take pebbles' and if you 'use pebbles' you will throw them into the creek. You have to go back and check out the grapes in the vinyard, they are just declicious!!");

      Room orchard = new Room("orchard", "Welcome to the orchard. We grow some of the sweetest apples in the country, would you like to 'pick' some apples if so just enter 'pick'?");

      //MY ITEMS
      Item apple = new Item("apple", "You take the apple this is sudden death");
      Item grape = new Item("grape", "You take the grape this makes you immortal! You Win!");
      Item basket = new Item("basket", "Use this basket to pick your produce");
      Item gnome = new Item("gnome", "You must do talk with the gnome to enter the garden.");
      Item pebbles = new Item("pebbles", "You can save these or use them to toss into the creek.");

      //ESTABLISH THE RELATIONSHIPS TO THE 


      yard.AddNearbyRoom("north", garden);
      garden.AddNearbyRoom("west", vinyard);
      garden.AddNearbyRoom("east", orchard);
      orchard.AddNearbyRoom("west", garden);
      vinyard.AddNearbyRoom("west", creek);
      creek.AddNearbyRoom("east", vinyard);
      vinyard.AddNearbyRoom("east", garden);
      garden.AddNearbyRoom("south", yard);


      CurrentRoom = yard;
      //items for use
      vinyard.Items.Add(grape);
      orchard.Items.Add(apple);
      yard.Items.Add(gnome);
      garden.Items.Add(basket);
      creek.Items.Add(pebbles);

      System.Console.WriteLine("type 'help' for directions. Press enter to continue");
      GetUserInput();

      StartGame();
    }


    //START GAME
    public void StartGame()
    {
      Console.Clear();
      System.Console.WriteLine($"Are you ready for an adventure {CurrentPlayer.PlayerName}? enter 'yes' or 'no'");
      string adventureresponse = Console.ReadLine().ToLower();
      if (adventureresponse == "no")
      {
        System.Console.WriteLine("Ok, maybe next time you will be ready for an adventure. Good Bye.");
        System.Console.WriteLine("Press the enter button to restart game.");
        Console.ReadLine();
        Reset();
      }
      else if (adventureresponse == "yes")
      {
        System.Console.WriteLine("The adventure begins!");
        System.Console.WriteLine("You are walking through the lush grass and a gnome appears, you must enter 'take gnome' to proceed");
        GetUserInput();

        while (playing == true)
        {
          GetUserInput();
        }
      }
      else
      {
        StartGame();
      }
    }
    //TAKE ITEM
    public void TakeItem(string itemName)
    {
      Item item = CurrentRoom.Items.Find(i =>
      {
        return i.Name.ToLower() == itemName;
      });
      if (item != null)
      {
        CurrentRoom.Items.Remove(item);
        CurrentPlayer.Inventory.Add(item);
        System.Console.WriteLine($"You now have a {item.Name}.");

      }
      else
      {
        System.Console.WriteLine("Cannot add that item.");
      }
    }

    //USE ITEM
    public void UseItem(string itemName)
    {
      Item usedItem = CurrentPlayer.Inventory.Find(i =>
      {
        return i.Name.ToLower() == itemName;
      });
      if (itemName == "gnome" && (CurrentPlayer.Inventory[0].Name.ToString() == "gnome") && CurrentRoom.Name.ToString() == "yard")
      {
        CurrentPlayer.Inventory.Remove(usedItem);
        System.Console.WriteLine("You will have great *luck* in your journey!");

        CurrentRoom.Description = "You are currently in the yard, where would you like to go next? The garden is to your north 'go north' will take you there.";
        Look();
      }


      if (itemName == "grape" && CurrentRoom.Name.ToString() == "vinyard")
      {
        System.Console.WriteLine("you have eaten the grapes! You now will live forever! You Win the game!");
        CurrentPlayer.Inventory.Remove(usedItem);

        System.Console.WriteLine("type in 'quit' to exit the game or you may keep exploring.");
        GetUserInput();
      }

      if (itemName == "pebbles" && CurrentRoom.Name.ToString() == "creek")
      {
        System.Console.WriteLine("You have tossed the pebbles into the creek.");
        CurrentPlayer.Inventory.Remove(usedItem);
        System.Console.WriteLine("Where do you want to go next");
        GetUserInput();
        Look();
      }
      if (itemName == "apple" && (CurrentPlayer.Inventory[0].Name.ToString() == "apple") && CurrentRoom.Name.ToString() == "orchard")
      {
        System.Console.WriteLine("You eaten an poisoned apple, your game is over.");
        playing = false;
      }


    }
  }



}




