using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCarePortalLab.Models
    {
    public class Agent
        {
        public void AssignTicket( Ticket ticket )
            {
            Tickets.Add( ticket );
            }
        public bool HasTicket( Ticket ticket )
            {
            return Tickets.Contains( ticket );
            }
        public int AgentID { get; set; }
        public string Name { get; set; }

        [Display( Name = "Team Leader" )]
        public bool TeamManager { get; set; }

        [Display( Name = "Head of Department" )]
        public bool DepartmentHead { get; set; }

        [Display( Name = "Head of Organization" )]
        public bool OrganizationHead { get; set; }

        [Display( Name = "Team's ID" )]
        public int TeamID { get; set; }

        [Display( Name = "Ticket ID" )]
        public int TicketID { get; set; } = 0;
        public List<Ticket> Tickets { get; }

        }
    }
