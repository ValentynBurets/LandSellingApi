using System.ComponentModel.DataAnnotations;

namespace Business.Contract.Model
{
    public class ProfileInfoModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Min Name lenght 2")]
        [MaxLength(20, ErrorMessage = "Max Name lenght 20")]
        public string Name { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Min Surname lenght 2")]
        [MaxLength(20, ErrorMessage = "Max Surname lenght 20")]
        public string SurName { get; set; }
    }
}
