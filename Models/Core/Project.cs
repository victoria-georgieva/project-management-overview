using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.Core
{
    public class Project
    {
        public int ID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "The field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public int? ProjecttypeID { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public DateTime? DeadLine { get;set; }

        [Required(ErrorMessage = "The field is required")]
        public int? Cost { get; set; }

        //Analysis
        [Required(ErrorMessage = "The field is required")]
        public DateTime? AnalysisPhaseStart { get; set; }
        [Required(ErrorMessage = "The field is required")]
        public DateTime? AnalysisPhaseFinish { get; set; }


        //Estimation
        [Required(ErrorMessage = "The field is required")]
        public DateTime? EstimationPhaseStart { get; set; }
        [Required(ErrorMessage = "The field is required")]
        public DateTime? EstimationPhaseFinish { get; set; }

        // Backend Development
        [Required(ErrorMessage = "The field is required")]
        public DateTime? BackendDevelopmentPhaseStart { get; set; }
        [Required(ErrorMessage = "The field is required")]
        public DateTime? BackendDevelopmentPhaseFinish { get; set; }

        // Fronend Development
        [Required(ErrorMessage = "The field is required")]
        public DateTime? FronendDevelopmentPhaseStart { get; set; }
        [Required(ErrorMessage = "The field is required")]
        public DateTime? FronendDevelopmentPhaseFinish { get; set; }

        // Testing Development
        [Required(ErrorMessage = "The field is required")]
        public DateTime? TestingPhaseStart { get; set; }
        [Required(ErrorMessage = "The field is required")]
        public DateTime? TestingPhaseFinish { get; set; }

        // UAT Development
        [Required(ErrorMessage = "The field is required")]
        public DateTime? UATPhaseStart { get; set; }
        [Required(ErrorMessage = "The field is required")]
        public DateTime? UATPhaseFinish { get; set; }


        // Release Development
        [Required(ErrorMessage = "The field is required")]
        public DateTime? ReleasePhaseStart { get; set; }
        [Required(ErrorMessage = "The field is required")]
        public DateTime? ReleasePhaseFinish { get; set; }


        //public List<ProjectPhase> ProjectPhases { get; set; }


    }
}
