using System.ComponentModel.DataAnnotations;

namespace CustomerCarePortalLab.Models
    {
    public enum Types
        {
        Bug = 1, Sales, Information, CustomerFeedback, TechnicalSupport
        }

    public enum Status
        {
        ToDo = 1, InProgress, Completed
        }
    public class Ticket
        {
        public void AssignTo( ref Agent agent )
            {
            agent.AssignTicket( this );
            Allocated = true;
            }
        public bool IsAssignedTo( Agent agent )
            {
            return agent.Tickets.Contains( this );
            }
        public int TicketID { get; set; }
        public string Email { get; set; }
        [StringLength( 100 )]
        public string Comments { get; set; }
        public Types TicketType { get; set; } = Types.Information;
        public Status TicketStatus { get; set; } = Status.ToDo;
        public bool Allocated { get; set; } = false;// check
        }
    }
