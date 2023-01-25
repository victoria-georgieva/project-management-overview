using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.Models.Core
{
    public class ProjectPhase
    {
        public int ID { get; set; }
        public int PhaseTypeID { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }    
        public int projectID { get; set; }

        [ForeignKey("projectID")]
        public Project project { get; set; }


    }
}
