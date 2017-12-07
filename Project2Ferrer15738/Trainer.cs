// FERRER, Carlo Ram M. 
// 151738
// December 5, 2016
// I have not discussed the C# language code in my program
// with anyone other than my instructor or the teaching assistants assigned to this
// course. I have not used C# language code obtained from
// another person, or any other unauthorized source, either modified or unmodified.
// Any C# language code or documentation used in my program
// that was obtained from another source, such as a text book, a web page,
// or another person, have been clearly noted with proper citation in the
// comments of my program.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRAFT
{
    public class Trainer
    {
        private const int MAX = 10;
        List<PokemonRegInfo> pokedex;
        MyPokemon[] bag;
        Profile[] prof;
        int numCandy;
        int numPokemonInBag;
        Random rndhp = new Random();
        Random rndcp = new Random();
        double spins;
        double xp;
        int badge;
        int pokeballs = 7;
        private string msg;
        int potions = 0;

        public Trainer()
        {
            pokedex = new List<PokemonRegInfo>();
            bag = new MyPokemon[MAX];
            prof = new Profile[1];
            numCandy = 0;
            numPokemonInBag = 0;
            badge = 0;
        }

        public void Register(string name, string type, string evolution, int cost, int multiplier)
        {
            if (FindInPokedex(name) == null)
            {
                if (evolution == "none")
                {
                    Console.WriteLine(name + " SUCCESSFULLY REGISTERED TO POKEDEX.");
                    pokedex.Add(new PokemonRegInfo(name, type, null, -1,-1));
                }
                else if (evolution == "None")
                {
                    Console.WriteLine(name + " SUCCESSFULLY REGISTERED TO POKEDEX.");
                    pokedex.Add(new PokemonRegInfo(name, type, null, -1, -1));
                }
                else
                {
                    Console.WriteLine(name + " SUCCESSFULLY REGISTERED TO POKEDEX.");
                    pokedex.Add(new PokemonRegInfo(name, type, evolution, cost, multiplier));
                }
                
                msg = "Registration successful.";
            }
            else
            {
                Console.WriteLine(name + " HAS ALREADY BEEN REGISTERED.");
                msg = "Pokemon has already been registered.";
            }
            
        }

        public void Catch(string name, string t, int hp, int cp, string ev, int em, int ec)
        {
            if (numPokemonInBag < MAX)
            {
                if (FindInPokedex(name) != null)
                {
                    ev = FindInPokedex(name).GetPokemonEvolution();
                    em = FindInPokedex(name).GetEvolutionMultiplier();
                    ec = FindInPokedex(name).GetEvolutionCost();
                    t = FindInPokedex(name).GetPokemonType();
                    bag[numPokemonInBag] = new MyPokemon(name, t, hp, cp, ev, em, ec);
                    numCandy += 3;
                    numPokemonInBag += 1;
                    xp += 0.2;
                    msg = name + " was caught!" + " You gained " + 0.2 * 10 + " xp.";
                }
                else
                {
                    msg = name + " does not exist in pokedex.";
                }
            }
            else
            {
                Console.WriteLine("YOUR BAG IS FULL.");
                msg = "Your bag is full.";
            }
        }

        public void Transfer(int id)
        {

            Console.WriteLine(String.Format("{0,5} | {1,-10} | {2,5} | {3,5}", "ID", "NAME","HP","CP"));
            Console.WriteLine("----------------------------------");
            if (numPokemonInBag == 0)
            {
                Console.WriteLine("NO POKEMON TO TRANSFER.");
                Console.WriteLine("==================================");
                Console.WriteLine("TOTAL CANDY: " + numCandy);
                Console.WriteLine("BAG CAPACITY: " + numPokemonInBag + "/" + MAX);
            }
            else
            {
                for (int i = 0; i < numPokemonInBag; i++)
                {
                    string name = bag[i].GetPokemonName();
                    int hp = bag[i].GetHealthPoints();
                    int cp = bag[i].GetCombatPower();
                    Console.WriteLine(String.Format("{0,5} | {1,-10} | {2,5} | {3,5}", i + 1, name, hp, cp));
                }
                Console.WriteLine("==================================");
                Console.WriteLine("TOTAL CANDY: " + numCandy);
                Console.WriteLine("BAG CAPACITY: " + numPokemonInBag + "/" + MAX);
                Console.Write("ENTER ID: ");
                if (id > numPokemonInBag)
                {
                    Console.WriteLine("INVALID ID.");
                }
                else
                {
                    FindInBag(bag[id].GetPokemonName());
                    if (bag[id].GetPokemonName() != null)
                    {
                        Console.WriteLine(bag[id].GetPokemonName() + " SUCCESSFULLY TRANSFERRED. YOU RECEIVED 1 CANDY.");
                        for (int i = id; i < numPokemonInBag - 1; i++)
                        {
                            bag[i] = bag[id+1];
                            id++;
                            if (bag[i] == null)
                                break;
                        }
                        bag[numPokemonInBag - 1] = null;
                        numPokemonInBag--;
                        numCandy++;
                        xp += 0.1;
                        Console.WriteLine("You gained " + 0.1 * 10 + " xp.");
                    }
                    else
                    {
                        Console.WriteLine("INVALID ID.");
                    }
                }
            }
        }

        public void Evolve(int id)
        {
            Console.WriteLine(String.Format("{0,5} | {1,-10} | {2,5} | {3,5}", "ID", "NAME", "HP", "CP"));
            Console.WriteLine("-----------------------------------");
            if (numPokemonInBag == 0)
            {
                Console.WriteLine("NO POKEMON TO EVOLVE.");
                Console.WriteLine("===================================");
                Console.WriteLine("TOTAL CANDY: " + numCandy);
                Console.WriteLine("BAG CAPACITY: " + numPokemonInBag + "/" + MAX);
            }
            else
            {
                for (int i = 0; i < numPokemonInBag; i++)
                {
                    string name = bag[i].GetPokemonName();
                    int hp = bag[i].GetHealthPoints();
                    int cp = bag[i].GetCombatPower();
                    Console.WriteLine(String.Format("{0,5} | {1,-10} | {2,5} | {3,5}", i + 1, name, hp, cp));
                }
                Console.WriteLine("===================================");
                Console.WriteLine("TOTAL CANDY: " + numCandy);
                Console.WriteLine("BAG CAPACITY: " + numPokemonInBag + "/" + MAX);
                Console.Write("ENTER ID: ");
                    if (id > numPokemonInBag )
                    {
                        Console.WriteLine("INVALID ID.");
                    }
                    else
                    {
                    //PokemonRegInfo curPokemon = pokedex.ElementAt(id-1);
                    if (bag[id].GetEvolution() == null)
                        msg = "No more next evolution.";
                    else if (bag[id].GetEvolution() == "")
                        msg = "No more next evolution.";
                    else
                    {
                        if (numCandy < bag[id].GetEvolutionCost())
                            msg = "You do not have enough candy to evolve that pokemon.";
                        else
                        {

                            numCandy = numCandy - bag[id].GetEvolutionCost();
                            msg = "Successful evolution. You gained " + 0.1 * 10 + " xp.";
                            xp += 0.1;
                            if (FindInPokedex(bag[id].GetEvolution()) == null)
                            {
                                pokedex.Add(new PokemonRegInfo(bag[id].GetEvolution(), bag[id].GetType(), "None", 0, 0));
                                bag[id].SetPokemonName(bag[id].GetEvolution());
                                bag[id].SetPokemonHp(bag[id].GetEvolutionMultiplier() * bag[id].GetHealthPoints());
                                bag[id].SetPokemonCp(bag[id].GetEvolutionMultiplier() * bag[id].GetCombatPower());
                                bag[id].SetPokemonEvolution(null);
                            }
                            else
                            {
                                bag[id].SetPokemonName(bag[id].GetEvolution());
                                bag[id].SetPokemonHp(bag[id].GetEvolutionMultiplier() * bag[id].GetHealthPoints());
                                bag[id].SetPokemonCp(bag[id].GetEvolutionMultiplier() * bag[id].GetCombatPower());
                                bag[id].SetPokemonEvolution(null);
                            }
                        }
                    }
                    }
            }
        }

        public void ViewBag()
        {
            Console.WriteLine(String.Format("{0,5} | {1,-10} | {2,5} | {3,5}", "ID", "NAME", "HP", "CP"));
            Console.WriteLine("----------------------------------");
            if (numPokemonInBag == 0)
            {
                Console.WriteLine("BAG IS EMPTY.");
                Console.WriteLine("==================================");
                Console.WriteLine("TOTAL CANDIES: " + numCandy);
                Console.WriteLine("BAG CAPACITY: " + numPokemonInBag + "/" + MAX);
                Console.WriteLine("TOTAL POKEBALLS: " + pokeballs);
            }
            else
            {
                for (int i = 0; i < numPokemonInBag; i++)
                {
                    if (bag[i] == null)
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        string name = bag[i].GetPokemonName();
                        int hp = bag[i].GetHealthPoints();
                        int cp = bag[i].GetCombatPower();
                        Console.WriteLine(String.Format("{0,5} | {1,-10} | {2,5} | {3,5}", i + 1, name, hp, cp));
                    }
                }
                    Console.WriteLine("==================================");
                    Console.WriteLine("TOTAL CANDY: " + numCandy);
                    Console.WriteLine("BAG CAPACITY: " + numPokemonInBag + "/" + MAX);
                    Console.WriteLine("TOTAL POKEBALLS: " + pokeballs);
            }

        }

        public void ViewPokedex()
        {
            Console.WriteLine(String.Format("{0,5} | {1,-10} | {2,-10} | {3,-10}", "ID", "NAME", "TYPE", "EVOLUTION"));
            Console.WriteLine("-------------------------------------------");
            if (pokedex.Count == 0)
            {
                Console.WriteLine("YOUR POKEDEX IS EMPTY.");
            }
            else
            {
                for (int i = 0; i < pokedex.Count; i++)
                {
                    PokemonRegInfo curPokemon = pokedex.ElementAt(i);
                    string n = curPokemon.GetPokemonName();
                    string e = curPokemon.GetPokemonEvolution();
                    string t = curPokemon.GetPokemonType();
                    Console.WriteLine(String.Format("{0,5} | {1,-10} | {2,-10} | {3,-10}", i + 1, n, t, e));
                }
            }
            Console.WriteLine("===========================================");
            Console.WriteLine("TOTAL REGISTERED: " + pokedex.Count);
        }

        public void EnterPokeStop()
        {

            double tempspins = Math.Floor(spins);
            Console.WriteLine("Number of spins: " + tempspins);
            if (tempspins == 0)
                Console.WriteLine("Catch more pokemons to get more spins");
            else
            {
                Console.Write("Press enter for a chance to get a candy..");
                Console.ReadLine();
                Random spin = new Random();
                spin.Next(1,2);
                if (spin.Next() == 1)
                {
                    Console.WriteLine("Try again!");
                }
                else
                {
                    Console.WriteLine("You got a candy");
                    numCandy++;
                    spins--;
                }
            }
        }
        public void ViewProfile()
        {
            if (prof[0] == null)
            {
                Console.WriteLine(">> UPDATE YOUR TRAINER PROFILE");
                Console.Write("Trainer name: ");
                string name = (Console.ReadLine());
                Console.WriteLine("Choose your Team");
                Console.WriteLine("• 1 for Mystic");
                Console.WriteLine("• 2 for Instinct");
                Console.WriteLine("• 3 for Valor");
                Console.Write("Enter number of choice: ");
                int TeamNumber = int.Parse(Console.ReadLine());
                string team;
                do
                {
                    if (TeamNumber == 1)
                    {
                        team ="Mystic";

                        prof[0] = new Profile(name, team);
                        Console.WriteLine("You've update your profile, " + name + ". Welcome to Team " + team + "!");
                        Console.WriteLine("View your profile again to see changes.");
                    }
                    else if (TeamNumber == 2)
                    {
                        team = "Instinct";

                        prof[0] = new Profile(name, team);
                        Console.WriteLine("You've update your profile, " + name + ". Welcome to Team " + team + "!");
                        Console.WriteLine("View your profile again to see changes.");
                    }
                    else if (TeamNumber == 3)
                    {
                        team = "Valor";

                        prof[0] = new Profile(name, team);
                        Console.WriteLine("You've update your profile, " + name + ". Welcome to Team " + team + "!");
                        Console.WriteLine("View your profile again to see changes.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");
                        TeamNumber = 0;
                    }
                } while (TeamNumber == 0);
            }
            else
            {
                Console.WriteLine("Trainer Name: " + prof[0].GetTrainerName());
                Console.WriteLine("Team: " + prof[0].GetTrainerTeam());
                double level = 1 + xp;
                Console.WriteLine("Level: " + Math.Floor(level));
                Console.WriteLine("Badges: " + badge);
                Console.WriteLine("Registered Pokemons: " + pokedex.Count );
            }
        }

        public PokemonRegInfo FindInPokedex(string name)
        {
            PokemonRegInfo nopokemonyet = null;
            for (int i = 0; i < pokedex.Count; i++)
            {
                PokemonRegInfo thepokemon = pokedex.ElementAt(i);
                if (name.Equals(thepokemon.GetPokemonName(), StringComparison.Ordinal))
                    return thepokemon;
            }
            return nopokemonyet;
        }

        public MyPokemon FindInBag(string name)
        {
            MyPokemon nopokemon = null;
            for (int i = 0; i >= 9; i++)
            {
                MyPokemon yespokemon = bag[i];
                if (name.Equals(bag[i].GetPokemonName(), StringComparison.Ordinal))
                {
                    return yespokemon; 
                }
            }
            return nopokemon;
        }

        public void EnterGym()
        {
            int id;
            double level = 1 + xp;
            if (Math.Floor(level) < 1)
                Console.WriteLine("You must be at least level 4 to enter the gym!");
            else if (numPokemonInBag == 0)
                Console.WriteLine("You don't have any pokemons.");
            else
            {
                if (badge == 0)
                {
                    Console.WriteLine("You've started a gym battle with Roark.");
                    Console.Write("Press enter to start");
                    Console.ReadLine();
                    Console.WriteLine("========================================");
                    int temphp = rndhp.Next(70, 115);
                    Console.WriteLine("Choose the pokemon you want to use");
                    Console.WriteLine(String.Format("{0,5} | {1,-10} | {2,5} | {3,5}", "ID", "NAME", "HP", "CP"));
                    for (int i = 0; i < numPokemonInBag; i++)
                    {
                        string name = bag[i].GetPokemonName();
                        int hp = bag[i].GetHealthPoints();
                        int cp = bag[i].GetCombatPower();
                        Console.WriteLine(String.Format("{0,5} | {1,-10} | {2,5} | {3,5}", i + 1, name, hp, cp));
                    }
                    Console.Write("ENTER ID: ");
                    id = int.Parse(Console.ReadLine());
                    if (id > numPokemonInBag)
                    {
                        Console.WriteLine("INVALID ID.");
                    }
                    else
                    {
                        Console.WriteLine("You chose " + bag[id - 1].GetPokemonName() + " with HP " + bag[id - 1].GetHealthPoints());
                        Console.WriteLine("Roark sent out Graveler with HP " + temphp);
                        if (temphp >= bag[id - 1].GetHealthPoints())
                        {
                            Console.WriteLine("Your pokemon lost to Geodude.");
                        }
                        else
                        {
                            Console.WriteLine("Congratulations! You've defeated Roark!");
                            Console.WriteLine("You earned a badge!");
                            badge++;
                            xp += 2;
                            Console.WriteLine("You earned 2 xp.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You've started a gym battle with Crasher Wake.");
                    Console.Write("Press enter to start");
                    Console.ReadLine();
                    Console.WriteLine("========================================");
                    int temphp = rndhp.Next(300, 1000);
                    Console.WriteLine("Choose the pokemon you want to use");
                    Console.WriteLine(String.Format("{0,5} | {1,-10} | {2,5} | {3,5}", "ID", "NAME", "HP", "CP"));
                    for (int i = 0; i < numPokemonInBag; i++)
                    {
                        string name = bag[i].GetPokemonName();
                        int hp = bag[i].GetHealthPoints();
                        int cp = bag[i].GetCombatPower();
                        Console.WriteLine(String.Format("{0,5} | {1,-10} | {2,5} | {3,5}", i + 1, name, hp, cp));
                    }
                    Console.Write("ENTER ID: ");
                    id = int.Parse(Console.ReadLine());
                    if (id > numPokemonInBag)
                    {
                        Console.WriteLine("INVALID ID.");
                    }
                    else
                    {
                        Console.WriteLine("You chose " + bag[id - 1].GetPokemonName() + " with HP " + bag[id - 1].GetHealthPoints());
                        Console.WriteLine("Crasher Wake sent out Vaporeon with HP " + temphp);
                        if (temphp >= bag[id - 1].GetHealthPoints())
                        {
                            Console.WriteLine("Your pokemon lost to Vaporeon.");
                        }
                        else
                        {
                            Console.WriteLine("Congratulations! You've defeated Crasher Wake!");
                            Console.WriteLine("You earned a badge!");
                            badge++;
                            xp += 3;
                            Console.WriteLine("You earned 3 xp.");
                        }
                    }
                }
            }
        }

        public void EnterShop()
        {
            Console.WriteLine("TOTAL CANDIES: " + numCandy);
            Console.WriteLine("You have {0} pokeballs. How many would you like to buy?", pokeballs);
            Console.Write("Enter number of pokeballs to buy: ");
            int order = int.Parse(Console.ReadLine());
            if (order == 0)
                Console.WriteLine("Thank you. Come again.");
            else
            {
                if (numCandy >= order)
                {
                    Console.WriteLine("{0} pokeballs has been added to your bag.", order);
                    pokeballs += order;
                    numCandy -= order;
                    Console.WriteLine("You now have {0} pokeballs. Thank you!", pokeballs);
                }
                else
                {
                    Console.Write("You don't have enough candies for that order. You need ");
                    Console.Write(order-numCandy);
                    Console.WriteLine(" more.");
                }
            }
        }

        public int GetNumPokemonInBag()
        {
            return numPokemonInBag;
        }

        public string GetMessage()
        {
            return msg;
        }

        public MyPokemon[] GetBag()
        {
            return bag;
        }

        public List<PokemonRegInfo> GetPokemons()
        {
            return pokedex;
        }
        public double GetLevel()
        {
            return xp;
        }

        public void LoadLevel(double more)
        {
            xp = more;
        }

        public void AddCandies(int candies)
        {
            numCandy = candies;
        }

        public int GetNumCandies()
        {
            return numCandy;
        }
        public int GetBadges()
        {
            return badge;
        }

        public void AddBadge()
        {
            badge++;
        }

        public void LoadBadges( int more )
        {
            badge += more;
        }

        public void LoadPotions( int more )
        {
            potions += more;
        }

        public int GetPotions()
        {
            return potions;
        }

        public void BuyPotions(int order)
        {
            if (order > numCandy)
                msg = "You do not have enough candies. You need " + (order - numCandy) + " more candies.";
            else
            {
                potions += order;
                numCandy -= order;
                msg = order + " potions have been added to your bag. " + order + " candies have been used.";
            }
        }

        public void UsePotions()
        {
            potions -= 1;
        }
    }
}
