using Developers;
using DeveloperTeams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeams
{
    public class DevTeamRepo
    {
        protected readonly List<DevTeam> _devTeamDirectory = new List<DevTeam>();
        
        //Create
        public bool AddTeam(DevTeam newTeam)
        {
            int count = _devTeamDirectory.Count();
            _devTeamDirectory.Add(newTeam);
            bool wasAdded = (_devTeamDirectory.Count > count) ? true : false;
            return wasAdded;
        }

        //Read
        public List<DevTeam> GetAllTeams()
        {
            return _devTeamDirectory;
        }

        public void DisplayAllTeams()
        {
            foreach (DevTeam team in _devTeamDirectory)
            {
                string teamInfo = $"{team.TeamID.ToString()} {team.TeamName}";
                Console.WriteLine(teamInfo);
            }
        }

        public DevTeam GetByTeamID(int ID)
        {
            foreach (DevTeam team in _devTeamDirectory)
            {
                if (team.TeamID == ID)
                {
                    return team;
                }
            }
            return null;
        }

        //Update
        public bool UpdateTeam(int teamID, DevTeam updatedTeam)
        {
            DevTeam oldInfo = GetByTeamID(teamID);
            if (oldInfo != null)
            {
                oldInfo.TeamID = updatedTeam.TeamID;
                oldInfo.TeamName = updatedTeam.TeamName;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddTeamMember(int teamID, int id)
        {
            DevTeam oldInfo = GetByTeamID(teamID);
            if (oldInfo != null)
            {
                oldInfo.DevList.Add(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveTeamMember(int teamID, int id)
        {
            DevTeam oldInfo = GetByTeamID(teamID);
            if (oldInfo != null)
            {
                oldInfo.DevList.Remove(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveTeam(DevTeam team)
        {
            bool removeResult = _devTeamDirectory.Remove(team);
            return removeResult;
        }

    }
}
