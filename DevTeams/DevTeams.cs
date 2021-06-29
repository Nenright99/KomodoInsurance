using Developers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeams
{
    public class DevTeam
    {
        public DevTeam() { }
        public DevTeam(int teamID, string teamName)
        {
            TeamID = teamID;
            TeamName = teamName;
        }

        public int TeamID { get; set; }
        public string TeamName { get; set; }
        //List by IDs
        public List<int> DevList = new List<int>();
    }
}
