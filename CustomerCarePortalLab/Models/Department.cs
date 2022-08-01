namespace CustomerCarePortalLab.Models
    {
    public class Department
        {

        public Agent GetDepartmentHead( )
            {
            foreach (var team in Teams)
                {
                foreach (var agent in team.Agents)
                    {
                    if (agent.DepartmentHead)
                        return agent;
                    }
                }
            return null;
            }

        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
        }
    }
