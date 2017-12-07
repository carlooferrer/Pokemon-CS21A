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
    public class Profile
    {
        private string TrainerName;
        private string TrainerTeam;

        public Profile(string name, string team)
        {
            TrainerName = name;
            TrainerTeam = team;
        }
        public string GetTrainerName()
        {
            if (TrainerName == null)
                return null;
            else
                return TrainerName;
        }
        public string GetTrainerTeam()
        {
            return TrainerTeam;
        }
    }
}
