using SurveySystem.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveySystem.Models
{
    public class TblKPI
    {
        [Key]
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Indicator Number must be a number")]
        public int KPIDNum { get; set; }

        [Required(ErrorMessage = "Enter Description")]
        [StringLength(150, ErrorMessage = "Description must be less than 150")]
        public string KPIDescription { get; set;}

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Department Num must be a number")]
        public int DepNo { get; set;}

        [Required]       
        public bool MeasurementUnit { get; set;}

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Targeted Value must be a number")]
        [PercentageValidationAttribute("MeasurementUnit")]
        public int TargetedValue { get;set;}
    }
}
