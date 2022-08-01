using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCarePortalLab.Models
    {
    public class Organization
        {
        public Agent GetOrganizationHead( )
            {
            foreach (var Dep in Departments)
                {
                foreach (var team in Dep.Teams)
                    {
                    foreach (var agent in team.Agents)
                        {
                        if (agent.OrganizationHead)
                            return agent;
                        }
                    }
                }
            return null;
            }

        public int OrganizationID { get; set; }
        public string Name { get; set; }
        public List<Department>? Departments { get; set; }
        }
    }
