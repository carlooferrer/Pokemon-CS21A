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
    public class PokemonRegInfo
    {
        private string PokemonName;
        private string PokemonType;
        private string PokemonEvolution;
        private int EvolveCost;
        private int EvolutionMultiplier;

         public PokemonRegInfo(string name, string type, string evolution, int cost, int multiplier)
         {
            PokemonName = name;
            PokemonType = type;
            PokemonEvolution= evolution;
            EvolveCost = cost;
            EvolutionMultiplier = multiplier;
         }


        public string GetPokemonName()
        {
            return PokemonName;
        }
        public string GetPokemonType()
        {
            return PokemonType;
        }
        public string GetPokemonEvolution()
        {
            //if (PokemonEvolution.Equals("None", StringComparison.Ordinal))
            //{
            //    return null;
            //}
            //else
                return PokemonEvolution;
        }
        public int GetEvolutionCost()
        {
            //if (PokemonEvolution.Equals("None", StringComparison.Ordinal))
            //{
            //    return 0;
            
            //}
            //else
            return EvolveCost;
        }
        public int GetEvolutionMultiplier()
        {
            //if (PokemonEvolution.Equals("None", StringComparison.Ordinal))
            //{
            //    return 1;
            //}
            //else
            return EvolutionMultiplier;
        }
        public void SetCost(int n)
        {
            EvolveCost = n;
        }
        public void SetMultiplier(int j)
        {
            EvolutionMultiplier = j;
        }
    }
}
