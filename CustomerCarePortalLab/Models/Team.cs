using System.ComponentModel.DataAnnotations;

namespace CustomerCarePortalLab.Models
    {
    public class Team
        {
        public Agent GetTeamManager( )
            {
            foreach (var agent in Agents)
                {
                if (agent.TeamManager)
                    return agent;
                }
            return null;
            }
        public void ChangeTeamManager( Agent teamManager )
            {
            foreach (var agent in Agents)
                {
                if (agent.TeamManager) // revoke existing team manager
                    agent.TeamManager = false;
                }
            if (teamManager.TeamID == TeamID)
                {
                Agents.Add( teamManager ); // add new team manager
                teamManager.TeamManager = true; // give team manager's authorities
                }
            }
        public Agent GetAssignee( Ticket ticket )
            {
            foreach (Agent agent in Agents)
                {
                agent.HasTicket( ticket );
                return agent;
                }
            return null;
            }

        public int TeamID { get; set; }
        public string Name { get; set; }

        public int DepartmentID { get; set; }

        public List<Agent> Agents { get; set; }
        }
    }
