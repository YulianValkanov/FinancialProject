using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace FinancialServices.Models.Home
{
    public class MspQueryModel
    {
        [Required]       
        [DisplayName("Брой персонал")]
        [Range(0, 100000, ErrorMessage = "Бройя персонал е ограничен до {2} лева")]
        public int Personal { get; set; }

        [DisplayName("Активи")]
        [Required]
        [Range(0, 1000000000, ErrorMessage = "Активите са ограничени до {2} лева")]
        public double Assets { get; set; }

        [DisplayName("Нетни приходи")]
        [Required]
        [Range(0, 1000000000, ErrorMessage = "Нетните приходи са ограничени до {2} лева")]
        public double Revenue { get; set; }


        public string Msp { get; set; } = null!;




    }
}
