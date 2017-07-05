using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoD;

namespace DungeonsOfDoom
{
    class Game
    {
        //todo ask if add to backpack
        //todo input to open backpack

        //todo randomutils
        //todo lägg till konstant värde för mapsize
        Player player;
        Room[,] world;

        public void Play()
        {
            CreatePlayer();
            CreateWorld();

            TextUtils.Animate("Get ready to face the horrors of Dungeons of Doom..");
            Console.ReadKey(true);


            do
            {
                Console.Clear();
                DisplayStats();
                DisplayWorld();
                AskForMovement();
                CheckMonsterCount();
            } while (player.Health > 0);

            GameOver();
        }

        //private void CheckMonsterCount()
        //{
        //    if (WorldItem.MonsterCount == 0)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("You killed all monsters!");
        //        Console.WriteLine("Do you want to play again? j/n");
        //       //bool check = true;
        //        string input = Console.ReadLine().ToUpper();
        //        //while (check)
        //        //{
        //            if (input == "J")
        //            {
        //               // check = false;
        //                Play();
        //            }
        //            else if (input == "N")
        //            {
        //               //check = false;
        //                Environment.Exit(0);
        //            }
        //            else
        //            {
        //                //check = true;
        //                Console.WriteLine("Try again");
        //            }
        //            Console.Clear();
        //       // } GÖR IMON så det går att trycka på fel knapp och bli tvingad ja eller nej
        //    }
        //}

        private void CheckMonsterCount()
        {
            if (WorldItem.MonsterCount == 0)
            {
                Console.Clear();
                Console.WriteLine("You killed all monsters!");
                Console.WriteLine("Do you want to play again? j/n");
                //bool check = true;
                string input = Console.ReadLine().ToUpper();
                //while (check)
                //{
                if (input == "J")
                {
                    // check = false;
                    Play();
                }
                else if (input == "N")
                {
                    //check = false;
                    Environment.Exit(0);
                }
                else
                {
                    //check = true;
                    Console.WriteLine("Try again");
                }
                Console.Clear();
                // } GÖR IMON så det går att trycka på fel knapp och bli tvingad ja eller nej
            }
        }

        void DisplayStats()
        {
            Console.Write($"Health: {player.Health}\t");
            Console.WriteLine($"Attack power: {player.AttackDamage}");
            Console.WriteLine($"Player: {player.Name}");
            ShowBackPack();
            Console.WriteLine();
        }

        private void ShowBackPack()
        {
            Console.WriteLine("Inventory: ");
            foreach (IPickupAble item in player.Backpack)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void AskForMovement()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            int newX = player.X;
            int newY = player.Y;
            bool isValidMove = true;

            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
                default: isValidMove = false; break;
            }

            if (isValidMove &&
                newX >= 0 && newX < world.GetLength(0) &&
                newY >= 0 && newY < world.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;

                Room currentRoom = world[player.X, player.Y];

                //player.Health--;
                //todo pontus genomgång
                //if (world[player.X, player.Y].Item != null)
                //{
                //    player.Backpack.Add(world[player.X, player.Y].Item);
                //    world[player.X, player.Y].Item = null;
                //}

                if (currentRoom.Monster != null)
                {
                    Console.Clear();
                    Console.WriteLine("Fight!");
                    bool playersTurn = true;
                    Console.ReadKey();

                    do
                    {
                        Console.WriteLine(player.Attack(currentRoom.Monster));

                        Console.ReadKey();
                        playersTurn = !playersTurn;
                        while (!playersTurn && currentRoom.Monster.Health > 0)
                        {
                            Console.WriteLine(currentRoom.Monster.Attack(player));
                            Console.ReadKey();
                            playersTurn = !playersTurn;
                        }


                        if (player.Health <= 0)
                        {
                            Console.WriteLine($"{player.Name} died screaming");
                            Console.ReadKey();
                        }
                        else if (currentRoom.Monster.Health <= 0)
                        {
                            Console.WriteLine($"{currentRoom.Monster.Name} died screaming");
                            WorldItem.MonsterCount--;
                            Console.ReadKey();
                        }

                    } while (player.Health > 0 && currentRoom.Monster.Health > 0);
                    Console.WriteLine(currentRoom.Monster.ItemGetPickedUp(player));
                    Console.ReadKey();
                    currentRoom.Monster = null;

                    //player.Backpack.Add(currentRoom.Monster);
                }

                if (currentRoom.Item != null)
                {
                    Console.Clear();

                    Item currentItem = currentRoom.Item;
                    Console.WriteLine(currentItem.GetPickedUp(player));
                    Console.ReadKey();
                    //currentItem = null;
                    Console.WriteLine(currentRoom.Item.ItemGetPickedUp(player));
                    Console.ReadKey();
                    currentRoom.Item = null;
                }
                //player.Backpack.Add(currentRoom.Item);
            }
        }

        private void DisplayWorld()
        {
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    Room room = world[x, y];

                    if (player.X == x && player.Y == y)
                        Console.Write(player.Symbol);
                    else if (room.Monster != null)
                        Console.Write(room.Monster.Symbol);
                    else if (room.Item != null)
                        Console.Write(room.Item.Symbol);
                    else
                        Console.Write(room.Symbol);

                }
                Console.WriteLine();
            }
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over...");
            Console.ReadKey();
            Play();
        }

        private void CreateWorld()
        {
            world = new Room[20, 5];
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    world[x, y] = new Room();

                    if (player.X != x || player.Y != y)
                    {
                        //todo använd randomutils här

                        if (RandomUtils.RandomRoll(10))
                        {
                            if (RandomUtils.RandomRoll(50))
                            {
                                world[x, y].Monster = new Orc();
                            }
                            else
                            {
                                world[x, y].Monster = new Ogre();
                            }
                        }

                        if (RandomUtils.RandomRoll(10))
                        {
                            if (RandomUtils.RandomRoll(50))
                            {
                                world[x, y].Item = new Weapon(5, "Sword");
                            }
                            else
                            {
                                world[x, y].Item = new Potion("Äpple", 10);
                            }
                        }
                    }
                }
            }
        }

        private void CreatePlayer()
        {
            player = new Player(0, 0, "MagicMike");
            //todo take input for playerName
        }

        //private void DetectCollision()
        //{
        //    if (world[player.X, player.Y].Monster != null)
        //    {
        //        // fight monster here
        //        //todo run method fightOpponent
        //        Room currentRoom = world[player.X, player.Y];
        //        Monster currentMonster = currentRoom.Monster;

        //        player.Attack(currentMonster);
        //    }
        //    else if (world[player.X, player.Y].Item != null)
        //    {
        //        // pick up item here
        //    }
        //}

        //todo Add CollisionDetection() method
        //todo Add FightOpponent() method

        //private void FightOpponent(Character opponent)
        //{
        //    bool isPlayersTurn = true;
        //    do
        //    {
                
        //    } while (player.Health > 0|| opponent.Health > 0);
        //}
    }
}
