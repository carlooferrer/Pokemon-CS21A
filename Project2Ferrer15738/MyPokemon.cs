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
    public class MyPokemon
    {
        private string PokemonName;
        private int HealthPoints;
        private int CombatPower;
        private string PokemonEvolution;
        private int EvolutionMultiplier;
        private int EvolutionCost;
        private string PokeType;

        public MyPokemon(string name, string t, int hp, int cp, string ev, int em, int ec)
         {
            PokemonName = name;
            PokeType = t;
            HealthPoints = hp;
            CombatPower = cp;
            PokemonEvolution = ev;
            if (PokemonEvolution == "None" || PokemonEvolution == "none")
                PokemonEvolution = null;
            EvolutionMultiplier = em;
            EvolutionCost = ec;
         }
        
        public string GetPokemonName()
        {
            return PokemonName;
        }

        public int GetHealthPoints()
        {
            return HealthPoints;
        }

        public int GetCombatPower()
        {
            return CombatPower;
        }

        public string GetEvolution()
        {
        //    if(PokemonEvolution.Equals("None", StringComparison.Ordinal))
        //    {
        //        return null;
        //    }
        //    else
            return PokemonEvolution;
        }

        public void SetPokemonName(string newname)
        {
            PokemonName = newname;
        }
        public void SetPokemonHp(int newhp)
        {
            HealthPoints = newhp;
        }
        public void SetPokemonCp(int newcp)
        {
             CombatPower = newcp;
        }
        public void SetPokemonEvolution(string newev)
        {
            PokemonEvolution = newev;
        }
        public int GetEvolutionMultiplier()
        {
            return EvolutionMultiplier;
        }
        public int GetEvolutionCost()
        {
            return EvolutionCost;
        }
        public string GetType()
        {
            return PokeType;
        }
    }
}
