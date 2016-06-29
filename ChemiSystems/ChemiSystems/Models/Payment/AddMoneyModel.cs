using System.ComponentModel.DataAnnotations;

namespace ChemiSystems.Models.Payment
{
    public class AddMoneyModel
    {
        [Required]
        [Display(Name = "Сумма")]
        public decimal Amount { get; set; }
    }
}