using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinancialServices.Models
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Потребителско име")]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Парола")]
        public string Password { get; set; } = null!;
    }
}
